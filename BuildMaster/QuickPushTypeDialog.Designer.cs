
namespace BuildMaster
{
    partial class QuickPushTypeDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuickPushTypeDialog));
            this.fileTypeQuery = new System.Windows.Forms.Label();
            this.choiceFolder = new System.Windows.Forms.Button();
            this.choiceFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // fileTypeQuery
            // 
            this.fileTypeQuery.AutoSize = true;
            this.fileTypeQuery.Font = new System.Drawing.Font("Roboto Lt", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileTypeQuery.Location = new System.Drawing.Point(31, 9);
            this.fileTypeQuery.Name = "fileTypeQuery";
            this.fileTypeQuery.Size = new System.Drawing.Size(222, 13);
            this.fileTypeQuery.TabIndex = 0;
            this.fileTypeQuery.Text = "Please select the object you will be pushing.";
            // 
            // choiceFolder
            // 
            this.choiceFolder.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.choiceFolder.Font = new System.Drawing.Font("Roboto Lt", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.choiceFolder.Location = new System.Drawing.Point(12, 48);
            this.choiceFolder.Name = "choiceFolder";
            this.choiceFolder.Size = new System.Drawing.Size(100, 46);
            this.choiceFolder.TabIndex = 1;
            this.choiceFolder.Text = "Folder";
            this.choiceFolder.UseVisualStyleBackColor = true;
            // 
            // choiceFile
            // 
            this.choiceFile.DialogResult = System.Windows.Forms.DialogResult.No;
            this.choiceFile.Font = new System.Drawing.Font("Roboto Lt", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.choiceFile.Location = new System.Drawing.Point(172, 48);
            this.choiceFile.Name = "choiceFile";
            this.choiceFile.Size = new System.Drawing.Size(100, 46);
            this.choiceFile.TabIndex = 2;
            this.choiceFile.Text = "File";
            this.choiceFile.UseVisualStyleBackColor = true;
            // 
            // QuickPushTypeDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 111);
            this.Controls.Add(this.choiceFile);
            this.Controls.Add(this.choiceFolder);
            this.Controls.Add(this.fileTypeQuery);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QuickPushTypeDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Type of Push?";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label fileTypeQuery;
        private System.Windows.Forms.Button choiceFolder;
        private System.Windows.Forms.Button choiceFile;
    }
}