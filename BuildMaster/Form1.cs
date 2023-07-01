//Dependancies
using System;
using System.IO;
using System.IO.IsolatedStorage;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Net.Http;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using Microsoft.WindowsAPICodePack.Dialogs;
using Newtonsoft.Json;
using System.Net;



namespace BuildMaster 
{
    public partial class Form1 : Form
    {
        reader Reader = new reader(); //Instantiates API References.
        //Variables
        string cmd; //command before executing
        int NoOfBuilds = 1; //Amount of builds for compilation
        int BuildsCompleted; //Amount of queued builds completed?
        ComboBox[] buildChannels; //All the different build channel boxes
        Control[] setupControls; //All the controls.
        TextBox[] buildFolders; //ALl build locations
        TextBox[] customVersions; //Custom version strings
        Dictionary<int, int> threadProgress = new Dictionary<int, int>(); //Storage for individual thread butler progress
        Dictionary<int, channel> channelData = new Dictionary<int, channel>(); //As described
        game gameData;
        trigger trigData;
        QuickPushMenu qpm; //A instance of the quick push menu - stored globally because this form needs all the data from it when it quits.
        bool quickPush;
        private static readonly HttpClient client = new HttpClient(); //Used for trigger requests.
        public Form1() //Initialiser
        {
            InitializeComponent();
            Utilities.colourManager.initFont();
            Reader.accountRead(null); //Reads account data to update menus.
            Reader.gameRead(null, new ComboBox[] { GameSelection, GameSelection2, GameSelection3, GameSelection4 });
            if (Properties.Settings.Default.channels == "")
            {
                Reader.channelAdd(new channel("Win64", "win64"));
                Reader.channelAdd(new channel("Win32", "win32"));
                Reader.channelAdd(new channel("Mac OS X", "osx"));
                Reader.channelAdd(new channel("Linux64", "linux64"));
            }
            if (Properties.Settings.Default.triggers == "") Reader.triggerAdd(new trigger("Example", "program", "cmd", "/C echo This is an example")); //Example trigger, shiws how they work
            buildChannels = new ComboBox[] { BuildChannel, BuildChannel2, BuildChannel3, BuildChannel4 }; //Assign all the default variables
            Reader.channelRead(null, buildChannels);
            Reader.triggerRead(null, triggerSelector);
            buildFolders = new TextBox[] { BuildFolder, BuildFolder2, BuildFolder3, BuildFolder4 };
            customVersions = new TextBox[] { customVersion, customVersion2, customVersion3, customVersion4 };
            setupControls = new Control[] { GameSelection, Build2Check, Build3Check, Build4Check, BuildChannel, BuildChannel2, BuildChannel3, BuildChannel4, BuildFolder, BuildFolder2, BuildFolder3, BuildFolder4, buildFolderBrowser, buildFolderBrowser2, buildFolderBrowser3, buildFolderBrowser4, PostDevlog, BuildButton, DiscreteBuild, triggerSelector, triggerVar1, triggerVar2, triggerVar3, buildFileBrowser, buildFileBrowser2, buildFileBrowser3, buildFileBrowser4, customVersion, customVersion2, customVersion3, customVersion4};
            Utilities.colourManager.colourDefinition(this, Properties.Settings.Default.BackColour, Properties.Settings.Default.ForeColour); //Theme loading
            gameBuildingPicture.Image = gameBuildingPicture.InitialImage; //Default image for no game selected.
            pSend.InstanceName = new PerformanceCounterCategory(pSend.CategoryName).GetInstanceNames()[0]; //Loads up the CPU, ram and network counters
            statUpdate.Start(); //Starts above counters.
        }
        private void BrowseForBuildFolder_Click(object sender, EventArgs e) //First channel folder browser.
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                BuildFolder.Text = dialog.FileName;
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) //keyboard shortcuts literally just interact with the menu items.
        {
            if (keyData == (Keys.Control | Keys.S))
            {
                saveSettingsFileToolStripMenuItem.PerformClick();
            }
            if (keyData == (Keys.Control | Keys.O))
            {
                loadSettingsFileToolStripMenuItem.PerformClick();
            }
            if (keyData == (Keys.Control | Keys.Q))
            {
                quickPushToolStripMenuItem.PerformClick();
            }
            if (keyData == (Keys.Control | Keys.X))
            {
                exitToolStripMenuItem.PerformClick();
            }
            if (keyData == (Keys.Control | Keys.P))
            {
                preferencesToolStripMenuItem.PerformClick();
            }
            if (keyData == (Keys.Control | Keys.B))
            {
                BuildButton.PerformClick();
            }
            if (keyData == (Keys.Control | Keys.D))
            {
                viewConsoleToolStripMenuItem.PerformClick();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void BuildButton_Click(object sender, EventArgs e) //When the big build button pressed!
        {
            if (gameData.key == null) //Checks for no game
            {
                PopupForm popup = new PopupForm("Please choose a game!");
                DialogResult dialogresult = popup.ShowDialog();
                popup.Dispose();
                return;
            }
            File.WriteAllText("credentials", gameData.key); //Stores the credentials somewhere butler can get to them
            foreach (Control cont in setupControls) //Locks off all controls to prevent in build change.
            {
                cont.Enabled = false;
            }
            Progress.Step = 100 / NoOfBuilds; //Calcs fallback progress step, used for if logging fails.
            Progress.Value = 0; //Resets data
            BuildsCompleted = 0;
            threadProgress.Clear();
            BuildsDone.Text = BuildsCompleted + " / " + NoOfBuilds;
            ProgressPercent.Text = Progress.Value.ToString() + " %";
            for (int i = 0; i < NoOfBuilds; i++) //For each builkd
            {
                cmd = " --assume-yes -i credentials push " + buildFolders[i].Text + " " + gameData.username + "/" + gameData.url.Split('/')[3]  + ":" + channelData[i].formalName;
                if (customVersions[i].Text != "") cmd += " --userversion " + customVersions[i].Text;
                Console.WriteLine(cmd); //Above constructs the arguments to be sent to butler, and logs it for people to see
                Thread butlerThread = new Thread(() => builderThread(cmd, i)); //Start a new thread for butler
                butlerThread.IsBackground = true; //Make the console window not appear
                butlerThread.Start(); //BEGIN!!
            }
            
        }
        void builderThread(string command, int threadIdent) //The threads for butler
        {
            using (Process butler = new Process()) //Starts up a butler thread
            {
                butler.StartInfo.FileName = "butler";
                butler.StartInfo.Arguments = command;
                butler.StartInfo.UseShellExecute = false;
                butler.StartInfo.RedirectStandardOutput = true;
                butler.StartInfo.StandardOutputEncoding = Encoding.UTF8;
                butler.StartInfo.CreateNoWindow = true;
                butler.OutputDataReceived += new DataReceivedEventHandler((sender, e) =>
                {
                    Trace.WriteLine(e.Data); //Stores data for trace debugging
                    if (e.Data != null)
                    {
                        try
                        {
                            if (e.Data.Contains(".")) // if there's dots in the line, there's probably a progress message. fire progress report.
                            {
                                progressReport(e.Data, threadIdent);
                            }
                        }
                        catch (System.NullReferenceException) //Avoids empty stuff, cus e.Data null catcher doesn't always work well
                        {
                            return;
                        }
                    }
                });
                butler.Start(); //Start the program, read the output, fire a function that only passes once it's done, but that's okay cus this is multi threaded, then close and kill the garbage collection, and increment.
                butler.BeginOutputReadLine();
                butler.WaitForExit();
                butler.Close();
                GC.KeepAlive(butler);
                incrementBuild();
            }
        }
        delegate void progressReportCallback(string data, int threadIdent);
        delegate void incrementBuildCallback();
        void incrementBuild() //Once one build is completed, update the UI. it used to be they would go one after the other, hence the naming of this.
        {
            if (this.BuildsDone.InvokeRequired)
            {
                incrementBuildCallback i = new incrementBuildCallback(incrementBuild);
                this.Invoke(i);
            }
            else
            {
                BuildsCompleted += 1;
                BuildsDone.Text = BuildsCompleted + " / " + NoOfBuilds;
                if (BuildsCompleted == NoOfBuilds) buildsComplete();
            }
        }
        void progressReport(string data, int threadIdent) //Called by standard output from any thread.
        {
            Console.WriteLine(data); //Log to the log files
            int value;
            if (this.Progress.InvokeRequired) //Not even quite sure what this done.
            {
                progressReportCallback i = new progressReportCallback(progressReport);
                this.Invoke(i, data, threadIdent); //Seems to be waiting for a progress bar animation to finish???
            }
            else
            {
                if (!threadProgress.ContainsKey(threadIdent)) //If there is no data, reset.
                {
                    threadProgress[threadIdent] = 0;
                    return;
                }
                if (threadProgress[threadIdent] == 100) return; //If 100 percent build complete will catch it.
                try
                {
                    value = int.Parse(data.Substring(data.IndexOf(".") - 3, 3).Trim()); //Finds the progress number in the line
                }
                catch (System.FormatException){ return; } //Gives up if there's any type of exception. Helps at start and end, and progress bar doesn't need to be this accurate.
                if (value > 100) return; //If this, we screwed up. Go back later.
                if (value != threadProgress[threadIdent]) //If new value compared to current known thread progress.
                {
                    int diff = value - threadProgress[threadIdent]; //Calc the differences
                    if (diff / NoOfBuilds < 1) return;
                    Progress.Step = diff / NoOfBuilds; //Step the progress bar by that difference divided by the number of builds, to make each build have an equal sway on the progress bar.
                    Progress.PerformStep();
                    ProgressPercent.Text = Progress.Value.ToString() + " %"; //Display progress exclusively by the bar
                }
                threadProgress[threadIdent] = value;
            }
            
        }
        void buildsComplete() //THis is when all builds complete.
        {
            Progress.Value = Progress.Maximum; //Update UI
            File.Delete("credentials"); //Purge credentials from system, those should only be in secure storage.
            PopupForm popup = new PopupForm("Project pushed succesfully!");
            DialogResult dialogresult = popup.ShowDialog();
            popup.Dispose();
            foreach (Control cont in setupControls) //Reenable all the controls.
            {
                cont.Enabled = true;
            }
            if (!quickPush && !DiscreteBuild.Checked)
            {
                if (PostDevlog.Checked) //Opens up the UI to add a new devlog. I don't know if this link is still accurate.
                {
                    ProcessStartInfo sInfo = new ProcessStartInfo("https://itch.io/dashboard/game/" + gameData.id + "/new-devlog");
                    Process.Start(sInfo);
                }
                if (trigData != null)
                {
                    string custArgs = trigData.args.Replace("{v1}", triggerVar1.Text).Replace("{v2}", triggerVar2.Text).Replace("{v3}", triggerVar3.Text);
                    Console.WriteLine(custArgs);
                    if (trigData.type.ToLower() == "program")
                    {
                        using (Process triggerProc = new Process()) //Opens program
                        {
                            triggerProc.StartInfo.FileName = trigData.link;
                            triggerProc.StartInfo.Arguments = custArgs;
                            triggerProc.StartInfo.UseShellExecute = false;
                            triggerProc.Start();
                        }
                    }
                    else
                    {
                        postRequest(trigData.link, Encoding.ASCII.GetBytes(custArgs)); //Post the link requested. I really should've allowed for multiple request types.
                        return;
                    }
                }
            }
            else
            {
				if (quickPushData.devlog)
				{
					ProcessStartInfo sInfo = new ProcessStartInfo("https://itch.io/dashboard/game/" + gameData.id + "/new-devlog");
					Process.Start(sInfo);
				}
				if (quickPushData.trigger != "")
				{
                    trigData = dataDicts.allTriggers[quickPushData.trigger];
                    string custArgs = trigData.args.Replace("{v1}", triggerVar1.Text).Replace("{v2}", triggerVar2.Text).Replace("{v3}", triggerVar3.Text);
					Console.WriteLine(custArgs);
					if (trigData.type.ToLower() == "program")
					{
						using (Process triggerProc = new Process())
						{
							triggerProc.StartInfo.FileName = trigData.link;
							triggerProc.StartInfo.Arguments = custArgs;
							triggerProc.StartInfo.UseShellExecute = false;
							triggerProc.Start();
						}
					}
					else
					{
						postRequest(trigData.link, Encoding.ASCII.GetBytes(custArgs));
						return;
					}
                    quickPushData.game = null; quickPushData.channel = null; quickPushData.folderPath = null; quickPushData.version = null; quickPushData.devlog = false;
                    quickPushData.trigger = null; quickPushData.v1 = null; quickPushData.v2 = null; quickPushData.v3 = null;
                }
            }
        }
        private void statUpdate_Tick(object sender, EventArgs e) //Just some nice info display. Useful for network particularly, but I had some whitespace in the UI so why on earth not.
        {
            //Gets values of addressed stats and stores them in floats
            float fcpu = pCPU.NextValue();
            float fram = pRAM.NextValue();
            float fsend = pSend.NextValue();
            //Formats values and displays
            lblCPU.Text = string.Format("{0:0.00}%", fcpu);
            lblRAM.Text = string.Format("{0:0.00}%", fram);
            lblSend.Text = string.Format("{0:0.00} B/s", fsend);
        }
        private void Build2Check_CheckedChanged(object sender, EventArgs e)
        {
            buildAmntChanged(0, Build2Check.Checked);
        }
        void buildAmntChanged(int buildNo, bool enabled) //Updates and enables UI for different buildCOntrols - does it need to declare buildControls each time? NO! Why does it? I DONT KNOW!!!
        {
            Control[] buildControls = new Control[] { BuildChannel2, BuildChannel3, BuildChannel4, BuildFolder2, BuildFolder3, BuildFolder4, buildFolderBrowser2, buildFolderBrowser3, buildFolderBrowser4, buildFileBrowser2, buildFileBrowser3, buildFileBrowser4, customVersion2, customVersion3, customVersion4 };
            if (enabled)
            {
                NoOfBuilds += 1;
                BuildsDone.Text = BuildsCompleted + " / " + NoOfBuilds;
                for (int i = buildNo; i < buildControls.Length; i += 3)
                {
                    buildControls[i].Enabled = true;
                }
            }
            else
            {
                NoOfBuilds -= 1;
                BuildsDone.Text = BuildsCompleted + " / " + NoOfBuilds;
                for (int i = buildNo; i < buildControls.Length; i += 3)
                {
                    buildControls[i].Enabled = false;
                }
            }
            
        }

        private void BrowseForBuildFolder2_Click(object sender, EventArgs e) //See below explanation of build folders.
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                BuildFolder2.Text = dialog.FileName;
            }
        }

