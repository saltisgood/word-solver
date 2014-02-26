namespace WordSolver.Gui
{
    partial class AddDictMenu
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
            this.BtnOpenFile = new System.Windows.Forms.Button();
            this.BtnOpenFolder = new System.Windows.Forms.Button();
            this.BtnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnOpenFile
            // 
            this.BtnOpenFile.Location = new System.Drawing.Point(12, 12);
            this.BtnOpenFile.Name = "BtnOpenFile";
            this.BtnOpenFile.Size = new System.Drawing.Size(320, 60);
            this.BtnOpenFile.TabIndex = 0;
            this.BtnOpenFile.Text = "Open a single dictionary file";
            this.BtnOpenFile.UseVisualStyleBackColor = true;
            this.BtnOpenFile.Click += new System.EventHandler(this.openFileButtonClick);
            // 
            // BtnOpenFolder
            // 
            this.BtnOpenFolder.Location = new System.Drawing.Point(12, 84);
            this.BtnOpenFolder.Name = "BtnOpenFolder";
            this.BtnOpenFolder.Size = new System.Drawing.Size(320, 60);
            this.BtnOpenFolder.TabIndex = 1;
            this.BtnOpenFolder.Text = "Open a directory of dictionary files";
            this.BtnOpenFolder.UseVisualStyleBackColor = true;
            this.BtnOpenFolder.Click += new System.EventHandler(this.openFolderButtonClick);
            // 
            // BtnClose
            // 
            this.BtnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnClose.Location = new System.Drawing.Point(12, 158);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(320, 60);
            this.BtnClose.TabIndex = 2;
            this.BtnClose.Text = "Cancel";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // AddDictMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 230);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.BtnOpenFolder);
            this.Controls.Add(this.BtnOpenFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddDictMenu";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Choose how to add your dictionary file/s";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddDictMenu_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnOpenFile;
        private System.Windows.Forms.Button BtnOpenFolder;
        private System.Windows.Forms.Button BtnClose;
    }
}