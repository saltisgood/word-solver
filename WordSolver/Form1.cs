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

namespace WordSolver
{
    public partial class Form1 : Form
    {
        private const int GRID_MAX_X = 4;
        private const int GRID_MAX_Y = 4;
        private const String DICT_LABEL_PROMPT = "Dictionary size: ";

        private DictTree Tree;
        private int GridIndex = 0;
        private LetterGrid Grid;

        public Form1()
        {
            InitializeComponent();
            Grid = new LetterGrid(4, 4, GRID_MAX_X, GRID_MAX_Y);
            tabControl1.SelectedIndex = 1;
            comboBox1.SelectedIndex = 1;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            initialiseDictionary();
        }

        private void button2_Click(object sender, EventArgs e)
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

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will completely reset the dictionary. Continue?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                != System.Windows.Forms.DialogResult.Yes)
            {
                return;
            }

            initialiseDictionary();
        }

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

            dictLoader.RunWorkerAsync(openFile.FileName);
        }

        private void addFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderSelect = new FolderBrowserDialog();
            folderSelect.Description = "Select the folder with your dictionary files";
            if (folderSelect.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }

            dictLoader.RunWorkerAsync(folderSelect.SelectedPath);
        }

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

            dictLoader.RunWorkerAsync(folderSelect.SelectedPath);
        }

        #region Dictionary Loading

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

        private void AddFolder(String folder)
        {
            string[] files = Directory.GetFiles(folder);
            for (int i = 0; i < files.Length; i++)
            {
                AddFile(files[i]);
                dictLoader.ReportProgress(100 * i / files.Length);
            }
        }

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

        private void dictLoader_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (!pb1.Visible)
            {
                pb1.Show();
            }
            pb1.Value = e.ProgressPercentage;
        }

        private void dictLoader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bool? result = e.Result as bool?;

            if (e.Error != null)
            {
                //TODO: Handle errors
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
        }

        #endregion

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

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
