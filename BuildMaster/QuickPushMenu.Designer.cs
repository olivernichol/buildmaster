
namespace BuildMaster
{
    partial class QuickPushMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuickPushMenu));
            this.gameLabel = new System.Windows.Forms.Label();
            this.gameSelector = new System.Windows.Forms.ComboBox();
            this.channelSelector = new System.Windows.Forms.ComboBox();
            this.channelLabel = new System.Windows.Forms.Label();
            this.verLabel = new System.Windows.Forms.Label();
            this.custVerInput = new System.Windows.Forms.TextBox();
            this.trigInput = new System.Windows.Forms.ComboBox();
            this.trigLabel = new System.Windows.Forms.Label();
            this.quickPushButton = new System.Windows.Forms.Button();
            this.v1Input = new System.Windows.Forms.TextBox();
            this.v2Input = new System.Windows.Forms.TextBox();
            this.v3Input = new System.Windows.Forms.TextBox();
            this.devlogCheck = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // gameLabel
            // 
            this.gameLabel.AutoSize = true;
            this.gameLabel.Font = new System.Drawing.Font("Roboto Lt", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameLabel.Location = new System.Drawing.Point(16, 13);
            this.gameLabel.Name = "gameLabel";
            this.gameLabel.Size = new System.Drawing.Size(42, 13);
            this.gameLabel.TabIndex = 0;
            this.gameLabel.Text = "Game: ";
            // 
            // gameSelector
            // 
            this.gameSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gameSelector.Font = new System.Drawing.Font("Roboto Lt", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameSelector.FormattingEnabled = true;
            this.gameSelector.Location = new System.Drawing.Point(64, 11);
            this.gameSelector.Name = "gameSelector";
            this.gameSelector.Size = new System.Drawing.Size(140, 21);
            this.gameSelector.TabIndex = 1;
            // 
            // channelSelector
            // 
            this.channelSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.channelSelector.Font = new System.Drawing.Font("Roboto Lt", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.channelSelector.FormattingEnabled = true;
            this.channelSelector.Location = new System.Drawing.Point(64, 37);
            this.channelSelector.Name = "channelSelector";
            this.channelSelector.Size = new System.Drawing.Size(140, 21);
            this.channelSelector.TabIndex = 2;
            // 
            // channelLabel
            // 
            this.channelLabel.AutoSize = true;
            this.channelLabel.Font = new System.Drawing.Font("Roboto Lt", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.channelLabel.Location = new System.Drawing.Point(8, 40);
            this.channelLabel.Name = "channelLabel";
            this.channelLabel.Size = new System.Drawing.Size(48, 13);
            this.channelLabel.TabIndex = 2;
            this.channelLabel.Text = "Channel:";
            // 
            // verLabel
            // 
            this.verLabel.AutoSize = true;
            this.verLabel.Font = new System.Drawing.Font("Roboto Lt", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.verLabel.Location = new System.Drawing.Point(8, 69);
            this.verLabel.Name = "verLabel";
            this.verLabel.Size = new System.Drawing.Size(49, 13);
            this.verLabel.TabIndex = 4;
            this.verLabel.Text = "Version: ";
            // 
            // custVerInput
            // 
            this.custVerInput.Font = new System.Drawing.Font("Roboto Lt", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.custVerInput.Location = new System.Drawing.Point(64, 66);
            this.custVerInput.Name = "custVerInput";
            this.custVerInput.Size = new System.Drawing.Size(140, 21);
            this.custVerInput.TabIndex = 3;
            // 
            // trigInput
            // 
            this.trigInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.trigInput.Font = new System.Drawing.Font("Roboto Lt", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trigInput.FormattingEnabled = true;
            this.trigInput.Location = new System.Drawing.Point(64, 95);
            this.trigInput.Name = "trigInput";
            this.trigInput.Size = new System.Drawing.Size(140, 21);
            this.trigInput.TabIndex = 4;
            // 
            // trigLabel
            // 
            this.trigLabel.AutoSize = true;
            this.trigLabel.Font = new System.Drawing.Font("Roboto Lt", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trigLabel.Location = new System.Drawing.Point(8, 98);
            this.trigLabel.Name = "trigLabel";
            this.trigLabel.Size = new System.Drawing.Size(44, 13);
            this.trigLabel.TabIndex = 6;
            this.trigLabel.Text = "Trigger:";
            // 
            // quickPushButton
            // 
            this.quickPushButton.Font = new System.Drawing.Font("Roboto Lt", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quickPushButton.Location = new System.Drawing.Point(-1, 176);
            this.quickPushButton.Name = "quickPushButton";
            this.quickPushButton.Size = new System.Drawing.Size(216, 36);
            this.quickPushButton.TabIndex = 9;
            this.quickPushButton.Text = "Push";
            this.quickPushButton.UseVisualStyleBackColor = true;
            this.quickPushButton.Click += new System.EventHandler(this.quickPushButton_Click);
            // 
            // v1Input
            // 
            this.v1Input.Font = new System.Drawing.Font("Roboto Lt", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.v1Input.Location = new System.Drawing.Point(11, 122);
            this.v1Input.Name = "v1Input";
            this.v1Input.Size = new System.Drawing.Size(70, 21);
            this.v1Input.TabIndex = 5;
            this.v1Input.Text = "{v1}";
            // 
            // v2Input
            // 
            this.v2Input.Font = new System.Drawing.Font("Roboto Lt", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.v2Input.Location = new System.Drawing.Point(87, 122);
            this.v2Input.Name = "v2Input";
            this.v2Input.Size = new System.Drawing.Size(70, 21);
            this.v2Input.TabIndex = 6;
            this.v2Input.Text = "{v2}";
            // 
            // v3Input
            // 
            this.v3Input.Font = new System.Drawing.Font("Roboto Lt", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.v3Input.Location = new System.Drawing.Point(11, 150);
            this.v3Input.Name = "v3Input";
            this.v3Input.Size = new System.Drawing.Size(70, 21);
            this.v3Input.TabIndex = 7;
            this.v3Input.Text = "{v3}";
            // 
            // devlogCheck
            // 
            this.devlogCheck.AutoSize = true;
            this.devlogCheck.Font = new System.Drawing.Font("Roboto Lt", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.devlogCheck.Location = new System.Drawing.Point(88, 152);
            this.devlogCheck.Name = "devlogCheck";
            this.devlogCheck.Size = new System.Drawing.Size(63, 17);
            this.devlogCheck.TabIndex = 8;
            this.devlogCheck.Text = "Devlog?";
            this.devlogCheck.UseVisualStyleBackColor = true;
            // 
            // QuickPushMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(213, 211);
            this.Controls.Add(this.devlogCheck);
            this.Controls.Add(this.v3Input);
            this.Controls.Add(this.v2Input);
            this.Controls.Add(this.v1Input);
            this.Controls.Add(this.quickPushButton);
            this.Controls.Add(this.trigInput);
            this.Controls.Add(this.trigLabel);
            this.Controls.Add(this.custVerInput);
            this.Controls.Add(this.verLabel);
            this.Controls.Add(this.channelSelector);
            this.Controls.Add(this.channelLabel);
            this.Controls.Add(this.gameSelector);
            this.Controls.Add(this.gameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QuickPushMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quick Push";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label gameLabel;
        private System.Windows.Forms.ComboBox gameSelector;
        private System.Windows.Forms.ComboBox channelSelector;
        private System.Windows.Forms.Label channelLabel;
        private System.Windows.Forms.Label verLabel;
        private System.Windows.Forms.TextBox custVerInput;
        private System.Windows.Forms.ComboBox trigInput;
        private System.Windows.Forms.Label trigLabel;
        private System.Windows.Forms.Button quickPushButton;
        private System.Windows.Forms.TextBox v1Input;
        private System.Windows.Forms.TextBox v2Input;
        private System.Windows.Forms.TextBox v3Input;
        private System.Windows.Forms.CheckBox devlogCheck;
    }
}