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
            this.components = new System.ComponentModel.Container();
            this.TextBoxDictionarySearch = new System.Windows.Forms.TextBox();
            this.BtnAddWord = new System.Windows.Forms.Button();
            this.dictLoader = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MenuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemDictionary = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemReset = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemAddFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemAddFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemSave = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemGrid = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemQuickEnter = new System.Windows.Forms.ToolStripMenuItem();
            this.Pb1 = new System.Windows.Forms.ProgressBar();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.GridPanel = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.ChkBoxMultipleWords = new System.Windows.Forms.CheckBox();
            this.BtnAnagramSetup = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.TextBoxAnagramSetup = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ChkBoxConnectingLetters = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ComBoxGameType = new System.Windows.Forms.ComboBox();
            this.BtnFindWords = new System.Windows.Forms.Button();
            this.ComBoxGridSize = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ListBoxDictionary = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeWordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LabelDictionaryStatus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LabelDictionarySave = new System.Windows.Forms.Label();
            this.dictSaver = new System.ComponentModel.BackgroundWorker();
            this.dictPopulateList = new System.ComponentModel.BackgroundWorker();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TextBoxDictionarySearch
            // 
            this.TextBoxDictionarySearch.Location = new System.Drawing.Point(11, 49);
            this.TextBoxDictionarySearch.Name = "TextBoxDictionarySearch";
            this.TextBoxDictionarySearch.Size = new System.Drawing.Size(260, 20);
            this.TextBoxDictionarySearch.TabIndex = 1;
            this.TextBoxDictionarySearch.TextChanged += new System.EventHandler(this.DictionarySearchTextBox_TextChanged);
            // 
            // BtnAddWord
            // 
            this.BtnAddWord.Location = new System.Drawing.Point(277, 47);
            this.BtnAddWord.Name = "BtnAddWord";
            this.BtnAddWord.Size = new System.Drawing.Size(75, 23);
            this.BtnAddWord.TabIndex = 2;
            this.BtnAddWord.Text = "Add Word";
            this.BtnAddWord.UseVisualStyleBackColor = true;
            this.BtnAddWord.Click += new System.EventHandler(this.AddWordBtn_Click);
            // 
            // dictLoader
            // 
            this.dictLoader.WorkerReportsProgress = true;
            this.dictLoader.WorkerSupportsCancellation = true;
            this.dictLoader.DoWork += new System.ComponentModel.DoWorkEventHandler(this.DictionaryLoader_DoWork);
            this.dictLoader.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.DictionaryLoader_ProgressChanged);
            this.dictLoader.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.DictionaryLoader_RunWorkerCompleted);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemFile,
            this.MenuItemGrid});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(799, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MenuItemFile
            // 
            this.MenuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemDictionary,
            this.MenuItemExit});
            this.MenuItemFile.Name = "MenuItemFile";
            this.MenuItemFile.Size = new System.Drawing.Size(37, 20);
            this.MenuItemFile.Text = "File";
            // 
            // MenuItemDictionary
            // 
            this.MenuItemDictionary.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemReset,
            this.MenuItemAddFile,
            this.MenuItemAddFolder,
            this.MenuItemSave});
            this.MenuItemDictionary.Name = "MenuItemDictionary";
            this.MenuItemDictionary.Size = new System.Drawing.Size(152, 22);
            this.MenuItemDictionary.Text = "Dictionary";
            // 
            // MenuItemReset
            // 
            this.MenuItemReset.Name = "MenuItemReset";
            this.MenuItemReset.Size = new System.Drawing.Size(152, 22);
            this.MenuItemReset.Text = "Reset";
            this.MenuItemReset.Click += new System.EventHandler(this.ResetDictionaryMenu_Click);
            // 
            // MenuItemAddFile
            // 
            this.MenuItemAddFile.Name = "MenuItemAddFile";
            this.MenuItemAddFile.Size = new System.Drawing.Size(152, 22);
            this.MenuItemAddFile.Text = "Add File";
            this.MenuItemAddFile.Click += new System.EventHandler(this.AddFileToDictionaryMenu_Click);
            // 
            // MenuItemAddFolder
            // 
            this.MenuItemAddFolder.Name = "MenuItemAddFolder";
            this.MenuItemAddFolder.Size = new System.Drawing.Size(152, 22);
            this.MenuItemAddFolder.Text = "Add Folder";
            this.MenuItemAddFolder.Click += new System.EventHandler(this.AddFolderToDictionaryMenu_Click);
            // 
            // MenuItemSave
            // 
            this.MenuItemSave.Name = "MenuItemSave";
            this.MenuItemSave.Size = new System.Drawing.Size(152, 22);
            this.MenuItemSave.Text = "Save";
            this.MenuItemSave.Click += new System.EventHandler(this.SaveDictionaryMenu_Click);
            // 
            // MenuItemExit
            // 
            this.MenuItemExit.Name = "MenuItemExit";
            this.MenuItemExit.Size = new System.Drawing.Size(152, 22);
            this.MenuItemExit.Text = "Exit";
            this.MenuItemExit.Click += new System.EventHandler(this.ExitFormMenu_Click);
            // 
            // MenuItemGrid
            // 
            this.MenuItemGrid.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemQuickEnter});
            this.MenuItemGrid.Name = "MenuItemGrid";
            this.MenuItemGrid.Size = new System.Drawing.Size(41, 20);
            this.MenuItemGrid.Text = "Grid";
            this.MenuItemGrid.Visible = false;
            // 
            // MenuItemQuickEnter
            // 
            this.MenuItemQuickEnter.Name = "MenuItemQuickEnter";
            this.MenuItemQuickEnter.Size = new System.Drawing.Size(152, 22);
            this.MenuItemQuickEnter.Text = "Quick Enter";
            this.MenuItemQuickEnter.Click += new System.EventHandler(this.QuickGridEnterMenu_Click);
            // 
            // Pb1
            // 
            this.Pb1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Pb1.Location = new System.Drawing.Point(3, 399);
            this.Pb1.Name = "Pb1";
            this.Pb1.Size = new System.Drawing.Size(785, 23);
            this.Pb1.TabIndex = 4;
            this.Pb1.Visible = false;
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
            this.splitContainer1.Panel1.Controls.Add(this.GridPanel);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.ChkBoxMultipleWords);
            this.splitContainer1.Panel2.Controls.Add(this.BtnAnagramSetup);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.TextBoxAnagramSetup);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.ChkBoxConnectingLetters);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.ComBoxGameType);
            this.splitContainer1.Panel2.Controls.Add(this.BtnFindWords);
            this.splitContainer1.Panel2.Controls.Add(this.ComBoxGridSize);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Size = new System.Drawing.Size(785, 419);
            this.splitContainer1.SplitterDistance = 513;
            this.splitContainer1.TabIndex = 5;
            // 
            // GridPanel
            // 
            this.GridPanel.AutoScroll = true;
            this.GridPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridPanel.Location = new System.Drawing.Point(0, 0);
            this.GridPanel.Name = "GridPanel";
            this.GridPanel.Size = new System.Drawing.Size(513, 419);
            this.GridPanel.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 163);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Multiple Words:";
            // 
            // ChkBoxMultipleWords
            // 
            this.ChkBoxMultipleWords.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ChkBoxMultipleWords.AutoSize = true;
            this.ChkBoxMultipleWords.Checked = true;
            this.ChkBoxMultipleWords.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkBoxMultipleWords.Enabled = false;
            this.ChkBoxMultipleWords.Location = new System.Drawing.Point(111, 163);
            this.ChkBoxMultipleWords.Name = "ChkBoxMultipleWords";
            this.ChkBoxMultipleWords.Size = new System.Drawing.Size(15, 14);
            this.ChkBoxMultipleWords.TabIndex = 12;
            this.toolTip1.SetToolTip(this.ChkBoxMultipleWords, "Solutions can be made up of multiple words");
            this.ChkBoxMultipleWords.UseVisualStyleBackColor = true;
            // 
            // BtnAnagramSetup
            // 
            this.BtnAnagramSetup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnAnagramSetup.Enabled = false;
            this.BtnAnagramSetup.Location = new System.Drawing.Point(147, 191);
            this.BtnAnagramSetup.Name = "BtnAnagramSetup";
            this.BtnAnagramSetup.Size = new System.Drawing.Size(75, 23);
            this.BtnAnagramSetup.TabIndex = 11;
            this.BtnAnagramSetup.Text = "Setup";
            this.BtnAnagramSetup.UseVisualStyleBackColor = true;
            this.BtnAnagramSetup.Click += new System.EventHandler(this.AnagramSetupBtn_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Anagram Entry:";
            // 
            // TextBoxAnagramSetup
            // 
            this.TextBoxAnagramSetup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxAnagramSetup.Enabled = false;
            this.TextBoxAnagramSetup.Location = new System.Drawing.Point(111, 123);
            this.TextBoxAnagramSetup.Name = "TextBoxAnagramSetup";
            this.TextBoxAnagramSetup.Size = new System.Drawing.Size(152, 20);
            this.TextBoxAnagramSetup.TabIndex = 9;
            this.TextBoxAnagramSetup.TextChanged += new System.EventHandler(this.AnagramTextBox_TextChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Connecting Letters:";
            // 
            // ChkBoxConnectingLetters
            // 
            this.ChkBoxConnectingLetters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ChkBoxConnectingLetters.AutoSize = true;
            this.ChkBoxConnectingLetters.Checked = true;
            this.ChkBoxConnectingLetters.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkBoxConnectingLetters.Location = new System.Drawing.Point(111, 91);
            this.ChkBoxConnectingLetters.Name = "ChkBoxConnectingLetters";
            this.ChkBoxConnectingLetters.Size = new System.Drawing.Size(15, 14);
            this.ChkBoxConnectingLetters.TabIndex = 7;
            this.toolTip1.SetToolTip(this.ChkBoxConnectingLetters, "Check if you only want solutions where the letters can join each other in the gri" +
        "d, i.e. if you have to be able to draw a line between the letters.");
            this.ChkBoxConnectingLetters.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Problem Type:";
            // 
            // ComBoxGameType
            // 
            this.ComBoxGameType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ComBoxGameType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComBoxGameType.FormattingEnabled = true;
            this.ComBoxGameType.Items.AddRange(new object[] {
            "Grid",
            "Anagram"});
            this.ComBoxGameType.Location = new System.Drawing.Point(111, 11);
            this.ComBoxGameType.Name = "ComBoxGameType";
            this.ComBoxGameType.Size = new System.Drawing.Size(152, 21);
            this.ComBoxGameType.TabIndex = 5;
            this.ComBoxGameType.SelectedIndexChanged += new System.EventHandler(this.GameTypeComBox_SelectedIndexChanged);
            // 
            // BtnFindWords
            // 
            this.BtnFindWords.Enabled = false;
            this.BtnFindWords.Location = new System.Drawing.Point(74, 288);
            this.BtnFindWords.Name = "BtnFindWords";
            this.BtnFindWords.Size = new System.Drawing.Size(106, 23);
            this.BtnFindWords.TabIndex = 4;
            this.BtnFindWords.Text = "Find Words";
            this.BtnFindWords.UseVisualStyleBackColor = true;
            this.BtnFindWords.Click += new System.EventHandler(this.FindWordBtn_Click);
            // 
            // ComBoxGridSize
            // 
            this.ComBoxGridSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ComBoxGridSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComBoxGridSize.FormattingEnabled = true;
            this.ComBoxGridSize.Items.AddRange(new object[] {
            "3 x 3",
            "4 x 4"});
            this.ComBoxGridSize.Location = new System.Drawing.Point(111, 48);
            this.ComBoxGridSize.Name = "ComBoxGridSize";
            this.ComBoxGridSize.Size = new System.Drawing.Size(152, 21);
            this.ComBoxGridSize.TabIndex = 1;
            this.ComBoxGridSize.SelectedIndexChanged += new System.EventHandler(this.GridSizeComBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Grid Size:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ListBoxDictionary);
            this.tabPage2.Controls.Add(this.LabelDictionaryStatus);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.LabelDictionarySave);
            this.tabPage2.Controls.Add(this.Pb1);
            this.tabPage2.Controls.Add(this.TextBoxDictionarySearch);
            this.tabPage2.Controls.Add(this.BtnAddWord);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(791, 425);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Dictionary Info";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ListBoxDictionary
            // 
            this.ListBoxDictionary.ContextMenuStrip = this.contextMenuStrip1;
            this.ListBoxDictionary.FormattingEnabled = true;
            this.ListBoxDictionary.Location = new System.Drawing.Point(11, 84);
            this.ListBoxDictionary.Name = "ListBoxDictionary";
            this.ListBoxDictionary.Size = new System.Drawing.Size(260, 277);
            this.ListBoxDictionary.TabIndex = 8;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeWordToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(150, 26);
            // 
            // removeWordToolStripMenuItem
            // 
            this.removeWordToolStripMenuItem.Name = "removeWordToolStripMenuItem";
            this.removeWordToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.removeWordToolStripMenuItem.Text = "Remove Word";
            this.removeWordToolStripMenuItem.Click += new System.EventHandler(this.RemoveWordMenu_Click);
            // 
            // LabelDictionaryStatus
            // 
            this.LabelDictionaryStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LabelDictionaryStatus.AutoSize = true;
            this.LabelDictionaryStatus.Location = new System.Drawing.Point(8, 383);
            this.LabelDictionaryStatus.Name = "LabelDictionaryStatus";
            this.LabelDictionaryStatus.Size = new System.Drawing.Size(43, 13);
            this.LabelDictionaryStatus.TabIndex = 7;
            this.LabelDictionaryStatus.Text = "Status: ";
            this.LabelDictionaryStatus.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Check For Word:";
            // 
            // LabelDictionarySave
            // 
            this.LabelDictionarySave.AutoSize = true;
            this.LabelDictionarySave.Location = new System.Drawing.Point(8, 3);
            this.LabelDictionarySave.Name = "LabelDictionarySave";
            this.LabelDictionarySave.Size = new System.Drawing.Size(89, 13);
            this.LabelDictionarySave.TabIndex = 5;
            this.LabelDictionarySave.Text = "Dictionary Size: 0";
            // 
            // dictSaver
            // 
            this.dictSaver.DoWork += new System.ComponentModel.DoWorkEventHandler(this.DictionarySaver_DoWork);
            this.dictSaver.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.DictionarySaver_RunWorkerCompleted);
            // 
            // dictPopulateList
            // 
            this.dictPopulateList.WorkerSupportsCancellation = true;
            this.dictPopulateList.DoWork += new System.ComponentModel.DoWorkEventHandler(this.DictionaryPopulateList_DoWork);
            this.dictPopulateList.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.DictionaryPopulateList_RunWorkerCompleted);
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
            this.Text = "Nick\'s Word Machine";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_Closing);
            this.Shown += new System.EventHandler(this.MainWindow_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextBoxDictionarySearch;
        private System.Windows.Forms.Button BtnAddWord;
        private System.ComponentModel.BackgroundWorker dictLoader;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuItemFile;
        private System.Windows.Forms.ToolStripMenuItem MenuItemDictionary;
        private System.Windows.Forms.ToolStripMenuItem MenuItemReset;
        private System.Windows.Forms.ToolStripMenuItem MenuItemAddFile;
        private System.Windows.Forms.ToolStripMenuItem MenuItemAddFolder;
        private System.Windows.Forms.ProgressBar Pb1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label LabelDictionarySave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel GridPanel;
        private System.Windows.Forms.ComboBox ComBoxGridSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnFindWords;
        private System.Windows.Forms.ToolStripMenuItem MenuItemExit;
        private System.Windows.Forms.ToolStripMenuItem MenuItemGrid;
        private System.Windows.Forms.ToolStripMenuItem MenuItemQuickEnter;
        private System.ComponentModel.BackgroundWorker dictSaver;
        private System.Windows.Forms.Label LabelDictionaryStatus;
        private System.Windows.Forms.ListBox ListBoxDictionary;
        private System.ComponentModel.BackgroundWorker dictPopulateList;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ComBoxGameType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox ChkBoxConnectingLetters;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem MenuItemSave;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TextBoxAnagramSetup;
        private System.Windows.Forms.Button BtnAnagramSetup;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox ChkBoxMultipleWords;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem removeWordToolStripMenuItem;
    }
}

