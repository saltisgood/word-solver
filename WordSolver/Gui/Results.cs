using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordSolver.Util;
using WordSolver.Dictionary;

namespace WordSolver.Gui
{
    public partial class Results : Form
    {
        private DictTree Tree;

        public Results(DictTree tree)
        {
            InitializeComponent();

            List<String>.Enumerator results = Solutions.Enumerate();
            while (results.MoveNext())
            {
                listBox1.Items.Add(results.Current);
            }

            Tree = tree;
        }

        private void removeFromDictionaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            object selectedItem = listBox1.SelectedItem;
            if (selectedItem == null)
            {
                return;
            }

            if (Tree.RemoveWord(selectedItem.ToString()))
            {
                listBox1.Items.Remove(selectedItem);
                MessageBox.Show(selectedItem.ToString() + " removed from dictionary. Remember to save dictionary when finished.", "Word removed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Unable to remove " + selectedItem.ToString() + " from dictionary", "Error removing word", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
