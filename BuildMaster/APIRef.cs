using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using System.IO.IsolatedStorage;
using System.IO;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

//The main load of API interfacing and class storage code.

namespace BuildMaster
{
    public class meRoot { public me user; } //Why do I U ser root files? Mainly to make it easier to interface with the settings, but also because I couldn't be bothered to mess with the API responses.
    public class gameRoot { public game[] games; }
    public class me //We only store the data needed.
    {
        public int id;
        public string key;
        public string cover_url;
        public string username;
        public int listIndex;
        public string url;
    }
    static class dataDicts //Dictionaries storing all the user data.
    {
        public static Dictionary<string, me> allAccounts = new Dictionary<string, me>();
        public static Dictionary<string, game> allGames = new Dictionary<string, game>();
        public static Dictionary<string, channel> allChannels = new Dictionary<string, channel>();
        public static Dictionary<string, trigger> allTriggers = new Dictionary<string, trigger>();
    }
    public class game //Same as me, we don't store any unneeded info
    {
        public string cover_url;
        public string created_at;
        public int id;
        public string key;
        public bool p_android;
        public bool p_linux;
        public bool p_osx;
        public bool p_windows;
        public string title;
        public string url;
        public int listIndex;
        public string username;
    }
    public class channel //Build channels on the menu
    {
        public string informalName;
        public string formalName;
        public int listIndex;
        public channel(string informalName, string formalName)
        {
            this.informalName = informalName;
            this.formalName = formalName;
        }
    }
    public class trigger //Automation actions post upload.
    {
        public string name;
        public string type;
        public string link; //Program/URL
        public string args;
        public int listIndex;
        public trigger(string name, string type, string link, string args)
        {
            this.name = name;
            this.type = type;
            this.link = link;
            this.args = args;
        }
    }
    public class reader //Reads data from the API or from storage.
    {
        public List<string> workingKeyList = new List<string>(); //Working API keys for usage.
        public List<me> workingUserList = new List<me>();
        public void accountRead(ListView list) //Clears and realoads all account data using the keys stored in secure storage.
        {
            dataDicts.allAccounts.Clear();
            workingKeyList.Clear();
            workingUserList.Clear();
            HttpWebResponse response;
            using (IsolatedStorageFile isoStore = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Domain | IsolatedStorageScope.Assembly, null, null))
            {
                if (!isoStore.DirectoryExists("BuildMaster")) return;
                for (int i = 0; i < Properties.Settings.Default.accountVol; i++)
                {
                    if (!isoStore.FileExists("BuildMaster/Account" + i)) continue;
                    using (IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream("BuildMaster/Account" + i, FileMode.Open, isoStore))
                    {
                        using (StreamReader reader = new StreamReader(isoStream))
                        {
                            workingKeyList.Add(reader.ReadLine());
                        }
                    }
                }
                foreach (string key in workingKeyList) //Polls the itch.io API to get account info.
                {
                    response = webRequest(key, "/me");
                    if (response == null) return;
                    var content = new StreamReader(response.GetResponseStream()).ReadToEnd();
                    var result = JsonConvert.DeserializeObject<meRoot>(content);
                    result.user.key = key;
                    workingUserList.Add(result.user);
                }
                if (list != null)
                {
                    if (list.Items.Count > 1)
                    {
                        for (int i = 1; i == list.Items.Count - 1; i++)
                        {
                            list.Items[i].Remove();
                        }
                    }
                }
                foreach (me user in workingUserList) //Readd the info.
                {
                    if (list != null)
                    {
                        if (!list.Items.ContainsKey(user.username))
                        {
                            ListViewItem listEntry = new ListViewItem();
                            listEntry.Text = user.username;
                            listEntry.Name = user.username;
                            list.Items.Add(listEntry);
                            user.listIndex = list.Items.Find(user.username, true)[0].Index;
                        }
                    }
                    dataDicts.allAccounts.Add(user.username, user);
                }
            }
        }
        public void gameRead(ListView list, ComboBox[] gameSelecters) //Clears and reloads all game data, to add games or update them as needed.
        {
            dataDicts.allGames.Clear();
            HttpWebResponse response;
            HttpWebResponse auxResponse;
            if (list != null)
            {
                list.Items.Clear();
            }
            foreach (string key in workingKeyList)
            {
                response = webRequest(key, "/my-games");
                if (response == null) return;
                var content = new StreamReader(response.GetResponseStream()).ReadToEnd();
                var result = JsonConvert.DeserializeObject<gameRoot>(content);
                foreach (game inGame in result.games)
                {
                    inGame.key = key;
                    auxResponse = webRequest(key, "/me");
                    if (auxResponse == null) return;
                    var auxContent = new StreamReader(auxResponse.GetResponseStream()).ReadToEnd();
                    var auxResult = JsonConvert.DeserializeObject<meRoot>(auxContent);
                    inGame.username = auxResult.user.username;
                    if (list != null)
                    {
                        if (!list.Items.ContainsKey(inGame.title))
                        {
                            ListViewItem listEntry = new ListViewItem();
                            listEntry.Text = inGame.title;
                            listEntry.Name = inGame.title;
                            list.Items.Add(listEntry);
                            inGame.listIndex = list.Items.Find(inGame.title, true)[0].Index;
                        }
                    }
                    if (gameSelecters != null)
                    {
                        foreach (ComboBox selection in gameSelecters)
                        {
                            if (!selection.Items.Contains(inGame.title))
                            {
                                selection.Items.Add(inGame.title);
                            }
                        }
                    }
                    dataDicts.allGames.Add(inGame.title, inGame);
                }

            }
        }
        public void fixChannelData() //A fix for an early bug, that remediates channel settings to replace dashes with | as a divider.
        {
            Properties.Settings.Default.channels = Properties.Settings.Default.channels.Replace("}-{", "}|{");
            Properties.Settings.Default.Save();
        }
        public void channelRead(ListView list, ComboBox[] chanSelecters) //Since we're only pulling channel data from storage, this is nice and easy.
        {
            dataDicts.allChannels.Clear();
            if (list != null)
            {
                if (list.Items.Count > 1)
                {
                    for (int i = 1; i == list.Items.Count - 1; i++)
                    {
                        list.Items[i].Remove();
                    }
                }
            }
            string[] workingChanList = Properties.Settings.Default.channels.Split('|');
            foreach (string chanstr in workingChanList)
            {
                if (chanstr.Contains("}-{"))
                {
                    fixChannelData();
                    channelRead(list, chanSelecters);
                    return;
                }
                channel deserializedChan = JsonConvert.DeserializeObject<channel>(chanstr);
                if (list != null)
                {
                    if (!list.Items.ContainsKey(deserializedChan.informalName))
                    {
                        ListViewItem listEntry = new ListViewItem();
                        listEntry.Text = deserializedChan.informalName;
                        listEntry.Name = deserializedChan.informalName;
                        list.Items.Add(listEntry);
                        deserializedChan.listIndex = list.Items.Find(deserializedChan.informalName, true)[0].Index;
                    }
                }
                if (chanSelecters != null)
                {
                    foreach (ComboBox selection in chanSelecters)
                    {
                        if (!selection.Items.Contains(deserializedChan.informalName))
                        {
                            selection.Items.Add(deserializedChan.informalName);
                        }
                    }
                }
                dataDicts.allChannels.Add(deserializedChan.informalName, deserializedChan);
            }
        }
        public void triggerRead(ListView list, ComboBox trigSelector) //Same as channel data, just from storage.
        {
            dataDicts.allTriggers.Clear();
            if (list != null)
            {
                if (list.Items.Count > 1)
                {
                    for (int i = 1; i == list.Items.Count - 1; i++)
                    {
                        list.Items[i].Remove();
                    }
                }
            }
            string[] workingTrigList = Properties.Settings.Default.triggers.Split('|');
            foreach (string trigstr in workingTrigList)
            {
                trigger deserializedTrig = JsonConvert.DeserializeObject<trigger>(trigstr);
                if (list != null)
                {
                    if (!list.Items.ContainsKey(deserializedTrig.name))
                    {
                        ListViewItem listEntry = new ListViewItem();
                        listEntry.Text = deserializedTrig.name;
                        listEntry.Name = deserializedTrig.name;
                        list.Items.Add(listEntry);
                        deserializedTrig.listIndex = list.Items.Find(deserializedTrig.name, true)[0].Index;
                    }
                }
                if (trigSelector != null)
                {
                    if (!trigSelector.Items.Contains(deserializedTrig.name))
                    {
                        trigSelector.Items.Add(deserializedTrig.name);
                    }
                }
                dataDicts.allTriggers.Add(deserializedTrig.name, deserializedTrig);
            }
        }
        public void channelAdd(channel chan) //Don't ask why all serialisation is done under the variable name cereal down here. again, lockdown. This stores the channel and trigger data as one string, with a traditional seperator. I really should've either used a control character or an array to store this, but hey I'm an idiot and this is old code.
        {
            string cereal = JsonConvert.SerializeObject(chan);
            if (Properties.Settings.Default.channels != "") Properties.Settings.Default.channels += "|" + cereal;
            else Properties.Settings.Default.channels += cereal;
            Properties.Settings.Default.Save();
            Console.WriteLine(Properties.Settings.Default.channels);
        }
        public void triggerAdd(trigger trig) //See above.
        {
            string cereal = JsonConvert.SerializeObject(trig);
            if (Properties.Settings.Default.triggers != "") Properties.Settings.Default.triggers += "|" + cereal;
            else Properties.Settings.Default.triggers += cereal;
            Properties.Settings.Default.Save();
            Console.WriteLine(Properties.Settings.Default.triggers);
        }
        public void channelDelete(channel chan) //The opposite of above
        {
            dataDicts.allChannels.Remove(chan.informalName);
            Properties.Settings.Default.channels = "";
            foreach (channel reChan in dataDicts.allChannels.Values)
            {
                string cereal = JsonConvert.SerializeObject(reChan);
                if (Properties.Settings.Default.channels != "") Properties.Settings.Default.channels += "|" + cereal;
                else Properties.Settings.Default.channels += cereal;
            }
            Properties.Settings.Default.Save();
        }
        public void triggerDelete(trigger trig) // ^
        {
            dataDicts.allTriggers.Remove(trig.name);
            Properties.Settings.Default.triggers = "";
            foreach (trigger reTrig in dataDicts.allTriggers.Values)
            {
                string cereal = JsonConvert.SerializeObject(reTrig);
                if (Properties.Settings.Default.triggers != "") Properties.Settings.Default.triggers += "|" + cereal;
                else Properties.Settings.Default.triggers += cereal;
            }
            Properties.Settings.Default.Save();
        }
        private HttpWebResponse webRequest(string key, string scope) //The web request system - since we only need to make requests to V1 of the itch.io API, that's all that's scoped. Error logging is rudimetary but functional.
        {
            HttpWebResponse response;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"https://itch.io/api/1/" + key + scope);
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException ex)
            {
                using (var stream = ex.Response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    string error = reader.ReadToEnd();
                    PopupForm popup = new PopupForm("An unexpected error occured!\n Make sure your API key is correct, otherwise this may be a bug.\nResponse: " + error);
                }
                return null;
            }
            catch (Exception)
            {
                PopupForm popup = new PopupForm("An unexpected error occured!\nMake sure you are connected to the internet - otherwise, try again later!");
                DialogResult dialogresult = popup.ShowDialog();
                return null;
            }
            return response;
        }
    }

}
