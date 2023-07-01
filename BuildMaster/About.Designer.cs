namespace BuildMaster
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.Title = new System.Windows.Forms.Label();
            this.logoPic = new System.Windows.Forms.PictureBox();
            this.versionAndDevLabel = new System.Windows.Forms.Label();
            this.butlerExplan = new System.Windows.Forms.Label();
            this.licenseLink = new System.Windows.Forms.LinkLabel();
            this.thankYou = new System.Windows.Forms.Label();
            this.sourceLink = new System.Windows.Forms.LinkLabel();
            this.webLabel = new System.Windows.Forms.LinkLabel();
            this.twitchLabel = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.logoPic)).BeginInit();
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Roboto Lt", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.Location = new System.Drawing.Point(33, 13);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(124, 25);
            this.Title.TabIndex = 0;
            this.Title.Text = "BuildMaster";
            // 
            // logoPic
            // 
            this.logoPic.Image = ((System.Drawing.Image)(resources.GetObject("logoPic.Image")));
            this.logoPic.Location = new System.Drawing.Point(5, 40);
            this.logoPic.Name = "logoPic";
            this.logoPic.Size = new System.Drawing.Size(180, 175);
            this.logoPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoPic.TabIndex = 1;
            this.logoPic.TabStop = false;
            // 
            // versionAndDevLabel
            // 
            this.versionAndDevLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.versionAndDevLabel.AutoSize = true;
            this.versionAndDevLabel.Font = new System.Drawing.Font("Roboto Lt", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.versionAndDevLabel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.versionAndDevLabel.Location = new System.Drawing.Point(17, 218);
            this.versionAndDevLabel.Name = "versionAndDevLabel";
            this.versionAndDevLabel.Size = new System.Drawing.Size(156, 50);
            this.versionAndDevLabel.TabIndex = 2;
            this.versionAndDevLabel.Text = "V2.0\r\nBy NeonCoding";
            this.versionAndDevLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // butlerExplan
            // 
            this.butlerExplan.Font = new System.Drawing.Font("Roboto Lt", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butlerExplan.Location = new System.Drawing.Point(5, 404);
            this.butlerExplan.Name = "butlerExplan";
            this.butlerExplan.Size = new System.Drawing.Size(180, 48);
            this.butlerExplan.TabIndex = 3;
            this.butlerExplan.Text = "Butler, the itch.io automated build tool, is licensed under MIT. See License File" +
    ": ";
            // 
            // licenseLink
            // 
            this.licenseLink.AutoSize = true;
            this.licenseLink.Location = new System.Drawing.Point(66, 429);
            this.licenseLink.Name = "licenseLink";
            this.licenseLink.Size = new System.Drawing.Size(30, 13);
            this.licenseLink.TabIndex = 4;
            this.licenseLink.TabStop = true;
            this.licenseLink.Text = "Here";
            this.licenseLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.licenseLabel_LinkClicked);
            // 
            // thankYou
            // 
            this.thankYou.AutoSize = true;
            this.thankYou.Font = new System.Drawing.Font("Roboto Lt", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thankYou.Location = new System.Drawing.Point(16, 268);
            this.thankYou.Name = "thankYou";
            this.thankYou.Size = new System.Drawing.Size(162, 13);
            this.thankYou.TabIndex = 5;
            this.thankYou.Text = "Thank you for using the project!";
            // 
            // sourceLink
            // 
            this.sourceLink.AutoSize = true;
            this.sourceLink.Font = new System.Drawing.Font("Roboto Lt", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sourceLink.Location = new System.Drawing.Point(73, 291);
            this.sourceLink.Name = "sourceLink";
            this.sourceLink.Size = new System.Drawing.Size(44, 15);
            this.sourceLink.TabIndex = 6;
            this.sourceLink.TabStop = true;
            this.sourceLink.Text = "Github";
            this.sourceLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.sourceLink_LinkClicked);
            // 
            // webLabel
            // 
            this.webLabel.AutoSize = true;
            this.webLabel.Font = new System.Drawing.Font("Roboto Lt", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.webLabel.Location = new System.Drawing.Point(69, 320);
            this.webLabel.Name = "webLabel";
            this.webLabel.Size = new System.Drawing.Size(52, 21);
            this.webLabel.TabIndex = 7;
            this.webLabel.TabStop = true;
            this.webLabel.Text = "Website";
            this.webLabel.UseCompatibleTextRendering = true;
            this.webLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.webLabel_LinkClicked);
            // 
            // twitchLabel
            // 
            this.twitchLabel.AutoSize = true;
            this.twitchLabel.Font = new System.Drawing.Font("Roboto Lt", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.twitchLabel.Location = new System.Drawing.Point(72, 354);
            this.twitchLabel.Name = "twitchLabel";
            this.twitchLabel.Size = new System.Drawing.Size(46, 15);
            this.twitchLabel.TabIndex = 8;
            this.twitchLabel.TabStop = true;
            this.twitchLabel.Text = "Twitch";
            this.twitchLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.twitchLabel_LinkClicked);
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(190, 451);
            this.Controls.Add(this.twitchLabel);
            this.Controls.Add(this.webLabel);
            this.Controls.Add(this.sourceLink);
            this.Controls.Add(this.thankYou);
            this.Controls.Add(this.licenseLink);
            this.Controls.Add(this.butlerExplan);
            this.Controls.Add(this.versionAndDevLabel);
            this.Controls.Add(this.logoPic);
            this.Controls.Add(this.Title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "About";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            ((System.ComponentModel.ISupportInitialize)(this.logoPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.PictureBox logoPic;
        private System.Windows.Forms.Label versionAndDevLabel;
        private System.Windows.Forms.Label butlerExplan;
        private System.Windows.Forms.LinkLabel licenseLink;
        private System.Windows.Forms.Label thankYou;
        private System.Windows.Forms.LinkLabel sourceLink;
        private System.Windows.Forms.LinkLabel webLabel;
        private System.Windows.Forms.LinkLabel twitchLabel;
    }
}