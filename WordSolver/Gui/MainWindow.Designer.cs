namespace WordSolver.Gui
{
    partial class MainWindow
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
            this.wordInput = new System.Windows.Forms.TextBox();
            this.checkWordButton = new System.Windows.Forms.Button();
            this.dictLoader = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dictionaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quickEnterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pb1 = new System.Windows.Forms.ProgressBar();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.findWordsButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dictStatusLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dictSizeLabel = new System.Windows.Forms.Label();
            this.dictSaver = new System.ComponentModel.BackgroundWorker();
            this.dictListBox = new System.Windows.Forms.ListBox();
            this.dictPopulateList = new System.ComponentModel.BackgroundWorker();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gameTypeCombo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // wordInput
            // 
            this.wordInput.Location = new System.Drawing.Point(9, 89);
            this.wordInput.Name = "wordInput";
            this.wordInput.Size = new System.Drawing.Size(171, 20);
            this.wordInput.TabIndex = 1;
            this.wordInput.TextChanged += new System.EventHandler(this.wordInput_TextChanged);
            // 
            // checkWordButton
            // 
            this.checkWordButton.Location = new System.Drawing.Point(51, 115);
            this.checkWordButton.Name = "checkWordButton";
            this.checkWordButton.Size = new System.Drawing.Size(75, 23);
            this.checkWordButton.TabIndex = 2;
            this.checkWordButton.Text = "Check";
            this.checkWordButton.UseVisualStyleBackColor = true;
            this.checkWordButton.Click += new System.EventHandler(this.checkWordClick);
            // 
            // dictLoader
            // 
            this.dictLoader.WorkerReportsProgress = true;
            this.dictLoader.WorkerSupportsCancellation = true;
            this.dictLoader.DoWork += new System.ComponentModel.DoWorkEventHandler(this.dictLoader_DoWork);
            this.dictLoader.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.dictLoader_ProgressChanged);
            this.dictLoader.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.dictLoader_RunWorkerCompleted);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.gridToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(799, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dictionaryToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // dictionaryToolStripMenuItem
            // 
            this.dictionaryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetToolStripMenuItem,
            this.addFileToolStripMenuItem,
            this.addFolderToolStripMenuItem});
            this.dictionaryToolStripMenuItem.Name = "dictionaryToolStripMenuItem";
            this.dictionaryToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.dictionaryToolStripMenuItem.Text = "Dictionary";
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.resetToolStripMenuItem.Text = "Reset";
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.resetToolStripMenuItem_Click);
            // 
            // addFileToolStripMenuItem
            // 
            this.addFileToolStripMenuItem.Name = "addFileToolStripMenuItem";
            this.addFileToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.addFileToolStripMenuItem.Text = "Add File";
            this.addFileToolStripMenuItem.Click += new System.EventHandler(this.addFileToolStripMenuItem_Click);
            // 
            // addFolderToolStripMenuItem
            // 
            this.addFolderToolStripMenuItem.Name = "addFolderToolStripMenuItem";
            this.addFolderToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.addFolderToolStripMenuItem.Text = "Add Folder";
            this.addFolderToolStripMenuItem.Click += new System.EventHandler(this.addFolderToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // gridToolStripMenuItem
            // 
            this.gridToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quickEnterToolStripMenuItem});
            this.gridToolStripMenuItem.Name = "gridToolStripMenuItem";
            this.gridToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.gridToolStripMenuItem.Text = "Grid";
            // 
            // quickEnterToolStripMenuItem
            // 
            this.quickEnterToolStripMenuItem.Name = "quickEnterToolStripMenuItem";
            this.quickEnterToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.quickEnterToolStripMenuItem.Text = "Quick Enter";
            this.quickEnterToolStripMenuItem.Click += new System.EventHandler(this.quickEnterToolStripMenuItem_Click);
            // 
            // pb1
            // 
            this.pb1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pb1.Location = new System.Drawing.Point(3, 391);
            this.pb1.Name = "pb1";
            this.pb1.Size = new System.Drawing.Size(758, 23);
            this.pb1.TabIndex = 4;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(799, 451);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(791, 425);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Word Finder";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // findWordsButton
            // 
            this.findWordsButton.Location = new System.Drawing.Point(74, 288);
            this.findWordsButton.Name = "findWordsButton";
            this.findWordsButton.Size = new System.Drawing.Size(75, 23);
            this.findWordsButton.TabIndex = 4;
            this.findWordsButton.Text = "Find Words";
            this.findWordsButton.UseVisualStyleBackColor = true;
            this.findWordsButton.Click += new System.EventHandler(this.findWordsClick);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Grid Size:";
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(537, 419);
            this.panel1.TabIndex = 2;
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "3 x 3",
            "4 x 4"});
            this.comboBox1.Location = new System.Drawing.Point(87, 48);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(152, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dictListBox);
            this.tabPage2.Controls.Add(this.dictStatusLabel);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.dictSizeLabel);
            this.tabPage2.Controls.Add(this.pb1);
            this.tabPage2.Controls.Add(this.wordInput);
            this.tabPage2.Controls.Add(this.checkWordButton);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(764, 417);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Dictionary Info";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dictStatusLabel
            // 
            this.dictStatusLabel.AutoSize = true;
            this.dictStatusLabel.Location = new System.Drawing.Point(7, 372);
            this.dictStatusLabel.Name = "dictStatusLabel";
            this.dictStatusLabel.Size = new System.Drawing.Size(43, 13);
            this.dictStatusLabel.TabIndex = 7;
            this.dictStatusLabel.Text = "Status: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Check For Word:";
            // 
            // dictSizeLabel
            // 
            this.dictSizeLabel.AutoSize = true;
            this.dictSizeLabel.Location = new System.Drawing.Point(6, 3);
            this.dictSizeLabel.Name = "dictSizeLabel";
            this.dictSizeLabel.Size = new System.Drawing.Size(80, 13);
            this.dictSizeLabel.TabIndex = 5;
            this.dictSizeLabel.Text = "Dictionary Size:";
            // 
            // dictSaver
            // 
            this.dictSaver.DoWork += new System.ComponentModel.DoWorkEventHandler(this.dictSaver_DoWork);
            this.dictSaver.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.dictSaver_RunWorkerCompleted);
            // 
            // dictListBox
            // 
            this.dictListBox.FormattingEnabled = true;
            this.dictListBox.Location = new System.Drawing.Point(11, 157);
            this.dictListBox.Name = "dictListBox";
            this.dictListBox.Size = new System.Drawing.Size(260, 212);
            this.dictListBox.TabIndex = 8;
            // 
            // dictPopulateList
            // 
            this.dictPopulateList.WorkerSupportsCancellation = true;
            this.dictPopulateList.DoWork += new System.ComponentModel.DoWorkEventHandler(this.dictPopulateList_DoWork);
            this.dictPopulateList.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.dictPopulateList_RunWorkerCompleted);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.gameTypeCombo);
            this.splitContainer1.Panel2.Controls.Add(this.findWordsButton);
            this.splitContainer1.Panel2.Controls.Add(this.comboBox1);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Size = new System.Drawing.Size(785, 419);
            this.splitContainer1.SplitterDistance = 537;
            this.splitContainer1.TabIndex = 5;
            // 
            // gameTypeCombo
            // 
            this.gameTypeCombo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gameTypeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gameTypeCombo.FormattingEnabled = true;
            this.gameTypeCombo.Items.AddRange(new object[] {
            "Grid",
            "Anagram"});
            this.gameTypeCombo.Location = new System.Drawing.Point(87, 11);
            this.gameTypeCombo.Name = "gameTypeCombo";
            this.gameTypeCombo.Size = new System.Drawing.Size(152, 21);
            this.gameTypeCombo.TabIndex = 5;
            this.gameTypeCombo.SelectedIndexChanged += new System.EventHandler(this.gameTypeCombo_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Problem Type:";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 475);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "Form1";
            this.Shown += new System.EventHandler(this.MainWindowShown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox wordInput;
        private System.Windows.Forms.Button checkWordButton;
        private System.ComponentModel.BackgroundWorker dictLoader;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dictionaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addFolderToolStripMenuItem;
        private System.Windows.Forms.ProgressBar pb1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label dictSizeLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button findWordsButton;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gridToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quickEnterToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker dictSaver;
        private System.Windows.Forms.Label dictStatusLabel;
        private System.Windows.Forms.ListBox dictListBox;
        private System.ComponentModel.BackgroundWorker dictPopulateList;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox gameTypeCombo;
    }
}

