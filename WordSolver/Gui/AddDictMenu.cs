using System;
using System.Windows.Forms;

namespace WordSolver.Gui
{
    /// <summary>
    /// Little form for selecting how to add a dictionary file to the dictionary
    /// </summary>
    public partial class AddDictMenu : Form
    {
        /// <summary>
        /// Reference to the main window form
        /// </summary>
        private MainWindow _parentWindow;

        /// <summary>
        /// Determines whether this form is programmatically closing itself by the user clicking on
        /// one of the buttons and closing inside the handler
        /// </summary>
        private bool _selfClose = false;



        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="prevWindow">Reference to the main window form</param>
        public AddDictMenu(MainWindow prevWindow)
        {
            InitializeComponent();

            _parentWindow = prevWindow;
        }



        /// <summary>
        /// Click handler for the add file to dictionary button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openFileButtonClick(object sender, EventArgs e)
        {
            _selfClose = true;
            this.Close();
            _parentWindow.AddFileToDictionaryMenu_Click(null, null);
        }

        /// <summary>
        /// Click handler for the add folder to dictionary button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openFolderButtonClick(object sender, EventArgs e)
        {
            _selfClose = true;
            this.Close();
            _parentWindow.AddFolderToDictionaryMenu_Click(null, null);
        }

        /// <summary>
        /// Click handler for the cancel button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            _selfClose = true;
            if (!_parentWindow.HasPopulatedDictionary())
            {
                MessageBox.Show("Note: You have to add some words to the dictionary before you can use the solving functions of this program!", 
                    "Dictionary addition canceled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.Close();
        }

        /// <summary>
        /// Callback to be invoked prior to closing the form. Gives a little warning message to the user that
        /// they have to add words to the dictionary to use the program.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddDictMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_selfClose && !_parentWindow.HasPopulatedDictionary())
            {
                MessageBox.Show("Note: You have to add some words to the dictionary before you can use the solving functions of this program!",
                    "Dictionary addition canceled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
