namespace BuildMaster
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.BuildChannel = new System.Windows.Forms.ComboBox();
            this.DiscreteBuild = new System.Windows.Forms.CheckBox();
            this.PostDevlog = new System.Windows.Forms.CheckBox();
            this.Account = new System.Windows.Forms.Label();
            this.NetworkUsageTitle = new System.Windows.Forms.Label();
            this.CPUUsageTitle = new System.Windows.Forms.Label();
            this.RAMUsageTitle = new System.Windows.Forms.Label();
            this.BuildButton = new System.Windows.Forms.Button();
            this.BuildFolder = new System.Windows.Forms.TextBox();
            this.buildFolderBrowser = new System.Windows.Forms.Button();
            this.statUpdate = new System.Windows.Forms.Timer(this.components);
            this.pCPU = new System.Diagnostics.PerformanceCounter();
            this.pRAM = new System.Diagnostics.PerformanceCounter();
            this.lblCPU = new System.Windows.Forms.Label();
            this.lblRAM = new System.Windows.Forms.Label();
            this.pSend = new System.Diagnostics.PerformanceCounter();
            this.lblSend = new System.Windows.Forms.Label();
            this.GameSelection = new System.Windows.Forms.ComboBox();
            this.Devlog = new System.Diagnostics.Process();
            this.Build2Check = new System.Windows.Forms.CheckBox();
            this.GameSelection2 = new System.Windows.Forms.ComboBox();
            this.BuildChannel2 = new System.Windows.Forms.ComboBox();
            this.BuildFolder2 = new System.Windows.Forms.TextBox();
            this.buildFolderBrowser2 = new System.Windows.Forms.Button();
            this.buildFolderBrowser3 = new System.Windows.Forms.Button();
            this.BuildFolder3 = new System.Windows.Forms.TextBox();
            this.BuildChannel3 = new System.Windows.Forms.ComboBox();
            this.GameSelection3 = new System.Windows.Forms.ComboBox();
            this.Build3Check = new System.Windows.Forms.CheckBox();
            this.buildFolderBrowser4 = new System.Windows.Forms.Button();
            this.BuildFolder4 = new System.Windows.Forms.TextBox();
            this.BuildChannel4 = new System.Windows.Forms.ComboBox();
            this.GameSelection4 = new System.Windows.Forms.ComboBox();
            this.Build4Check = new System.Windows.Forms.CheckBox();
            this.Progress = new System.Windows.Forms.ProgressBar();
            this.ProgressPercent = new System.Windows.Forms.Label();
            this.BuildsDone = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quickPushToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSettingsFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadSettingsFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutOfAllAccountsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewConsoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.itchioPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildFileBrowser = new System.Windows.Forms.Button();
            this.buildFileBrowser2 = new System.Windows.Forms.Button();
            this.buildFileBrowser3 = new System.Windows.Forms.Button();
            this.buildFileBrowser4 = new System.Windows.Forms.Button();
            this.gameBuildingPicture = new System.Windows.Forms.PictureBox();
            this.pushSubtitle = new System.Windows.Forms.Label();
            this.pushToGameTitle = new System.Windows.Forms.Label();
            this.versionInfoLabel = new System.Windows.Forms.Label();
            this.customVersion = new System.Windows.Forms.TextBox();
            this.customVersion4 = new System.Windows.Forms.TextBox();
            this.customVersion3 = new System.Windows.Forms.TextBox();
            this.customVersion2 = new System.Windows.Forms.TextBox();
            this.windowsSupport = new System.Windows.Forms.PictureBox();
            this.osxSupport = new System.Windows.Forms.PictureBox();
            this.linuxSupport = new System.Windows.Forms.PictureBox();
            this.androidSupport = new System.Windows.Forms.PictureBox();
            this.triggerSelectorLabel = new System.Windows.Forms.Label();
            this.triggerSelector = new System.Windows.Forms.ComboBox();
            this.triggerVar1 = new System.Windows.Forms.TextBox();
            this.triggerVar2 = new System.Windows.Forms.TextBox();
            this.triggerVar3 = new System.Windows.Forms.TextBox();
            this.buildShortcut = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pCPU)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pRAM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pSend)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gameBuildingPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.windowsSupport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.osxSupport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linuxSupport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.androidSupport)).BeginInit();
            this.SuspendLayout();
            // 
            // BuildChannel
            // 
            this.BuildChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BuildChannel.Font = new System.Drawing.Font("Roboto Lt", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BuildChannel.FormattingEnabled = true;
            this.BuildChannel.Location = new System.Drawing.Point(166, 27);
            this.BuildChannel.Name = "BuildChannel";
            this.BuildChannel.Size = new System.Drawing.Size(74, 21);
            this.BuildChannel.TabIndex = 2;
            this.BuildChannel.SelectedIndexChanged += new System.EventHandler(this.BuildChannel_SelectedIndexChanged);
            // 
            // DiscreteBuild
            // 
            this.DiscreteBuild.AutoSize = true;
            this.DiscreteBuild.Font = new System.Drawing.Font("Roboto Lt", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DiscreteBuild.Location = new System.Drawing.Point(10, 138);
            this.DiscreteBuild.Name = "DiscreteBuild";
            this.DiscreteBuild.Size = new System.Drawing.Size(140, 17);
            this.DiscreteBuild.TabIndex = 28;
            this.DiscreteBuild.Text = "Discrete? (No Triggers)";
            this.DiscreteBuild.UseVisualStyleBackColor = true;
            this.DiscreteBuild.CheckedChanged += new System.EventHandler(this.DiscreteBuild_CheckedChanged);
            // 
            // PostDevlog
            // 
            this.PostDevlog.AutoSize = true;
            this.PostDevlog.CausesValidation = false;
            this.PostDevlog.Font = new System.Drawing.Font("Roboto Lt", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PostDevlog.Location = new System.Drawing.Point(151, 138);
            this.PostDevlog.Name = "PostDevlog";
            this.PostDevlog.Size = new System.Drawing.Size(89, 17);
            this.PostDevlog.TabIndex = 29;
            this.PostDevlog.Text = "Post Devlog?";
            this.PostDevlog.UseVisualStyleBackColor = true;
            // 
            // Account
            // 
            this.Account.AutoSize = true;
            this.Account.Font = new System.Drawing.Font("Roboto Lt", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Account.Location = new System.Drawing.Point(108, 236);
            this.Account.Name = "Account";
            this.Account.Size = new System.Drawing.Size(151, 15);
            this.Account.TabIndex = 5;
            this.Account.Text = "To Account: One of them.";
            // 
            // NetworkUsageTitle
            // 
            this.NetworkUsageTitle.AutoSize = true;
            this.NetworkUsageTitle.Font = new System.Drawing.Font("Roboto Lt", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NetworkUsageTitle.Location = new System.Drawing.Point(388, 218);
            this.NetworkUsageTitle.Name = "NetworkUsageTitle";
            this.NetworkUsageTitle.Size = new System.Drawing.Size(84, 13);
            this.NetworkUsageTitle.TabIndex = 7;
            this.NetworkUsageTitle.Text = "Network Usage:";
            // 
            // CPUUsageTitle
            // 
            this.CPUUsageTitle.AutoSize = true;
            this.CPUUsageTitle.Font = new System.Drawing.Font("Roboto Lt", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CPUUsageTitle.Location = new System.Drawing.Point(408, 236);
            this.CPUUsageTitle.Name = "CPUUsageTitle";
            this.CPUUsageTitle.Size = new System.Drawing.Size(64, 13);
            this.CPUUsageTitle.TabIndex = 8;
            this.CPUUsageTitle.Text = "CPU Usage:";
            // 
            // RAMUsageTitle
            // 
            this.RAMUsageTitle.AutoSize = true;
            this.RAMUsageTitle.Font = new System.Drawing.Font("Roboto Lt", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RAMUsageTitle.Location = new System.Drawing.Point(407, 255);
            this.RAMUsageTitle.Name = "RAMUsageTitle";
            this.RAMUsageTitle.Size = new System.Drawing.Size(66, 13);
            this.RAMUsageTitle.TabIndex = 9;
            this.RAMUsageTitle.Text = "RAM Usage:";
            // 
            // BuildButton
            // 
            this.BuildButton.Font = new System.Drawing.Font("Roboto Lt", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BuildButton.Location = new System.Drawing.Point(674, 202);
            this.BuildButton.Name = "BuildButton";
            this.BuildButton.Size = new System.Drawing.Size(238, 76);
            this.BuildButton.TabIndex = 34;
            this.BuildButton.Text = "Push to butler!";
            this.BuildButton.UseVisualStyleBackColor = true;
            this.BuildButton.Click += new System.EventHandler(this.BuildButton_Click);
            // 
            // BuildFolder
            // 
            this.BuildFolder.Font = new System.Drawing.Font("Roboto Lt", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BuildFolder.Location = new System.Drawing.Point(246, 26);
            this.BuildFolder.Name = "BuildFolder";
            this.BuildFolder.Size = new System.Drawing.Size(390, 21);
            this.BuildFolder.TabIndex = 3;
            // 
            // buildFolderBrowser
            // 
            this.buildFolderBrowser.Font = new System.Drawing.Font("Roboto Lt", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buildFolderBrowser.Location = new System.Drawing.Point(642, 27);
            this.buildFolderBrowser.Name = "buildFolderBrowser";
            this.buildFolderBrowser.Size = new System.Drawing.Size(75, 23);
            this.buildFolderBrowser.TabIndex = 4;
            this.buildFolderBrowser.Text = "Folder";
            this.buildFolderBrowser.UseVisualStyleBackColor = true;
            this.buildFolderBrowser.Click += new System.EventHandler(this.BrowseForBuildFolder_Click);
            // 
            // statUpdate
            // 
            this.statUpdate.Enabled = true;
            this.statUpdate.Interval = 1000;
            this.statUpdate.Tick += new System.EventHandler(this.statUpdate_Tick);
            // 
            // pCPU
            // 
            this.pCPU.CategoryName = "Processor";
            this.pCPU.CounterName = "% Processor Time";
            this.pCPU.InstanceName = "_Total";
            // 
            // pRAM
            // 
            this.pRAM.CategoryName = "Memory";
            this.pRAM.CounterName = "% Committed Bytes In Use";
            // 
            // lblCPU
            // 
            this.lblCPU.AutoSize = true;
            this.lblCPU.Font = new System.Drawing.Font("Roboto Lt", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCPU.Location = new System.Drawing.Point(480, 236);
            this.lblCPU.Name = "lblCPU";
            this.lblCPU.Size = new System.Drawing.Size(24, 13);
            this.lblCPU.TabIndex = 15;
            this.lblCPU.Text = "0 %";
            // 
            // lblRAM
            // 
            this.lblRAM.AutoSize = true;
            this.lblRAM.Font = new System.Drawing.Font("Roboto Lt", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRAM.Location = new System.Drawing.Point(481, 255);
            this.lblRAM.Name = "lblRAM";
            this.lblRAM.Size = new System.Drawing.Size(24, 13);
            this.lblRAM.TabIndex = 16;
            this.lblRAM.Text = "0 %";
            // 
            // pSend
            // 
            this.pSend.CategoryName = "Network Interface";
            this.pSend.CounterName = "Bytes Sent/sec";
            this.pSend.InstanceName = "Rea";
            // 
            // lblSend
            // 
            this.lblSend.AutoSize = true;
            this.lblSend.Font = new System.Drawing.Font("Roboto Lt", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSend.Location = new System.Drawing.Point(480, 218);
            this.lblSend.Name = "lblSend";
            this.lblSend.Size = new System.Drawing.Size(33, 13);
            this.lblSend.TabIndex = 17;
            this.lblSend.Text = "0 B/s";
            // 
            // GameSelection
            // 
            this.GameSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GameSelection.Font = new System.Drawing.Font("Roboto Lt", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GameSelection.FormattingEnabled = true;
            this.GameSelection.Location = new System.Drawing.Point(30, 26);
            this.GameSelection.Name = "GameSelection";
            this.GameSelection.Size = new System.Drawing.Size(130, 21);
            this.GameSelection.TabIndex = 1;
            this.GameSelection.SelectedIndexChanged += new System.EventHandler(this.GameSelection_SelectedIndexChanged);
            // 
            // Devlog
            // 
            this.Devlog.StartInfo.CreateNoWindow = true;
            this.Devlog.StartInfo.Domain = "";
            this.Devlog.StartInfo.FileName = "C:\\Program Files\\BuildMaster\\Devlog.ahk";
            this.Devlog.StartInfo.LoadUserProfile = false;
            this.Devlog.StartInfo.Password = null;
            this.Devlog.StartInfo.StandardErrorEncoding = null;
            this.Devlog.StartInfo.StandardOutputEncoding = null;
            this.Devlog.StartInfo.UserName = "";
            this.Devlog.StartInfo.WorkingDirectory = "C:\\Program Files\\BuildMaster";
            this.Devlog.SynchronizingObject = this;
            // 
            // Build2Check
            // 
            this.Build2Check.AutoSize = true;
            this.Build2Check.Location = new System.Drawing.Point(9, 56);
            this.Build2Check.Name = "Build2Check";
            this.Build2Check.Size = new System.Drawing.Size(15, 14);
            this.Build2Check.TabIndex = 7;
            this.Build2Check.UseVisualStyleBackColor = true;
            this.Build2Check.CheckedChanged += new System.EventHandler(this.Build2Check_CheckedChanged);
            // 
            // GameSelection2
            // 
            this.GameSelection2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GameSelection2.Enabled = false;
            this.GameSelection2.Font = new System.Drawing.Font("Roboto Lt", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GameSelection2.FormattingEnabled = true;
            this.GameSelection2.Location = new System.Drawing.Point(30, 53);
            this.GameSelection2.Name = "GameSelection2";
            this.GameSelection2.Size = new System.Drawing.Size(130, 21);
            this.GameSelection2.TabIndex = 8;
            // 
            // BuildChannel2
            // 
            this.BuildChannel2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BuildChannel2.Enabled = false;
            this.BuildChannel2.Font = new System.Drawing.Font("Roboto Lt", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BuildChannel2.FormattingEnabled = true;
            this.BuildChannel2.Location = new System.Drawing.Point(166, 53);
            this.BuildChannel2.Name = "BuildChannel2";
            this.BuildChannel2.Size = new System.Drawing.Size(74, 21);
            this.BuildChannel2.TabIndex = 9;
            this.BuildChannel2.SelectedIndexChanged += new System.EventHandler(this.BuildChannel2_SelectedIndexChanged);
            // 
            // BuildFolder2
            // 
            this.BuildFolder2.Enabled = false;
            this.BuildFolder2.Font = new System.Drawing.Font("Roboto Lt", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BuildFolder2.Location = new System.Drawing.Point(246, 54);
            this.BuildFolder2.Name = "BuildFolder2";
            this.BuildFolder2.Size = new System.Drawing.Size(390, 21);
            this.BuildFolder2.TabIndex = 10;
            // 
            // buildFolderBrowser2
            // 
            this.buildFolderBrowser2.Enabled = false;
            this.buildFolderBrowser2.Font = new System.Drawing.Font("Roboto Lt", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buildFolderBrowser2.Location = new System.Drawing.Point(642, 52);
            this.buildFolderBrowser2.Name = "buildFolderBrowser2";
            this.buildFolderBrowser2.Size = new System.Drawing.Size(75, 23);
            this.buildFolderBrowser2.TabIndex = 11;
            this.buildFolderBrowser2.Text = "Folder";
            this.buildFolderBrowser2.UseVisualStyleBackColor = true;
            this.buildFolderBrowser2.Click += new System.EventHandler(this.BrowseForBuildFolder2_Click);
            // 
            // buildFolderBrowser3
            // 
            this.buildFolderBrowser3.Enabled = false;
            this.buildFolderBrowser3.Font = new System.Drawing.Font("Roboto Lt", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buildFolderBrowser3.Location = new System.Drawing.Point(642, 78);
            this.buildFolderBrowser3.Name = "buildFolderBrowser3";
            this.buildFolderBrowser3.Size = new System.Drawing.Size(75, 23);
            this.buildFolderBrowser3.TabIndex = 18;
            this.buildFolderBrowser3.Text = "Folder";
            this.buildFolderBrowser3.UseVisualStyleBackColor = true;
            this.buildFolderBrowser3.Click += new System.EventHandler(this.BrowseForBuildFolder3_Click);
            // 
            // BuildFolder3
            // 
            this.BuildFolder3.Enabled = false;
            this.BuildFolder3.Font = new System.Drawing.Font("Roboto Lt", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BuildFolder3.Location = new System.Drawing.Point(246, 80);
            this.BuildFolder3.Name = "BuildFolder3";
            this.BuildFolder3.Size = new System.Drawing.Size(390, 21);
            this.BuildFolder3.TabIndex = 17;
            // 
            // BuildChannel3
            // 
            this.BuildChannel3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BuildChannel3.Enabled = false;
            this.BuildChannel3.Font = new System.Drawing.Font("Roboto Lt", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BuildChannel3.FormattingEnabled = true;
            this.BuildChannel3.Location = new System.Drawing.Point(166, 79);
            this.BuildChannel3.Name = "BuildChannel3";
            this.BuildChannel3.Size = new System.Drawing.Size(74, 21);
            this.BuildChannel3.TabIndex = 16;
            this.BuildChannel3.SelectedIndexChanged += new System.EventHandler(this.BuildChannel3_SelectedIndexChanged);
            // 
            // GameSelection3
            // 
            this.GameSelection3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GameSelection3.Enabled = false;
            this.GameSelection3.Font = new System.Drawing.Font("Roboto Lt", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GameSelection3.FormattingEnabled = true;
            this.GameSelection3.Location = new System.Drawing.Point(30, 79);
            this.GameSelection3.Name = "GameSelection3";
            this.GameSelection3.Size = new System.Drawing.Size(130, 21);
            this.GameSelection3.TabIndex = 15;
            // 
            // Build3Check
            // 
            this.Build3Check.AutoSize = true;
            this.Build3Check.Location = new System.Drawing.Point(9, 82);
            this.Build3Check.Name = "Build3Check";
            this.Build3Check.Size = new System.Drawing.Size(15, 14);
            this.Build3Check.TabIndex = 14;
            this.Build3Check.UseVisualStyleBackColor = true;
            this.Build3Check.CheckedChanged += new System.EventHandler(this.Build3Check_CheckedChanged);
            // 
            // buildFolderBrowser4
            // 
            this.buildFolderBrowser4.Enabled = false;
            this.buildFolderBrowser4.Font = new System.Drawing.Font("Roboto Lt", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buildFolderBrowser4.Location = new System.Drawing.Point(642, 104);
            this.buildFolderBrowser4.Name = "buildFolderBrowser4";
            this.buildFolderBrowser4.Size = new System.Drawing.Size(75, 23);
            this.buildFolderBrowser4.TabIndex = 25;
            this.buildFolderBrowser4.Text = "Folder";
            this.buildFolderBrowser4.UseVisualStyleBackColor = true;
            this.buildFolderBrowser4.Click += new System.EventHandler(this.BrowseForBuildFolder4_Click);
            // 
            // BuildFolder4
            // 
            this.BuildFolder4.Enabled = false;
            this.BuildFolder4.Font = new System.Drawing.Font("Roboto Lt", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BuildFolder4.Location = new System.Drawing.Point(246, 106);
            this.BuildFolder4.Name = "BuildFolder4";
            this.BuildFolder4.Size = new System.Drawing.Size(390, 21);
            this.BuildFolder4.TabIndex = 24;
            // 
            // BuildChannel4
            // 
            this.BuildChannel4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BuildChannel4.Enabled = false;
            this.BuildChannel4.Font = new System.Drawing.Font("Roboto Lt", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BuildChannel4.FormattingEnabled = true;
            this.BuildChannel4.Location = new System.Drawing.Point(166, 105);
            this.BuildChannel4.Name = "BuildChannel4";
            this.BuildChannel4.Size = new System.Drawing.Size(74, 21);
            this.BuildChannel4.TabIndex = 23;
            this.BuildChannel4.SelectedIndexChanged += new System.EventHandler(this.BuildChannel4_SelectedIndexChanged);
            // 
            // GameSelection4
            // 
            this.GameSelection4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GameSelection4.Enabled = false;
            this.GameSelection4.Font = new System.Drawing.Font("Roboto Lt", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GameSelection4.FormattingEnabled = true;
            this.GameSelection4.Location = new System.Drawing.Point(30, 105);
            this.GameSelection4.Name = "GameSelection4";
            this.GameSelection4.Size = new System.Drawing.Size(130, 21);
            this.GameSelection4.TabIndex = 22;
            // 
            // Build4Check
            // 
            this.Build4Check.AutoSize = true;
            this.Build4Check.Location = new System.Drawing.Point(9, 108);
            this.Build4Check.Name = "Build4Check";
            this.Build4Check.Size = new System.Drawing.Size(15, 14);
            this.Build4Check.TabIndex = 21;
            this.Build4Check.UseVisualStyleBackColor = true;
            this.Build4Check.CheckedChanged += new System.EventHandler(this.Build4Check_CheckedChanged);
            // 
            // Progress
            // 
            this.Progress.Location = new System.Drawing.Point(20, 161);
            this.Progress.Name = "Progress";
            this.Progress.Size = new System.Drawing.Size(892, 23);
            this.Progress.Step = 1;
            this.Progress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.Progress.TabIndex = 35;
            // 
            // ProgressPercent
            // 
            this.ProgressPercent.AutoSize = true;
            this.ProgressPercent.Font = new System.Drawing.Font("Roboto Lt", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProgressPercent.Location = new System.Drawing.Point(413, 188);
            this.ProgressPercent.Name = "ProgressPercent";
            this.ProgressPercent.Size = new System.Drawing.Size(24, 13);
            this.ProgressPercent.TabIndex = 36;
            this.ProgressPercent.Text = "0 %";
            // 
            // BuildsDone
            // 
            this.BuildsDone.AutoSize = true;
            this.BuildsDone.Font = new System.Drawing.Font("Roboto Lt", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BuildsDone.Location = new System.Drawing.Point(443, 188);
            this.BuildsDone.Name = "BuildsDone";
            this.BuildsDone.Size = new System.Drawing.Size(29, 13);
            this.BuildsDone.TabIndex = 37;
            this.BuildsDone.Text = "0 / 1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Roboto Lt", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(924, 24);
            this.menuStrip1.TabIndex = 39;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quickPushToolStripMenuItem,
            this.saveSettingsFileToolStripMenuItem,
            this.loadSettingsFileToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // quickPushToolStripMenuItem
            // 
            this.quickPushToolStripMenuItem.Name = "quickPushToolStripMenuItem";
            this.quickPushToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.quickPushToolStripMenuItem.Text = "Quick Push (Ctrl + Q)";
            this.quickPushToolStripMenuItem.Click += new System.EventHandler(this.quickPushToolStripMenuItem_Click);
            // 
            // saveSettingsFileToolStripMenuItem
            // 
            this.saveSettingsFileToolStripMenuItem.Name = "saveSettingsFileToolStripMenuItem";
            this.saveSettingsFileToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.saveSettingsFileToolStripMenuItem.Text = "Save Config File (Ctrl + S)";
            this.saveSettingsFileToolStripMenuItem.Click += new System.EventHandler(this.saveSettingsFileToolStripMenuItem_Click);
            // 
            // loadSettingsFileToolStripMenuItem
            // 
            this.loadSettingsFileToolStripMenuItem.Name = "loadSettingsFileToolStripMenuItem";
            this.loadSettingsFileToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.loadSettingsFileToolStripMenuItem.Text = "Load Config File (Ctrl + O)";
            this.loadSettingsFileToolStripMenuItem.Click += new System.EventHandler(this.loadSettingsFileToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.exitToolStripMenuItem.Text = "Exit (Ctrl + X)";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.preferencesToolStripMenuItem,
            this.logOutOfAllAccountsToolStripMenuItem,
            this.viewConsoleToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.preferencesToolStripMenuItem.Text = "Preferences (Ctrl + P)";
            this.preferencesToolStripMenuItem.Click += new System.EventHandler(this.preferencesToolStripMenuItem_Click);
            // 
            // logOutOfAllAccountsToolStripMenuItem
            // 
            this.logOutOfAllAccountsToolStripMenuItem.Name = "logOutOfAllAccountsToolStripMenuItem";
            this.logOutOfAllAccountsToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.logOutOfAllAccountsToolStripMenuItem.Text = "Log Out of All Accounts";
            this.logOutOfAllAccountsToolStripMenuItem.Click += new System.EventHandler(this.logOutOfAllAccountsToolStripMenuItem_Click);
            // 
            // viewConsoleToolStripMenuItem
            // 
            this.viewConsoleToolStripMenuItem.Name = "viewConsoleToolStripMenuItem";
            this.viewConsoleToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.viewConsoleToolStripMenuItem.Text = "View Console (Ctrl + D)";
            this.viewConsoleToolStripMenuItem.Click += new System.EventHandler(this.viewConsoleToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem1,
            this.itchioPageToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(136, 22);
            this.aboutToolStripMenuItem1.Text = "About...";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // itchioPageToolStripMenuItem
            // 
            this.itchioPageToolStripMenuItem.Name = "itchioPageToolStripMenuItem";
            this.itchioPageToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.itchioPageToolStripMenuItem.Text = "itch.io Page";
            this.itchioPageToolStripMenuItem.Click += new System.EventHandler(this.itchioPageToolStripMenuItem_Click);
            // 
            // buildFileBrowser
            // 
            this.buildFileBrowser.Font = new System.Drawing.Font("Roboto Lt", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buildFileBrowser.Location = new System.Drawing.Point(723, 27);
            this.buildFileBrowser.Name = "buildFileBrowser";
            this.buildFileBrowser.Size = new System.Drawing.Size(75, 23);
            this.buildFileBrowser.TabIndex = 5;
            this.buildFileBrowser.Text = "File";
            this.buildFileBrowser.UseVisualStyleBackColor = true;
            this.buildFileBrowser.Click += new System.EventHandler(this.buildFileBrowser_Click);
            // 
            // buildFileBrowser2
            // 
            this.buildFileBrowser2.Enabled = false;
            this.buildFileBrowser2.Font = new System.Drawing.Font("Roboto Lt", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buildFileBrowser2.Location = new System.Drawing.Point(723, 54);
            this.buildFileBrowser2.Name = "buildFileBrowser2";
            this.buildFileBrowser2.Size = new System.Drawing.Size(75, 23);
            this.buildFileBrowser2.TabIndex = 12;
            this.buildFileBrowser2.Text = "File";
            this.buildFileBrowser2.UseVisualStyleBackColor = true;
            this.buildFileBrowser2.Click += new System.EventHandler(this.buildFileBrowser2_Click);
            // 
            // buildFileBrowser3
            // 
            this.buildFileBrowser3.Enabled = false;
            this.buildFileBrowser3.Font = new System.Drawing.Font("Roboto Lt", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buildFileBrowser3.Location = new System.Drawing.Point(723, 80);
            this.buildFileBrowser3.Name = "buildFileBrowser3";
            this.buildFileBrowser3.Size = new System.Drawing.Size(75, 23);
            this.buildFileBrowser3.TabIndex = 19;
            this.buildFileBrowser3.Text = "File";
            this.buildFileBrowser3.UseVisualStyleBackColor = true;
            this.buildFileBrowser3.Click += new System.EventHandler(this.buildFileBrowser3_Click);
            // 
            // buildFileBrowser4
            // 
            this.buildFileBrowser4.Enabled = false;
            this.buildFileBrowser4.Font = new System.Drawing.Font("Roboto Lt", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buildFileBrowser4.Location = new System.Drawing.Point(723, 105);
            this.buildFileBrowser4.Name = "buildFileBrowser4";
            this.buildFileBrowser4.Size = new System.Drawing.Size(75, 23);
            this.buildFileBrowser4.TabIndex = 26;
            this.buildFileBrowser4.Text = "File";
            this.buildFileBrowser4.UseVisualStyleBackColor = true;
            this.buildFileBrowser4.Click += new System.EventHandler(this.buildFileBrowser4_Click);
            // 
            // gameBuildingPicture
            // 
            this.gameBuildingPicture.ErrorImage = ((System.Drawing.Image)(resources.GetObject("gameBuildingPicture.ErrorImage")));
            this.gameBuildingPicture.InitialImage = ((System.Drawing.Image)(resources.GetObject("gameBuildingPicture.InitialImage")));
            this.gameBuildingPicture.Location = new System.Drawing.Point(20, 202);
            this.gameBuildingPicture.Name = "gameBuildingPicture";
            this.gameBuildingPicture.Size = new System.Drawing.Size(80, 80);
            this.gameBuildingPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.gameBuildingPicture.TabIndex = 44;
            this.gameBuildingPicture.TabStop = false;
            // 
            // pushSubtitle
            // 
            this.pushSubtitle.AutoSize = true;
            this.pushSubtitle.Font = new System.Drawing.Font("Roboto Lt", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pushSubtitle.Location = new System.Drawing.Point(115, 191);
            this.pushSubtitle.Name = "pushSubtitle";
            this.pushSubtitle.Size = new System.Drawing.Size(129, 13);
            this.pushSubtitle.TabIndex = 45;
            this.pushSubtitle.Text = "You are going to push to:";
            // 
            // pushToGameTitle
            // 
            this.pushToGameTitle.AutoSize = true;
            this.pushToGameTitle.Font = new System.Drawing.Font("Roboto Lt", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pushToGameTitle.Location = new System.Drawing.Point(106, 208);
            this.pushToGameTitle.Name = "pushToGameTitle";
            this.pushToGameTitle.Size = new System.Drawing.Size(198, 25);
            this.pushToGameTitle.TabIndex = 46;
            this.pushToGameTitle.Text = "No project selected!";
            // 
            // versionInfoLabel
            // 
            this.versionInfoLabel.AutoSize = true;
            this.versionInfoLabel.Font = new System.Drawing.Font("Roboto Lt", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.versionInfoLabel.Location = new System.Drawing.Point(789, 11);
            this.versionInfoLabel.Name = "versionInfoLabel";
            this.versionInfoLabel.Size = new System.Drawing.Size(135, 13);
            this.versionInfoLabel.TabIndex = 48;
            this.versionInfoLabel.Text = "Version (Blank for Default)";
            // 
            // customVersion
            // 
            this.customVersion.Font = new System.Drawing.Font("Roboto Lt", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customVersion.Location = new System.Drawing.Point(804, 30);
            this.customVersion.Name = "customVersion";
            this.customVersion.Size = new System.Drawing.Size(108, 21);
            this.customVersion.TabIndex = 6;
            // 
            // customVersion4
            // 
            this.customVersion4.Enabled = false;
            this.customVersion4.Font = new System.Drawing.Font("Roboto Lt", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customVersion4.Location = new System.Drawing.Point(804, 106);
            this.customVersion4.Name = "customVersion4";
            this.customVersion4.Size = new System.Drawing.Size(108, 21);
            this.customVersion4.TabIndex = 27;
            // 
            // customVersion3
            // 
            this.customVersion3.Enabled = false;
            this.customVersion3.Font = new System.Drawing.Font("Roboto Lt", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customVersion3.Location = new System.Drawing.Point(804, 82);
            this.customVersion3.Name = "customVersion3";
            this.customVersion3.Size = new System.Drawing.Size(108, 21);
            this.customVersion3.TabIndex = 20;
            // 
            // customVersion2
            // 
            this.customVersion2.Enabled = false;
            this.customVersion2.Font = new System.Drawing.Font("Roboto Lt", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customVersion2.Location = new System.Drawing.Point(804, 55);
            this.customVersion2.Name = "customVersion2";
            this.customVersion2.Size = new System.Drawing.Size(108, 21);
            this.customVersion2.TabIndex = 13;
            // 
            // windowsSupport
            // 
            this.windowsSupport.Image = ((System.Drawing.Image)(resources.GetObject("windowsSupport.Image")));
            this.windowsSupport.Location = new System.Drawing.Point(106, 254);
            this.windowsSupport.Name = "windowsSupport";
            this.windowsSupport.Size = new System.Drawing.Size(32, 32);
            this.windowsSupport.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.windowsSupport.TabIndex = 53;
            this.windowsSupport.TabStop = false;
            // 
            // osxSupport
            // 
            this.osxSupport.Image = ((System.Drawing.Image)(resources.GetObject("osxSupport.Image")));
            this.osxSupport.Location = new System.Drawing.Point(144, 255);
            this.osxSupport.Name = "osxSupport";
            this.osxSupport.Size = new System.Drawing.Size(32, 32);
            this.osxSupport.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.osxSupport.TabIndex = 54;
            this.osxSupport.TabStop = false;
            // 
            // linuxSupport
            // 
            this.linuxSupport.Image = ((System.Drawing.Image)(resources.GetObject("linuxSupport.Image")));
            this.linuxSupport.Location = new System.Drawing.Point(182, 255);
            this.linuxSupport.Name = "linuxSupport";
            this.linuxSupport.Size = new System.Drawing.Size(32, 32);
            this.linuxSupport.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.linuxSupport.TabIndex = 55;
            this.linuxSupport.TabStop = false;
            // 
            // androidSupport
            // 
            this.androidSupport.Image = ((System.Drawing.Image)(resources.GetObject("androidSupport.Image")));
            this.androidSupport.Location = new System.Drawing.Point(220, 255);
            this.androidSupport.Name = "androidSupport";
            this.androidSupport.Size = new System.Drawing.Size(32, 32);
            this.androidSupport.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.androidSupport.TabIndex = 56;
            this.androidSupport.TabStop = false;
            // 
            // triggerSelectorLabel
            // 
            this.triggerSelectorLabel.AutoSize = true;
            this.triggerSelectorLabel.Font = new System.Drawing.Font("Roboto Lt", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.triggerSelectorLabel.Location = new System.Drawing.Point(261, 138);
            this.triggerSelectorLabel.Name = "triggerSelectorLabel";
            this.triggerSelectorLabel.Size = new System.Drawing.Size(44, 13);
            this.triggerSelectorLabel.TabIndex = 57;
            this.triggerSelectorLabel.Text = "Trigger:";
            // 
            // triggerSelector
            // 
            this.triggerSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.triggerSelector.Font = new System.Drawing.Font("Roboto Lt", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.triggerSelector.FormattingEnabled = true;
            this.triggerSelector.Location = new System.Drawing.Point(310, 133);
            this.triggerSelector.Name = "triggerSelector";
            this.triggerSelector.Size = new System.Drawing.Size(121, 21);
            this.triggerSelector.TabIndex = 30;
            this.triggerSelector.SelectedIndexChanged += new System.EventHandler(this.triggerSelector_SelectedIndexChanged);
            // 
            // triggerVar1
            // 
            this.triggerVar1.Font = new System.Drawing.Font("Roboto Lt", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.triggerVar1.Location = new System.Drawing.Point(525, 134);
            this.triggerVar1.Name = "triggerVar1";
            this.triggerVar1.Size = new System.Drawing.Size(125, 21);
            this.triggerVar1.TabIndex = 31;
            this.triggerVar1.Text = "Variable1";
            // 
            // triggerVar2
            // 
            this.triggerVar2.Font = new System.Drawing.Font("Roboto Lt", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.triggerVar2.Location = new System.Drawing.Point(656, 135);
            this.triggerVar2.Name = "triggerVar2";
            this.triggerVar2.Size = new System.Drawing.Size(125, 21);
            this.triggerVar2.TabIndex = 32;
            this.triggerVar2.Text = "Variable2";
            // 
            // triggerVar3
            // 
            this.triggerVar3.Font = new System.Drawing.Font("Roboto Lt", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.triggerVar3.Location = new System.Drawing.Point(787, 135);
            this.triggerVar3.Name = "triggerVar3";
            this.triggerVar3.Size = new System.Drawing.Size(125, 21);
            this.triggerVar3.TabIndex = 33;
            this.triggerVar3.Text = "Variable3";
            // 
            // buildShortcut
            // 
            this.buildShortcut.AutoSize = true;
            this.buildShortcut.Font = new System.Drawing.Font("Roboto Lt", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buildShortcut.Location = new System.Drawing.Point(761, 281);
            this.buildShortcut.Name = "buildShortcut";
            this.buildShortcut.Size = new System.Drawing.Size(59, 11);
            this.buildShortcut.TabIndex = 62;
            this.buildShortcut.Text = "(Ctrl + B for ^)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(924, 291);
            this.Controls.Add(this.buildShortcut);
            this.Controls.Add(this.triggerVar3);
            this.Controls.Add(this.triggerVar2);
            this.Controls.Add(this.triggerVar1);
            this.Controls.Add(this.triggerSelector);
            this.Controls.Add(this.triggerSelectorLabel);
            this.Controls.Add(this.androidSupport);
            this.Controls.Add(this.linuxSupport);
            this.Controls.Add(this.osxSupport);
            this.Controls.Add(this.windowsSupport);
            this.Controls.Add(this.customVersion2);
            this.Controls.Add(this.customVersion3);
            this.Controls.Add(this.customVersion4);
            this.Controls.Add(this.customVersion);
            this.Controls.Add(this.versionInfoLabel);
            this.Controls.Add(this.pushToGameTitle);
            this.Controls.Add(this.pushSubtitle);
            this.Controls.Add(this.gameBuildingPicture);
            this.Controls.Add(this.buildFileBrowser4);
            this.Controls.Add(this.buildFileBrowser3);
            this.Controls.Add(this.buildFileBrowser2);
            this.Controls.Add(this.buildFileBrowser);
            this.Controls.Add(this.BuildsDone);
            this.Controls.Add(this.ProgressPercent);
            this.Controls.Add(this.Progress);
            this.Controls.Add(this.buildFolderBrowser4);
            this.Controls.Add(this.BuildFolder4);
            this.Controls.Add(this.BuildChannel4);
            this.Controls.Add(this.GameSelection4);
            this.Controls.Add(this.Build4Check);
            this.Controls.Add(this.buildFolderBrowser3);
            this.Controls.Add(this.BuildFolder3);
            this.Controls.Add(this.BuildChannel3);
            this.Controls.Add(this.GameSelection3);
            this.Controls.Add(this.Build3Check);
            this.Controls.Add(this.buildFolderBrowser2);
            this.Controls.Add(this.BuildFolder2);
            this.Controls.Add(this.BuildChannel2);
            this.Controls.Add(this.GameSelection2);
            this.Controls.Add(this.Build2Check);
            this.Controls.Add(this.GameSelection);
            this.Controls.Add(this.lblSend);
            this.Controls.Add(this.lblRAM);
            this.Controls.Add(this.lblCPU);
            this.Controls.Add(this.buildFolderBrowser);
            this.Controls.Add(this.BuildFolder);
            this.Controls.Add(this.BuildButton);
            this.Controls.Add(this.RAMUsageTitle);
            this.Controls.Add(this.CPUUsageTitle);
            this.Controls.Add(this.NetworkUsageTitle);
            this.Controls.Add(this.Account);
            this.Controls.Add(this.PostDevlog);
            this.Controls.Add(this.DiscreteBuild);
            this.Controls.Add(this.BuildChannel);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BuildMaster";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pCPU)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pRAM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pSend)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gameBuildingPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.windowsSupport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.osxSupport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linuxSupport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.androidSupport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox BuildChannel;
        private System.Windows.Forms.CheckBox DiscreteBuild;
        private System.Windows.Forms.CheckBox PostDevlog;
        private System.Windows.Forms.Label Account;
        private System.Windows.Forms.Label NetworkUsageTitle;
        private System.Windows.Forms.Label CPUUsageTitle;
        private System.Windows.Forms.Label RAMUsageTitle;
        private System.Windows.Forms.Button BuildButton;
        private System.Windows.Forms.TextBox BuildFolder;
        private System.Windows.Forms.Button buildFolderBrowser;
        private System.Windows.Forms.Timer statUpdate;
        private System.Diagnostics.PerformanceCounter pCPU;
        private System.Diagnostics.PerformanceCounter pRAM;
        private System.Windows.Forms.Label lblCPU;
        private System.Windows.Forms.Label lblRAM;
        private System.Diagnostics.PerformanceCounter pSend;
        private System.Windows.Forms.Label lblSend;
        private System.Windows.Forms.ComboBox GameSelection;
        private System.Diagnostics.Process Devlog;
        private System.Windows.Forms.Button buildFolderBrowser2;
        private System.Windows.Forms.TextBox BuildFolder2;
        private System.Windows.Forms.ComboBox BuildChannel2;
        private System.Windows.Forms.ComboBox GameSelection2;
        private System.Windows.Forms.CheckBox Build2Check;
        private System.Windows.Forms.Button buildFolderBrowser3;
        private System.Windows.Forms.TextBox BuildFolder3;
        private System.Windows.Forms.ComboBox BuildChannel3;
        private System.Windows.Forms.ComboBox GameSelection3;
        private System.Windows.Forms.CheckBox Build3Check;
        private System.Windows.Forms.Button buildFolderBrowser4;
        private System.Windows.Forms.TextBox BuildFolder4;
        private System.Windows.Forms.ComboBox BuildChannel4;
        private System.Windows.Forms.ComboBox GameSelection4;
        private System.Windows.Forms.CheckBox Build4Check;
        private System.Windows.Forms.ProgressBar Progress;
        private System.Windows.Forms.Label ProgressPercent;
        private System.Windows.Forms.Label BuildsDone;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quickPushToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveSettingsFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadSettingsFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutOfAllAccountsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem itchioPageToolStripMenuItem;
        private System.Windows.Forms.Button buildFileBrowser4;
        private System.Windows.Forms.Button buildFileBrowser3;
        private System.Windows.Forms.Button buildFileBrowser2;
        private System.Windows.Forms.Button buildFileBrowser;
        private System.Windows.Forms.PictureBox gameBuildingPicture;
        private System.Windows.Forms.Label pushToGameTitle;
        private System.Windows.Forms.Label pushSubtitle;
        private System.Windows.Forms.Label versionInfoLabel;
        private System.Windows.Forms.TextBox customVersion2;
        private System.Windows.Forms.TextBox customVersion3;
        private System.Windows.Forms.TextBox customVersion4;
        private System.Windows.Forms.TextBox customVersion;
        private System.Windows.Forms.PictureBox androidSupport;
        private System.Windows.Forms.PictureBox linuxSupport;
        private System.Windows.Forms.PictureBox osxSupport;
        private System.Windows.Forms.PictureBox windowsSupport;
        private System.Windows.Forms.ToolStripMenuItem viewConsoleToolStripMenuItem;
        private System.Windows.Forms.ComboBox triggerSelector;
        private System.Windows.Forms.Label triggerSelectorLabel;
        private System.Windows.Forms.TextBox triggerVar3;
        private System.Windows.Forms.TextBox triggerVar2;
        private System.Windows.Forms.TextBox triggerVar1;
        private System.Windows.Forms.Label buildShortcut;
    }
}

