using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordSolver.Gui
{
    public partial class AddDictMenu : Form
    {
        private MainWindow ParentWindow;
        private bool SelfClose = false;

        public AddDictMenu(MainWindow prevWindow)
        {
            InitializeComponent();

            ParentWindow = prevWindow;
        }

        private void openFileButtonClick(object sender, EventArgs e)
        {
            SelfClose = true;
            this.Close();
            ParentWindow.addFileToolStripMenuItem_Click(null, null);
        }

        private void openFolderButtonClick(object sender, EventArgs e)
        {
            SelfClose = true;
            this.Close();
            ParentWindow.addFolderToolStripMenuItem_Click(null, null);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            SelfClose = true;
            if (!ParentWindow.HasPopulatedTree())
            {
                MessageBox.Show("Note: You have to add some words to the dictionary before you can use the solving functions of this program!", 
                    "Dictionary addition canceled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.Close();
        }

        private void AddDictMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!SelfClose && !ParentWindow.HasPopulatedTree())
            {
                MessageBox.Show("Note: You have to add some words to the dictionary before you can use the solving functions of this program!",
                    "Dictionary addition canceled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