        private void GameSelection_SelectedIndexChanged(object sender, EventArgs e) //When game changes
        {
            GameSelection2.SelectedItem = GameSelection.SelectedItem; //Update all channels game selections
            GameSelection3.SelectedItem = GameSelection.SelectedItem;
            GameSelection4.SelectedItem = GameSelection.SelectedItem;
            gameData = dataDicts.allGames[GameSelection.SelectedItem.ToString()];
            Account.Text = "To Account: " + gameData.username; //show the game data, including cover and platforms
            pushToGameTitle.Text = gameData.title;
            if (gameData.cover_url != null) gameBuildingPicture.LoadAsync(gameData.cover_url);
            else gameBuildingPicture.Image = gameBuildingPicture.InitialImage;
            
            if (gameData.p_windows) windowsSupport.Image = Properties.Resources.Windows_Logo__Coloured_;
            else windowsSupport.Image = Properties.Resources.Windows_Logo__Greyscale_;

            if (gameData.p_osx) osxSupport.Image = Properties.Resources.OSX_Logo__Coloured_;
            else osxSupport.Image = Properties.Resources.OSX_Logo__Greyscale_;
            
            if (gameData.p_linux) linuxSupport.Image = Properties.Resources.Linux_Logo__Coloured_;
            else linuxSupport.Image = Properties.Resources.Linux_Logo__Greyscale_;
            
            if (gameData.p_android) androidSupport.Image = Properties.Resources.Android_Logo__Coloured_;
            else androidSupport.Image = Properties.Resources.Android_Logo__Greyscale_;
        }

