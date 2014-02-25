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
            this.openFileButton = new System.Windows.Forms.Button();
            this.openFolderButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openFileButton
            // 
            this.openFileButton.Location = new System.Drawing.Point(12, 12);
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(320, 60);
            this.openFileButton.TabIndex = 0;
            this.openFileButton.Text = "Open a single dictionary file";
            this.openFileButton.UseVisualStyleBackColor = true;
            this.openFileButton.Click += new System.EventHandler(this.openFileButtonClick);
            // 
            // openFolderButton
            // 
            this.openFolderButton.Location = new System.Drawing.Point(12, 84);
            this.openFolderButton.Name = "openFolderButton";
            this.openFolderButton.Size = new System.Drawing.Size(320, 60);
            this.openFolderButton.TabIndex = 1;
            this.openFolderButton.Text = "Open a directory of dictionary files";
            this.openFolderButton.UseVisualStyleBackColor = true;
            this.openFolderButton.Click += new System.EventHandler(this.openFolderButtonClick);
            // 
            // CancelButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CloseButton.Location = new System.Drawing.Point(12, 158);
            this.CloseButton.Name = "CancelButton";
            this.CloseButton.Size = new System.Drawing.Size(320, 60);
            this.CloseButton.TabIndex = 2;
            this.CloseButton.Text = "Cancel";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // AddDictMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 230);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.openFolderButton);
            this.Controls.Add(this.openFileButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddDictMenu";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Choose how to add your dictionary file/s";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddDictMenu_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button openFileButton;
        private System.Windows.Forms.Button openFolderButton;
        private System.Windows.Forms.Button CloseButton;
    }
}