using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections.Specialized;
using System.Net;
using Newtonsoft.Json;
using System.Diagnostics;
using System.IO.IsolatedStorage;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace BuildMaster
{
    public partial class Form4 : Form
    {
        reader Reader = new reader(); //Pull in stuff from APIRef
        public string workingKey; //Working API key for requests.
        public me currentUser; //Working data storage for all menu items.
        public game currentGame;
        public channel currentChan;
        public trigger currentTrig;
        public Form4()
        {

            InitializeComponent();
            Utilities.colourManager.colourDefinition(this, Properties.Settings.Default.BackColour, Properties.Settings.Default.ForeColour);
            accountInfoBox.Parent = Accounts; //Why these are defined here? I don't remember.
            accountInfoBox.Location = addAccountBox.Location;
            channelInfoBox.Parent = channelsPage;
            channelInfoBox.Location = addChannelBox.Location;
            Reader.accountRead(listView2); //Read and apply account data to displays.
            Reader.gameRead(gamesList, null);
            Reader.channelRead(channelList, null);
            Reader.triggerRead(triggerList, null);
        }
        private void gamesList_SelectedIndexChanged(object sender, EventArgs e) //When game selections picked..
        {
            if (gamesList.SelectedIndices.Count > 0) //If any games present
            {
                groupBox1.Text = "Game"; //Display and populate the menu data.
                foreach (game inGame in dataDicts.allGames.Values)
                {
                    if (inGame.listIndex == gamesList.SelectedIndices[0])
                    {
                        currentGame = inGame;
                        titleField.Text = "Title: " + currentGame.title;
                        gameAccLink.Text = "Linked to Account: " + inGame.username;
                        gameCover.SizeMode = PictureBoxSizeMode.Zoom;
                        if (inGame.cover_url != null) gameCover.Load(inGame.cover_url);
                        string gameChans = "Playable on: \n";
                        if (inGame.p_windows) gameChans += "Windows\n";
                        if (inGame.p_osx) gameChans += "Mac OS X\n";
                        if (inGame.p_linux) gameChans += "Linux\n";
                        if (inGame.p_android) gameChans += "Android";
                        playableOn.Text = gameChans;
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e) //I apologise for the arbitrary names. I have gotten better, I promise. I never planned on releasing this, but here we are.
        {
            System.Diagnostics.Process.Start("https://itch.io/api-keys");
        }

        private void button5_Click(object sender, EventArgs e) //Check Account
        {
            HttpWebResponse response;
            string key = textBox4.Text;
            if (key == "")
            {
                PopupForm popup = new PopupForm("Please provide an API Key!");
                DialogResult dialogresult = popup.ShowDialog();
                return;
            }
            response = webRequest(key, "/credentials/info"); //Check key for validity
            if (response == null) return;
            string content = new StreamReader(response.GetResponseStream()).ReadToEnd();
            if (content.Contains("errors")) //Bad response
            {
                if (content.Contains("invalid key"))
                {
                    PopupForm popup = new PopupForm("An invalid key was sent - please provide a valid API key\nAPI Responded: " + content);
                    DialogResult dialogresult = popup.ShowDialog();
                    return;
                }
                else
                {
                    PopupForm popup = new PopupForm("An unexpected error occured - please ensure your API key is valid - if it is, this may be a bug.\nAPI Responded: " + content);
                    DialogResult dialogresult = popup.ShowDialog();
                    return;
                }
            }
            else //Good credentials returned
            {
                label11.Visible = true; //Affirms Valid key
                workingKey = key; //Set to be the active key.
                response = webRequest(key, "/me");
                if (response == null) return;
                content = new StreamReader(response.GetResponseStream()).ReadToEnd();
                var result = JsonConvert.DeserializeObject<meRoot>(content);
                label12.Text = "Username: " + result.user.username;
                label12.Visible = true;
                foreach (me user in dataDicts.allAccounts.Values)
                {
                    if (user.id == result.user.id)
                    {
                        PopupForm popup = new PopupForm("This user has already been added! Please use a different account.");
                        DialogResult dialogresult = popup.ShowDialog();
                        return;
                    }
                }
                button6.Enabled = true; //Once all checks done, enables the save button.
            }
        }

        private void button6_Click(object sender, EventArgs e) //Save account data.
        {
            using (IsolatedStorageFile isoStore = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Domain | IsolatedStorageScope.Assembly, null, null))
            {
                if (!isoStore.DirectoryExists("BuildMaster"))
                {
                    isoStore.CreateDirectory("BuildMaster");
                }
                using (IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream("BuildMaster/Account" + Properties.Settings.Default.accountVol, FileMode.CreateNew, isoStore))
                {
                    using (StreamWriter writer = new StreamWriter(isoStream))
                    {
                        writer.WriteLine(workingKey);
                    }
                }
                Properties.Settings.Default.accountVol += 1;
                Properties.Settings.Default.Save();
            }
            Reader.accountRead(listView2); //Reload account dat.
            Reader.gameRead(gamesList, null);
        }
        private HttpWebResponse webRequest(string key, string scope) //API requester? I assume used to validate keys.
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
        private void button7_Click(object sender, EventArgs e) //Removes accounts
        {
            using (IsolatedStorageFile isoStore = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Domain | IsolatedStorageScope.Assembly, null, null))
            {
                if (!isoStore.DirectoryExists("BuildMaster")) return; 
                for (int i = 0; i < Properties.Settings.Default.accountVol; i++)
                {
                    if (!isoStore.FileExists("BuildMaster/Account" + i)) continue;
                    else isoStore.DeleteFile("BuildMaster/Account" + i);
                }
                Properties.Settings.Default.accountVol = 0;
                Properties.Settings.Default.Save();
                isoStore.DeleteDirectory("BuildMaster");, 
                Reader.accountRead(listView2);
                Reader.gameRead(gamesList, null);
            }
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e) //This is the account list viewer. 
        {
            if (listView2.SelectedIndices.Count > 0)
            {
                if (listView2.SelectedIndices[0] == 0) //If nonme, show the add prompt.
                {
                    accountInfoBox.Visible = false;
                    addAccountBox.Visible = true;
                }
                else
                {
                    addAccountBox.Visible = false;
                    accountInfoBox.Visible = true;
                    foreach (me user in dataDicts.allAccounts.Values) //Shows the relevant data.
                    {
                        if (user.listIndex == listView2.SelectedIndices[0]) //For the first item
                        {
                            currentUser = user; //Shows the relevant data straight away.
                            usernameField.Text = "Username: " + user.username;
                            urlField.Text = "Profile: " + user.url;
                            if (user.cover_url != null) profilePic.Load(user.cover_url);
                            string gameList = "Games on Account: \n";
                            foreach (game inGame in dataDicts.allGames.Values) //Lists the games on the account.
                            {
                                if (inGame.username == user.username)
                                {
                                    gameList += inGame.title + "\n";
                                }
                            }
                            gameListLabel.Text = gameList;
                        }
                    }
                }
            }
        }

        private void accountDashButt_Click(object sender, EventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("https://itch.io/dashboard");
            Process.Start(sInfo);
        }

        private void logOutButt_Click(object sender, EventArgs e) //Log an individual account out from selection, clears from secure storage.
        {
            using (IsolatedStorageFile isoStore = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Domain | IsolatedStorageScope.Assembly, null, null))
            {
                if (!isoStore.DirectoryExists("BuildMaster")) return;
                if (isoStore.FileExists("BuildMaster/Account" + Reader.workingKeyList.IndexOf(currentUser.key)))
                {
                    isoStore.DeleteFile("BuildMaster/Account" + Reader.workingKeyList.IndexOf(currentUser.key));
                }
                Properties.Settings.Default.accountVol -= 1;
                Properties.Settings.Default.Save();
                PopupForm success = new PopupForm("Logged out. You may need to restart the program for changes to be shown.");
                DialogResult dialogresult = success.ShowDialog();
                dataDicts.allAccounts.Remove(currentUser.username);
                Reader.accountRead(listView2); //Reloads data.
                Reader.gameRead(gamesList, null);
            }
        }

        private void channelList_SelectedIndexChanged(object sender, EventArgs e) //Shows channels box
        {
            if (channelList.SelectedIndices.Count > 0)
            {
                if (channelList.SelectedIndices[0] == 0)
                {
                    channelInfoBox.Visible = false;
                    addChannelBox.Visible = true; //If none, adds a add prompt.
                }
                else
                {
                    addChannelBox.Visible = false;
                    channelInfoBox.Visible = true;
                    foreach (channel chan in dataDicts.allChannels.Values) //Loads all the channel info
                    {
                        if (chan.listIndex == channelList.SelectedIndices[0])
                        {
                            currentChan = chan;
                            if (currentChan.formalName == "win64" || currentChan.formalName == "win32" || currentChan.formalName == "osx" || currentChan.formalName == "linux64") deleteChannel.Enabled = false;
                            else deleteChannel.Enabled = true;
                            channelInformalName.Text = "UI Name: " + chan.informalName;
                            channelFormalName.Text = "Butler Name: " + chan.formalName;
                            string platList = "Auto-Detected Platforms: \n";
                            if (chan.formalName.Contains("win")) platList += "Windows \n";
                            if (chan.formalName.Contains("osx")) platList += "Mac OS X \n";
                            if (chan.formalName.Contains("linux")) platList += "Linux \n";
                            if (chan.formalName.Contains("android")) platList += "Android \n";
                            autoDetectPlat.Text = platList;
                        }
                    }
                }
            }
        }
        private void triggerList_SelectedIndexChanged(object sender, EventArgs e) //Show triggers.
        {
            if (triggerList.SelectedIndices.Count > 0)
            {
                if (triggerList.SelectedIndices[0] == 0)
                {
                    triggerInfoBox.Visible = false;
                    addTriggerBox.Visible = true;
                }
                else
                {
                    addTriggerBox.Visible = false;
                    triggerInfoBox.Visible = true;
                    foreach (trigger trig in dataDicts.allTriggers.Values)
                    {
                        if (trig.listIndex == triggerList.SelectedIndices[0])
                        {
                            currentTrig = trig;
                            if (currentTrig.name == "Example") deleteTrigger.Enabled = false; //Example trigger is used to show how it works.
                            else deleteTrigger.Enabled = true;
                            triggerInfoName.Text = "Name: " + trig.name;
                            triggerInfoType.Text = "Type: " + trig.type;
                            if (trig.type == "Program") triggerInfoLink.Text = "Program: " + trig.link;
                            else triggerInfoLink.Text = "URL: " + trig.link;
                            triggerInfoArgs.Text = "Arguments: " + trig.args;

                        }
                    }
                }
            }
        }
        private void addChannelConfirmButton_Click(object sender, EventArgs e) //Add channels.
        {
            foreach (channel chan in dataDicts.allChannels.Values)
            {
                if (chan.formalName == butlerNameInput.Text)
                {
                    PopupForm popup = new PopupForm("You already have a channel setup for this! Please use a different formal channel name.");
                    DialogResult wrong = popup.ShowDialog();
                    return;
                }
            }
            Reader.channelAdd(new channel(UInameInput.Text, butlerNameInput.Text));
            PopupForm success = new PopupForm("Channel Created.");
            Reader.channelRead(channelList, null);
            DialogResult dialogresult = success.ShowDialog();
        }

        private void deleteChannel_Click(object sender, EventArgs e)
        {
            Reader.channelDelete(currentChan);
            PopupForm success = new PopupForm("Channel deleted.");
            Reader.channelRead(channelList, null);
            DialogResult dialogresult = success.ShowDialog();
        }

        private void addTriggerTypeSelector_SelectedIndexChanged(object sender, EventArgs e) //Adding either a program or URL open trigger.
        {
            if (addTriggerTypeSelector.SelectedIndex == 0)
            {
                programWebhookLabel.Text = "Program:";
                addTriggerSelectProgramButt.Enabled = true;
                addTriggerArgumentsDescription.Text = "Arguments - To provide input variables at build time\n(up to 3) use variables { v1} { v2} { v3}";
            }
            else
            {
                programWebhookLabel.Text = "URL:";
                addTriggerSelectProgramButt.Enabled = false;
                addTriggerArgumentsDescription.Text = "Arguments - JSON Format please! To provide input\nvariables at build time (up to 3) use variables { v1} { v2}\n{ v3} - Sidenote, webhooks use a POST request.";
            }
        }

        private void addTriggerSelectProgramButt_Click(object sender, EventArgs e) //Select a program to open with a trigger.
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                addTriggerProgURLTextbox.Text = dialog.FileName;
            }
        }

        private void addTriggerButt_Click(object sender, EventArgs e)
        {
            Reader.triggerAdd(new trigger(addTriggerNameBox.Text, addTriggerTypeSelector.SelectedItem.ToString(), addTriggerProgURLTextbox.Text, addTriggerArgsBox.Text));
            PopupForm success = new PopupForm("Trigger created.");
            Reader.triggerRead(triggerList, null);
            DialogResult dialogresult = success.ShowDialog();
        }

        private void deleteTrigger_Click(object sender, EventArgs e)
        {
            Reader.triggerDelete(currentTrig);
            PopupForm success = new PopupForm("Trigger deleted.");
            Reader.triggerRead(triggerList, null);
            DialogResult dialogresult = success.ShowDialog();
        }

        private void themeSelector_SelectedIndexChanged(object sender, EventArgs e) //Theme changed.
        {
            if (themeSelector.SelectedIndex == 0) Utilities.colourManager.colourDefinition(this, System.Drawing.SystemColors.Control, System.Drawing.SystemColors.ControlText);
            
            else Utilities.colourManager.colourDefinition(this, Color.FromArgb(12, 12, 12), Color.White);
        }
    }
}