        private void BrowseForBuildFolder3_Click(object sender, EventArgs e) //Folder searchers for 3 and 4
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                BuildFolder3.Text = dialog.FileName;
            }
        }

        private void BrowseForBuildFolder4_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                BuildFolder4.Text = dialog.FileName;
            }
        }

        private void Build3Check_CheckedChanged(object sender, EventArgs e) //Updates the UI for amount of builds - two down to allow zero-based int, and also the top build is always on.
        {
            buildAmntChanged(1, Build3Check.Checked);
        }

        private void Build4Check_CheckedChanged(object sender, EventArgs e)
        {
            buildAmntChanged(2, Build4Check.Checked);
        }
        private void LaunchButler_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) //Just launches CMD for users to interface with butler
        {
            Process commandPrompt = new Process();
            commandPrompt.StartInfo.UseShellExecute = false;
            commandPrompt.StartInfo.FileName = "CMD.exe";
            commandPrompt.Start();
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var abt = new About();
            abt.Show(this);
        }

        private void itchioPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessStartInfo itch = new ProcessStartInfo("https://neoncoding.itch.io/build-master/");
            Process.Start(itch);
        }
        private void logOutOfAllAccountsToolStripMenuItem_Click(object sender, EventArgs e) //Clear the secure storage.
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
                isoStore.DeleteDirectory("BuildMaster");
            }
            PopupForm popup = new PopupForm("Logged out of all accounts.");
            DialogResult dialogresult = popup.ShowDialog();
            Reader.accountRead(null);
            Reader.gameRead(null, new ComboBox[] { GameSelection, GameSelection2, GameSelection3, GameSelection4 }); //Logging out of accounts will clear games so we'll need new data there too.
        }
        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e) //Open settings
        {
            var pref = new Form4();
            pref.FormClosed += Preferences_FormClosed;
            pref.Show(this);
        }
        private void Preferences_FormClosed(object sender, FormClosedEventArgs e) //Once settings closed, refresh all data.
        {
            Reader.accountRead(null);
            Reader.gameRead(null, new ComboBox[] { GameSelection, GameSelection2, GameSelection3, GameSelection4 });
            buildChannels = new ComboBox[] { BuildChannel, BuildChannel2, BuildChannel3, BuildChannel4 };
            Reader.channelRead(null, buildChannels);
            Reader.triggerRead(null, triggerSelector);
            Utilities.colourManager.colourDefinition(this, Properties.Settings.Default.BackColour, Properties.Settings.Default.ForeColour);
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(Environment.ExitCode); //Ensures all threads are closed when exit called.
        }
        private void saveSettingsFileToolStripMenuItem_Click(object sender, EventArgs e) 
        {
            //Generates a object with all of the configuration info
            configData currentConf = new configData(new bool[] { Build2Check.Checked, Build3Check.Checked, Build4Check.Checked }, DiscreteBuild.Checked, PostDevlog.Checked, GameSelection.Text, new string[] { BuildChannel.Text, BuildChannel2.Text, BuildChannel3.Text, BuildChannel4.Text }, new string[] { BuildFolder.Text, BuildFolder2.Text, BuildFolder3.Text, BuildFolder4.Text }, new string[] { customVersion.Text, customVersion2.Text, customVersion3.Text, customVersion4.Text}, triggerSelector.Text, new string[] { triggerVar1.Text, triggerVar2.Text, triggerVar3.Text});
            string cereal = JsonConvert.SerializeObject(currentConf); //serializes to JSON
            CommonSaveFileDialog dialog = new CommonSaveFileDialog(); //Saving dialog
            dialog.DefaultExtension = "json";
            dialog.DefaultFileName = "save.json";
            dialog.Filters.Add(new CommonFileDialogFilter("JSON", ".json"));
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                File.WriteAllText(dialog.FileName, cereal); //Once file found, save all to location
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(Environment.ExitCode); //Ensures everything is closed when the main window is.
        }

        private void quickPushToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuickPushTypeDialog checkType = new QuickPushTypeDialog(); //Quick push dialog - folder or file?
            DialogResult result = checkType.ShowDialog();
            CommonOpenFileDialog dialog = new CommonOpenFileDialog(); //Opens file dialog as needed.
            if (result == DialogResult.Yes) dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                qpm = new QuickPushMenu(dialog.FileName); //Opens quick push menu.
                qpm.FormClosed += QuickPushMenu_FormClosed;
                qpm.Show(this);
            }

        }
        private void QuickPushMenu_FormClosed(object sender, FormClosedEventArgs e) //Once quick push closed
        {
            if (quickPushData.game == null) return; //Ensure data is valid
            if (quickPushData.game == "") return;
            quickPush = true; //Block off other pushes
            gameData = dataDicts.allGames[quickPushData.game]; //Pull game data from storage
            Account.Text = "To Account: " + gameData.username; //Update UI for below
            pushToGameTitle.Text = gameData.title;
            if (gameData.cover_url != null) gameBuildingPicture.LoadAsync(gameData.cover_url);
            else gameBuildingPicture.Image = gameBuildingPicture.InitialImage;

            if (gameData.p_windows) windowsSupport.Image = Properties.Resources.Windows_Logo__Coloured_; //Below is the channel data being loaded
            else windowsSupport.Image = Properties.Resources.Windows_Logo__Greyscale_;

            if (gameData.p_osx) osxSupport.Image = Properties.Resources.OSX_Logo__Coloured_;
            else osxSupport.Image = Properties.Resources.OSX_Logo__Greyscale_;

            if (gameData.p_linux) linuxSupport.Image = Properties.Resources.Linux_Logo__Coloured_;
            else linuxSupport.Image = Properties.Resources.Linux_Logo__Greyscale_;

            if (gameData.p_android) androidSupport.Image = Properties.Resources.Android_Logo__Coloured_;
            else androidSupport.Image = Properties.Resources.Android_Logo__Greyscale_;
            File.WriteAllText("credentials", gameData.key); //Stores the credentials for butler to use temporarily.
            foreach (Control cont in setupControls) cont.Enabled = false; //Disable controls for the push
            NoOfBuilds = 1; //1 going up.
            Progress.Step = 100 / NoOfBuilds; //Setup the progress bar.
            Progress.Value = 0;
            BuildsCompleted = 0;
            threadProgress.Clear();
            BuildsDone.Text = BuildsCompleted + " / " + NoOfBuilds;
            ProgressPercent.Text = Progress.Value.ToString() + " %";
            cmd = " --assume-yes -i credentials push " + quickPushData.folderPath + " " + gameData.username + "/" + gameData.url.Split('/')[3] + ":" + quickPushData.channel; //the butler commnad to be used
            if (quickPushData.version != "") cmd += " --userversion " + quickPushData.version; //Version specified?
            Console.WriteLine(cmd); //Log this to the console, for the logging
            Thread butlerThread = new Thread(() => builderThread(cmd, 0)); //coonstruct a new thread
            butlerThread.IsBackground = true; 
            butlerThread.Start(); //start the thread.
        }

        private void buildFileBrowser_Click(object sender, EventArgs e) //Looks for and assigns file pushes in the 4 bars.
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                BuildFolder.Text = dialog.FileName;
            }
        }

        private void buildFileBrowser2_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                BuildFolder2.Text = dialog.FileName;
            }
        }

        private void buildFileBrowser3_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                BuildFolder3.Text = dialog.FileName;
            }
        }

        private void buildFileBrowser4_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                BuildFolder4.Text = dialog.FileName;
            }
        }

        private void BuildChannel_SelectedIndexChanged(object sender, EventArgs e) //Below is assigning channel data into memory.
        {
            channelData[0] = dataDicts.allChannels[BuildChannel.SelectedItem.ToString()];
        }

        private void BuildChannel2_SelectedIndexChanged(object sender, EventArgs e)
        {
            channelData[1] = dataDicts.allChannels[BuildChannel2.SelectedItem.ToString()];
        }

        private void BuildChannel3_SelectedIndexChanged(object sender, EventArgs e)
        {
            channelData[2] = dataDicts.allChannels[BuildChannel3.SelectedItem.ToString()];
        }

        private void BuildChannel4_SelectedIndexChanged(object sender, EventArgs e)
        {
            channelData[3] = dataDicts.allChannels[BuildChannel4.SelectedItem.ToString()];
        }

        private void loadSettingsFileToolStripMenuItem_Click(object sender, EventArgs e) //Load the saved settings from a JSON file.
        {
            
            CommonOpenFileDialog dialog = new CommonOpenFileDialog(); //File dialog with extension and data.
            dialog.DefaultExtension = "json";
            dialog.DefaultFileName = "save.json";
            dialog.Filters.Add(new CommonFileDialogFilter("JSON", ".json"));
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok) //Once closed
            {
                string cereal = File.ReadAllText(dialog.FileName); //Read all the things. if this errors? eh. Programmers are almost always going to be the ones using this,
                configData currentConf = JsonConvert.DeserializeObject<configData>(cereal); //so I don't feel super guilty about missing that one. Still an oversight.
                Build2Check.Checked = currentConf.buildsChecked[0];
                Build3Check.Checked = currentConf.buildsChecked[1];
                Build4Check.Checked = currentConf.buildsChecked[2];
                DiscreteBuild.Checked = currentConf.discreteBuild;
                PostDevlog.Checked = currentConf.postDevlog;
                GameSelection.SelectedIndex = GameSelection.FindStringExact(currentConf.gameSelected);
                BuildChannel.SelectedIndex = BuildChannel.FindStringExact(currentConf.channelSelected[0]);
                BuildChannel2.SelectedIndex = BuildChannel2.FindStringExact(currentConf.channelSelected[1]);
                BuildChannel3.SelectedIndex = BuildChannel3.FindStringExact(currentConf.channelSelected[2]);
                BuildChannel4.SelectedIndex = BuildChannel4.FindStringExact(currentConf.channelSelected[3]);
                BuildFolder.Text = currentConf.buildFolderPaths[0];
                BuildFolder2.Text = currentConf.buildFolderPaths[1];
                BuildFolder3.Text = currentConf.buildFolderPaths[2];
                BuildFolder4.Text = currentConf.buildFolderPaths[3];
                customVersion.Text = currentConf.customVersionStrings[0];
                customVersion2.Text = currentConf.customVersionStrings[1];
                customVersion3.Text = currentConf.customVersionStrings[2];
                customVersion4.Text = currentConf.customVersionStrings[3];
                triggerSelector.SelectedIndex = triggerSelector.FindStringExact(currentConf.triggerSelected);
                triggerVar1.Text = currentConf.trigVariables[0];
                triggerVar2.Text = currentConf.trigVariables[1];
                triggerVar3.Text = currentConf.trigVariables[2];
            }
        }

        private void viewConsoleToolStripMenuItem_Click(object sender, EventArgs e) //Load and show the console if needed.
        {
            var log = new Log();
            log.Show(this);
        }

        private void DiscreteBuild_CheckedChanged(object sender, EventArgs e) //Discrete builds turrn off all triggers and publication.
        {
            if (DiscreteBuild.Checked)
            {
                PostDevlog.Enabled = false;
                triggerSelector.Enabled = false;
                triggerVar1.Enabled = false;
                triggerVar2.Enabled = false;
                triggerVar3.Enabled = false;
            }
            else
            {
                PostDevlog.Enabled = true;
                triggerSelector.Enabled = true;
                if (trigData != null)
                {
                    if(trigData.args.Contains("{v1}")) triggerVar1.Enabled = true;
                    else triggerVar1.Enabled = false;
                    if (trigData.args.Contains("{v2}")) triggerVar2.Enabled = true;
                    else triggerVar2.Enabled = false;
                    if (trigData.args.Contains("{v3}")) triggerVar3.Enabled = true;
                    else triggerVar3.Enabled = false;
                }
                
            }
        }

        private void triggerSelector_SelectedIndexChanged(object sender, EventArgs e) //Trigger variable configuration - why is it set to exclusively these three and three in general? lockdown code.
        {
            trigData = dataDicts.allTriggers[triggerSelector.SelectedItem.ToString()];
            if (trigData.args.Contains("{v1}")) triggerVar1.Enabled = true;
            else triggerVar1.Enabled = false;
            if (trigData.args.Contains("{v2}")) triggerVar2.Enabled = true;
            else triggerVar2.Enabled = false;
            if (trigData.args.Contains("{v3}")) triggerVar3.Enabled = true;
            else triggerVar3.Enabled = false;
        }
        private HttpWebResponse postRequest(string uri, byte[] content) //Fairly basic POST for triggers.
        {
            HttpWebResponse response;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@uri);
                request.Method = "POST";
                request.ContentLength = content.Length;
                request.ContentType = "application/json";
                Stream dataStream = request.GetRequestStream();
                dataStream.Write(content, 0, content.Length);
                dataStream.Close();
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException ex)
            {
                using (var stream = ex.Response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    string error = reader.ReadToEnd();
                    PopupForm popup = new PopupForm("An unexpected error occured - This may be a bug.\nResponse: " + error);
                    Console.WriteLine("Error: " + error);
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
    public class configData //Data structure for saving and loading configuration data.
    {
        public bool[] buildsChecked;
        public bool discreteBuild;
        public bool postDevlog;
        public string gameSelected;
        public string[] channelSelected;
        public string[] buildFolderPaths;
        public string[] customVersionStrings;
        public string triggerSelected;
        public string[] trigVariables;
        public configData(bool[] buildsChecked, bool discreteBuild, bool postDevlog, string gameSelected, string[] channelSelected, string[] buildFolderPaths, string[] customVersionStrings, string triggerSelected, string[] trigVariables)
        {
            this.buildsChecked = buildsChecked;
            this.discreteBuild = discreteBuild;
            this.postDevlog = postDevlog;
            this.gameSelected = gameSelected;
            this.channelSelected = channelSelected;
            this.buildFolderPaths = buildFolderPaths;
            this.customVersionStrings = customVersionStrings;
            this.triggerSelected = triggerSelected;
            this.trigVariables = trigVariables;
        }
    }
    static class quickPushData //Storage for class data. Why isn't this JSON? Who knows.
    {
        public static string folderPath;
        public static string game;
        public static string channel;
        public static string version;
        public static string trigger;
        public static string v1;
        public static string v2;
        public static string v3;
        public static bool devlog;
    }
}
