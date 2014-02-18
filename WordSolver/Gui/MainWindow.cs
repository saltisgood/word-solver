using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic;
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
        /// The prompt that goes before the status of the dictionary in its associated label
        /// </summary>
        private const String DICT_STATUS_LABEL_PROMPT = "Status: ";
        /// <summary>
        /// The prompt that goes before the size of the dictionary in its associated label
        /// </summary>
        private const String DICT_LABEL_PROMPT = "Dictionary size: ";

        /// <summary>
        /// The dictionary tree used in the program
        /// </summary>
        private DictTree Tree;
        /// <summary>
        /// The currently selected type of grid used in the form
        /// </summary>
        private int GridIndex = 0;
        /// <summary>
        /// The Grid object used in the form
        /// </summary>
        private LetterGrid Grid;
        /// <summary>
        /// Boolean used for determining whether to save the dictionary after it's finished loading
        /// </summary>
        private bool SaveWhenFinished = false;

        /// <summary>
        /// Default constructor. Initialises all necessary components
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            Grid = new LetterGrid(4, 4);
            tabControl1.SelectedIndex = 1;
            comboBox1.SelectedIndex = 1;
        }

        /// <summary>
        /// Event handler for when the form is shown to the user. Starts loading the dictionary
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindowShown(object sender, EventArgs e)
        {
            if (!LoadDefaultDictionary())
            {
                initialiseDictionary();
            }
        }

        #region GUI Junk

        /// <summary>
        /// Event handler for when the button is clicked to check whether a word is in the dictionary
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkWordClick(object sender, EventArgs e)
        {
            String input = wordInput.Text;
            if (String.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("No input detected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Tree == null)
            {
                MessageBox.Show("Dictionary not initialised", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Tree.FindWord(input))
            {
                MessageBox.Show("Word found", "Yay!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Word not found :(", "Aww...", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        /// <summary>
        /// Event handler for when the dictionary reset menu item is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will completely reset the dictionary. Continue?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                != System.Windows.Forms.DialogResult.Yes)
            {
                return;
            }

            String path = getDictionaryPath();
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            initialiseDictionary();
        }

        /// <summary>
        /// Event handler for when the add file to dictionary menu item is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.CheckFileExists = true;
            openFile.CheckPathExists = true;
            openFile.Title = "Select the dictionary file to add";
            if (openFile.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }

            preBGW(true);
            dictLoader.RunWorkerAsync(openFile.FileName);
        }

        /// <summary>
        /// Event handler for when the add folder to dictionary menu item is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderSelect = new FolderBrowserDialog();
            folderSelect.Description = "Select the folder with your dictionary files";
            if (folderSelect.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }

            preBGW(true);
            dictLoader.RunWorkerAsync(folderSelect.SelectedPath);
        }

        /// <summary>
        /// Event handler for when the selected item in the grid combo box is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == GridIndex)
            {
                return;
            }

            panel1.Controls.Clear();
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    Grid.SetGridSize(3, 3);
                    panel1.Controls.AddRange(Grid.GetControls());
                    GridIndex = 0;
                    this.MinimumSize = new Size(337, 431);
                    this.Size = new Size(337, 431);
                    break;
                case 1:
                    Grid.SetGridSize(4, 4);
                    panel1.Controls.AddRange(Grid.GetControls());
                    GridIndex = 1;
                    this.MinimumSize = new Size(442, 537);
                    this.Size = new Size(442, 537);
                    break;
            }
        }

        /// <summary>
        /// Event handler for when the button is pressed to find all words in the dictionary given a particular grid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void findWordsClick(object sender, EventArgs e)
        {
            Solutions.Reset();
            Grid.FindWords(Tree);
            MessageBox.Show("Found: " + Solutions.Count + " words", "Finished", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            Solutions.Finish();
            new Results().ShowDialog();
        }

        /// <summary>
        /// Event handler for when the quick enter menu item is clicked. This is when you enter a series of letters to be displayed in the grid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void quickEnterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String result = Interaction.InputBox("Enter the letters in order with spaces in between them", "Quick Letter Entry", String.Empty);
            string[] letters = result.Split(' ');
            switch (GridIndex)
            {
                case 0:
                    throw new NotImplementedException();
                case 1:
                    if (letters.Length < 16)
                    {
                        if (MessageBox.Show("Not enough letters entered", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error)
                            == System.Windows.Forms.DialogResult.Retry)
                        {
                            quickEnterToolStripMenuItem_Click(null, null);
                        }
                        return;
                    }

                    for (int i = 0; i < 16; i++)
                    {
                        Grid.SetButtonValue(i, LetterUtil.GetLetter(letters[i][0]));
                    }
                    break;
            }
        }

        #endregion

        #region Dictionary Loading

        /// <summary>
        /// Helper method to get the path of the program's dictionary. This is in the same directory as the executable and is called "user.dict"
        /// </summary>
        /// <returns>The full path to the dictionary</returns>
        private String getDictionaryPath()
        {
            return Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "user.dict");
        }

        /// <summary>
        /// Attempt to load the default dictionary file. Should be called from the main thread and will not block.
        /// </summary>
        /// <returns>True if the dictionary file exists and is starting to be read, false if it can't be found</returns>
        private bool LoadDefaultDictionary()
        {
            Tree = new DictTree();
            String path = getDictionaryPath();
            if (!File.Exists(path))
            {
                return false;
            }

            preBGW(false);
            dictLoader.RunWorkerAsync(path);
            return true;
        }

        /// <summary>
        /// Initialise the dictionary. This resets the tree held in memory, asks the user to select a folder of dictionary files and will save the
        /// new dictionary after it finishes scanning. Should be called from the main thread and will not block.
        /// </summary>
        private void initialiseDictionary()
        {
            Tree = new DictTree();

            FolderBrowserDialog folderSelect = new FolderBrowserDialog();
            folderSelect.Description = "Select the folder with your dictionary files";
            if (folderSelect.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                MessageBox.Show("Dictionary initialisation canceled. Please add files with the menu later", "Operation canceled", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            preBGW(true);
            dictLoader.RunWorkerAsync(folderSelect.SelectedPath);
        }

        /// <summary>
        /// Helper method that should be called from the main thread prior to starting the background dictionary loader
        /// </summary>
        /// <param name="postSave">True to save the dictionary after loading</param>
        private void preBGW(bool postSave)
        {
            pb1.Value = 0;
            pb1.Show();
            dictStatusLabel.Text = DICT_STATUS_LABEL_PROMPT + "Loading...";
            dictStatusLabel.Show();
            SaveWhenFinished = postSave;
        }

        /// <summary>
        /// The method that is run on the background thread to load the dictionary. The path of the files to be loaded
        /// should be passed as the argument.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dictLoader_DoWork(object sender, DoWorkEventArgs e)
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
                        Tree.AddWord(line);
                    }
                }
            }
        }

        /// <summary>
        /// The handler for when the dictionary loader changes progress. Changes the progress value of the progress bar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dictLoader_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (!pb1.Visible)
            {
                pb1.Show();
            }
            pb1.Value = e.ProgressPercentage;
        }

        /// <summary>
        /// The method called when the dictionary loader finishes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dictLoader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bool? result = e.Result as bool?;

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
                    dictSizeLabel.Text = DICT_LABEL_PROMPT + Tree.WordCount;
                    MessageBox.Show("Done");
                }
                else
                {
                    MessageBox.Show("Error loading");
                }
            }

            pb1.Hide();
            label1.Hide();

            if (!File.Exists(getDictionaryPath()) && Tree.WordCount > 0)
            {
                dictSaver.RunWorkerAsync();
            }
        }

        /// <summary>
        /// The method called to save the dictionary to file. Don't manually call
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dictSaver_DoWork(object sender, DoWorkEventArgs e)
        {
            String path = getDictionaryPath();
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
        private void dictSaver_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // TODO: Possibly add some handler here
        }

        #endregion 
    }
}
