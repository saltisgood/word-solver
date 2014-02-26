using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using WordSolver.Dictionary;
using WordSolver.Grid;
using WordSolver.Util;

namespace WordSolver.Gui
{
    /// <summary>
    /// The main window that is shown to the user
    /// </summary>
    public partial class MainWindow : Form
    {
        /// <summary>
        /// The prompt that goes before the size of the dictionary in its associated label
        /// </summary>
        private const String DICT_LABEL_PROMPT = "Dictionary size: ";

        /// <summary>
        /// The prompt that goes before the status of the dictionary in its associated label
        /// </summary>
        private const String DICT_STATUS_LABEL_PROMPT = "Status: ";
        


        /// <summary>
        /// The dictionary tree used in the program
        /// </summary>
        public DictTree Tree { get; private set; }



        /// <summary>
        /// The Grid object used in the form when the selected game type is Anagram
        /// </summary>
        private LetterGrid _anagramGrid;

        /// <summary>
        /// The Grid object used in the form when the selected game type is Grid
        /// </summary>
        private LetterGrid _gameGrid;

        /// <summary>
        /// The currently selected game type
        /// 0 == Grid
        /// 1 == Anagram
        /// </summary>
        private int _gameTypeIndex = 0;

        /// <summary>
        /// The currently selected type of grid used in the form
        /// </summary>
        private int _gridIndex = 0;

        /// <summary>
        /// Determines whether the program should save the state of the dictionary before exiting
        /// </summary>
        private bool _saveOnExit = false;

        /// <summary>
        /// Boolean used for determining whether to save the dictionary after it's finished loading
        /// </summary>
        private bool _saveWhenFinished = false;
        
        

        /// <summary>
        /// Default constructor. Initialises all necessary components
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            _gameGrid = new LetterGrid(4, 4, this);
            ComBoxGridSize.SelectedIndex = 1;
            ComBoxGameType.SelectedIndex = 0;
        }

        /// <summary>
        /// Event handler for when the form is shown to the user. Starts loading the dictionary
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_Shown(object sender, EventArgs e)
        {
            if (!LoadDefaultDictionary())
            {
                InitialiseDictionary();
            }
        }

        /// <summary>
        /// Callback when the form is closing. Is used to save the dictionary if it's been modified.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_Closing(object sender, FormClosingEventArgs e)
        {
            if (_saveOnExit && !dictSaver.IsBusy)
            {
                dictSaver.RunWorkerAsync();
            }

            if (dictSaver.IsBusy)
            {
                this.UseWaitCursor = true;

                while (dictSaver.IsBusy)
                {
                    Application.DoEvents();
                }
            }
        }

        #region GUI Junk

        /// <summary>
        /// Event handler for when the add file to dictionary menu item is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AddFileToDictionaryMenu_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.CheckFileExists = true;
            openFile.CheckPathExists = true;
            openFile.Title = "Select the dictionary file to add";
            if (openFile.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }

