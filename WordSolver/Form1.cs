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
        private DictTree Tree;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }

            Tree = new DictTree();

            using (FileStream fs = new FileStream(openFile.FileName, FileMode.Open, FileAccess.Read))
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
            MessageBox.Show("Finished with " + Tree.WordCount + " words!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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

        private void initialiseDictionary()
        {
            Tree = new DictTree();

            FolderBrowserDialog folderSelect = new FolderBrowserDialog();
            if (folderSelect.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                MessageBox.Show("Dictionary initialisation canceled. Please add files with the menu later", "Operation canceled", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            
        }

        private void AddFolder(String folder)
        {

        }

        private void AddFile(String file)
        {

        }

        private void dictLoader_DoWork(object sender, DoWorkEventArgs e)
        {

        }
    }
}