            PreDictionaryLoader(true);
            dictLoader.RunWorkerAsync(openFile.FileName);
        }

        /// <summary>
        /// Event handler for when the add folder to dictionary menu item is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AddFolderToDictionaryMenu_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderSelect = new FolderBrowserDialog();
            folderSelect.Description = "Select the folder with your dictionary files";
            if (folderSelect.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }

            PreDictionaryLoader(true);
            dictLoader.RunWorkerAsync(folderSelect.SelectedPath);
        }

        /// <summary>
        /// Event handler for when the button is clicked to check whether a word is in the dictionary
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddWordBtn_Click(object sender, EventArgs e)
        {
            String text = TextBoxDictionarySearch.Text;
            if (String.IsNullOrWhiteSpace(text))
            {
                MessageBox.Show("Type in a word to add in the text box", "No word entered", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Tree.AddWord(text))
            {
                LabelDictionarySave.Text = DICT_LABEL_PROMPT + Tree.WordCount;
                DictionarySearchTextBox_TextChanged(null, null);
                BtnFindWords.Enabled = true;
                _saveOnExit = true;
                MessageBox.Show(text + " has been added to the dictionary!", "Word added", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show(text + " is already in the dictionary", "Existing word entered", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        /// <summary>
        /// Event handler for clicking on the anagram setup button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AnagramSetupBtn_Click(object sender, EventArgs e)
        {
            _anagramGrid = new LetterGrid(TextBoxAnagramSetup.Text.Trim().ToLowerInvariant(), this);
            GridPanel.Controls.Clear();
            GridPanel.Controls.AddRange(_anagramGrid.GetControls());
        }

        /// <summary>
        /// Event handler for when the user types into the text box for setting up anagrams
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AnagramTextBox_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(TextBoxAnagramSetup.Text))
            {
                BtnAnagramSetup.Enabled = false;
            }
            else
            {
                BtnAnagramSetup.Enabled = true;
            }
        }

        /// <summary>
        /// Event handler for when the user types into the dictionary search text box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DictionarySearchTextBox_TextChanged(object sender, EventArgs e)
        {
            if (Tree.WordCount > 0)
            {
                ListBoxDictionary.Items.Clear();
                if (dictPopulateList.IsBusy)
                {
                    dictPopulateList.CancelAsync();
                    while (dictPopulateList.IsBusy)
                    {
                        Thread.Sleep(50);
                    }
                }
                dictPopulateList.RunWorkerAsync(TextBoxDictionarySearch.Text);
            }
        }

        /// <summary>
        /// Event handler for the close program menu item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitFormMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Event handler for when the button is pressed to find all words in the dictionary given a particular grid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FindWordBtn_Click(object sender, EventArgs e)
        {
            Solutions.Reset();
            switch (_gameTypeIndex)
            {
                case 0: // Grid
                    _gameGrid.Options.AreConnectingLettersRequired = ChkBoxConnectingLetters.Checked;
                    _gameGrid.FindWords();
                    break;
                case 1: // Anagram
                    _anagramGrid.Options.AreMultipleWordsAllowed = ChkBoxMultipleWords.Checked;
                    _anagramGrid.FindWords();
                    break;
                default:
                    throw new InvalidOperationException("Unexpected GameTypeIndex value!");
            }
            MessageBox.Show("Found: " + Solutions.Count + " words", "Finished", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            Solutions.Finish();
            new Results().ShowDialog();
        }

        /// <summary>
        /// Event handler for when the user selects a different item in the game type combo box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameTypeComBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComBoxGameType.SelectedIndex == _gameTypeIndex)
            {
                return;
            }

            switch (ComBoxGameType.SelectedIndex)
            {
                case 0:
                    ComBoxGridSize.Enabled = true;
                    ChkBoxConnectingLetters.Enabled = true;
                    _gameTypeIndex = 0;
                    TextBoxAnagramSetup.Enabled = false;
                    BtnAnagramSetup.Enabled = false;
                    ChkBoxMultipleWords.Enabled = false;
                    break;
                case 1:
                    ComBoxGridSize.Enabled = false;
                    ChkBoxConnectingLetters.Enabled = false;
                    _gameTypeIndex = 1;
                    TextBoxAnagramSetup.Enabled = true;
                    ChkBoxMultipleWords.Enabled = true;
                    if (!String.IsNullOrWhiteSpace(TextBoxAnagramSetup.Text))
                    {
                        BtnAnagramSetup.Enabled = true;
                    }

                    if (_anagramGrid == null)
                    {
                        String result = Interaction.InputBox("Enter the letters to be solved", "Enter the anagram", string.Empty);
                        if (String.IsNullOrWhiteSpace(result))
                        {
                            _anagramGrid = new LetterGrid(this);
                        }
                        else
                        {
                            result = result.Trim().ToLowerInvariant().Replace(" ", "");
                            _anagramGrid = new LetterGrid(result, this);
                        }
                    }
                    break;
            }

            RefreshPanel();
        }

        /// <summary>
        /// Event handler for when the selected item in the grid combo box is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridSizeComBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComBoxGridSize.SelectedIndex == _gridIndex)
            {
                return;
            }

            GridPanel.Controls.Clear();
            switch (ComBoxGridSize.SelectedIndex)
            {
                case 0:
                    _gameGrid.SetGridSize(3, 3);
                    GridPanel.Controls.AddRange(_gameGrid.GetControls());
                    _gridIndex = 0;
                    break;
                case 1:
                    _gameGrid.SetGridSize(4, 4);
                    GridPanel.Controls.AddRange(_gameGrid.GetControls());
                    _gridIndex = 1;
                    break;
            }
        }

        /// <summary>
        /// Event handler for when the quick enter menu item is clicked. This is when you enter a series of letters to be displayed in the grid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QuickGridEnterMenu_Click(object sender, EventArgs e)
        {
            String result = Interaction.InputBox("Enter the letters in order with spaces in between them", "Quick Letter Entry", String.Empty);
            string[] letters = result.Split(' ');
            switch (_gridIndex)
            {
                case 0:
                    throw new NotImplementedException();
                case 1:
                    if (letters.Length < 16)
                    {
                        if (MessageBox.Show("Not enough letters entered", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error)
                            == System.Windows.Forms.DialogResult.Retry)
                        {
                            QuickGridEnterMenu_Click(null, null);
                        }
                        return;
                    }

                    for (int i = 0; i < 16; i++)
                    {
                        _gameGrid.SetButtonValue(i, LetterUtil.GetLetter(letters[i][0]));
                    }
                    break;
            }
        }

        /// <summary>
        /// Event handler for clicking on the remove word right-click item in the dictionary list box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveWordMenu_Click(object sender, EventArgs e)
        {
            String word = ListBoxDictionary.SelectedItem as String;
            if (String.IsNullOrWhiteSpace(word))
            {
                return;
            }

            if (MessageBox.Show("Remove " + word + " from the dictionary?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            if (Tree.RemoveWord(word))
            {
                DictionarySearchTextBox_TextChanged(null, null);
                _saveOnExit = true;
                MessageBox.Show(word + " removed from the dictionary", "Operation Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show(word + " could not be removed from the dictionary for some reason. ", "Operation Failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        /// <summary>
        /// Method for refreshing the panel that contains the buttons for the game grids
        /// </summary>
        public void RefreshPanel()
        {
            GridPanel.Controls.Clear();
            switch (_gameTypeIndex)
            {
                case 0: // Grid
                    GridPanel.Controls.AddRange(_gameGrid.GetControls());
                    break;
                case 1: // Anagram
                    GridPanel.Controls.AddRange(_anagramGrid.GetControls());
                    break;
                default:
                    throw new InvalidOperationException("GameTypeIndex has unexpected value");
            }
        }

        /// <summary>
        /// Event handler for when the dictionary reset menu item is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetDictionaryMenu_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will completely reset the dictionary. Continue?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                != System.Windows.Forms.DialogResult.Yes)
            {
                return;
            }

            String path = GetDictionaryPath();
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            InitialiseDictionary();
        }

        /// <summary>
        /// Event handler for clicking on the save dictionary menu item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveDictionaryMenu_Click(object sender, EventArgs e)
        {
            PreDictionarySaver(true);
        }

        #endregion

        #region Dictionary Loading

        /// <summary>
        /// Add a file to be loaded to the dictionary. Don't call from the main thread, it's not instantaneous.
        /// </summary>
        /// <param name="file">The path to the file to be loaded</param>
        private void AddFile(String file)
        {
            using (FileStream fs = File.OpenRead(file))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    String line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        line = line.Trim().ToLowerInvariant();
                        if (!LetterUtil.ContainsInvalidLetters(line))
                        {
                            Tree.AddWord(line);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Add a folder of files to be loaded into the dictionary. Don't call from the main thread, it's not instantaneous.
        /// </summary>
        /// <param name="folder">The path to the folder to be loaded</param>
        private void AddFolder(String folder)
        {
            string[] files = Directory.GetFiles(folder);
            for (int i = 0; i < files.Length; i++)
            {
                AddFile(files[i]);
                dictLoader.ReportProgress(100 * i / files.Length);
            }
        }

        /// <summary>
        /// The method that is run on the background thread to load the dictionary. The path of the files to be loaded
        /// should be passed as the argument.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DictionaryLoader_DoWork(object sender, DoWorkEventArgs e)
        {
            String dictPath;

            dictLoader.ReportProgress(0);
            if (e == null || e.Argument == null || (dictPath = e.Argument as String) == null)
            {
                e.Result = false;
                return;
            }

            FileAttributes attrs = File.GetAttributes(dictPath);
            if ((attrs & FileAttributes.Directory) == FileAttributes.Directory)
            {
                AddFolder(dictPath);
            }
            else
            {
                AddFile(dictPath);
            }

            dictLoader.ReportProgress(100);
            e.Result = true;
        }

        /// <summary>
        /// The handler for when the dictionary loader changes progress. Changes the progress value of the progress bar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DictionaryLoader_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (!Pb1.Visible)
            {
                Pb1.Show();
            }
            Pb1.Value = e.ProgressPercentage;
        }

        /// <summary>
        /// The method called when the dictionary loader finishes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DictionaryLoader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bool? result = e.Result as bool?;
            Exception error = e.Result as Exception;

            if (e.Error != null)
            {
                MessageBox.Show("An error occurred loading the dictionary:\n" + e.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (e.Cancelled)
            {
                //TODO: Handle user cancelled
            }
            else if (result != null && result.HasValue)
            {
                if (result.Value)
                {
                    LabelDictionarySave.Text = DICT_LABEL_PROMPT + Tree.WordCount;
                    BtnFindWords.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Error loading");
                }
            }
            else if (error != null)
            {
                MessageBox.Show("An error occurred whilst loading the dictionary: " + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Pb1.Hide();
            LabelDictionaryStatus.Hide();
            MenuItemDictionary.Enabled = true;

            if (!File.Exists(GetDictionaryPath()) && Tree.WordCount > 0)
            {
                PreDictionarySaver(null);
            }
        }

        /// <summary>
        /// Helper method to get the path of the program's dictionary. This is in the same directory as the executable and is called "user.dict"
        /// </summary>
        /// <returns>The full path to the dictionary</returns>
        private String GetDictionaryPath()
        {
            return Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "user.dict");
        }

        /// <summary>
        /// Initialise the dictionary. This resets the tree held in memory, asks the user to select a folder of dictionary files and will save the
        /// new dictionary after it finishes scanning. Should be called from the main thread and will not block.
        /// </summary>
        private void InitialiseDictionary()
        {
            Tree = new DictTree();
            LabelDictionarySave.Text = DICT_LABEL_PROMPT + "0";

            AddDictMenu addDict = new AddDictMenu(this);
            addDict.ShowDialog();
        }

        /// <summary>
        /// Attempt to load the default dictionary file. Should be called from the main thread and will not block.
        /// </summary>
        /// <returns>True if the dictionary file exists and is starting to be read, false if it can't be found</returns>
        private bool LoadDefaultDictionary()
        {
            Tree = new DictTree();
            String path = GetDictionaryPath();
            if (!File.Exists(path))
            {
                return false;
            }

            PreDictionaryLoader(false);
            dictLoader.RunWorkerAsync(path);
            return true;
        }

        /// <summary>
        /// Helper method that should be called from the main thread prior to starting the background dictionary loader
        /// </summary>
        /// <param name="postSave">True to save the dictionary after loading</param>
        private void PreDictionaryLoader(bool postSave)
        {
            Pb1.Value = 0;
            Pb1.Show();
            LabelDictionaryStatus.Text = DICT_STATUS_LABEL_PROMPT + "Loading...";
            LabelDictionaryStatus.Show();
            MenuItemDictionary.Enabled = false;
            _saveWhenFinished = postSave;
        }

        #endregion 

        #region Dictionary saving
        
        /// <summary>
        /// The method called to save the dictionary to file. Don't manually call
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DictionarySaver_DoWork(object sender, DoWorkEventArgs e)
        {
            bool? arg = e.Argument as bool?;
            if (arg != null && arg.HasValue && arg.Value)
            {
                e.Result = true;
            }

            String path = GetDictionaryPath();
            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    Tree.WriteToStream(sw);
                }
            }
        }

        /// <summary>
        /// The method to be called when the dictionary has finished saving.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DictionarySaver_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _saveOnExit = false;
            MenuItemSave.Enabled = true;

            bool? result = e.Result as bool?;
            if (result != null && result.HasValue && result.Value)
            {
                MessageBox.Show("Dictionary saved", "Dictionary saved", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        /// <summary>
        /// Helper method that should be called to start the dictionary saving. Call from the main thread.
        /// </summary>
        /// <param name="bgArgs">Any arguments to pass to the dictionary saving background worker</param>
        private void PreDictionarySaver(object bgArgs)
        {
            MenuItemSave.Enabled = false;
            dictSaver.RunWorkerAsync(bgArgs);
        }

        #endregion

        #region Dictionary Searching

        /// <summary>
        /// The method called to search the dictionary given a partial match to populate the listbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DictionaryPopulateList_DoWork(object sender, DoWorkEventArgs e)
        {
            String input;
            if (e == null || e.Argument == null || (input = e.Argument as String) == null)
            {
                return;
            }

            e.Result = Tree.WordSearch(input);
        }

        /// <summary>
        /// Callback method when the dictionary searching is finished
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DictionaryPopulateList_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            List<String> solns;
            if (e == null || e.Result == null || (solns = e.Result as List<String>) == null)
            {
                return;
            }

            foreach (String str in solns)
            {
                ListBoxDictionary.Items.Add(str);
            }
        }

        #endregion

        #region Misc

        /// <summary>
        /// Check whether the form's dictionary tree is empty or actually has values
        /// </summary>
        /// <returns>True if the dictionary contains items, false otherwise</returns>
        public bool HasPopulatedDictionary()
        {
            if (Tree != null && Tree.WordCount > 0)
            {
                return true;
            }
            return false;
        }

        #endregion
    }
}
