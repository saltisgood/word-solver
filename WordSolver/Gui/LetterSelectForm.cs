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

namespace WordSolver.Gui
{
    /// <summary>
    /// A form used to let the user choose the options for a particular letter in the grid. Should always
    /// be used as a modal dialog (.ShowDialog() rather than .Show())
    /// </summary>
    public partial class LetterSelectForm : Form
    {
        /// <summary>
        /// The button in the grid that the form is associated with
        /// </summary>
        private LetterButton Button;

        /// <summary>
        /// Standard constructor. Associates the form with a particular letter in the grid.
        /// </summary>
        /// <param name="button">The button in the grid that the otions are being set for</param>
        public LetterSelectForm(LetterButton button)
        {
            Button = button;
            InitializeComponent();

            letterComBox.SelectedIndex = (int)Button.SelectedLetter;
            requiredCheBox.Checked = Button.IsRequired;
            restrictionCombo.SelectedIndex = (int)Button.Restriction;
        }

        /// <summary>
        /// The click event handler for the OK button. Takes the selected options and applies them to the button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Button.SelectedLetter = (LetterUtil.Letter)letterComBox.SelectedIndex;
            Button.IsRequired = requiredCheBox.Checked;
            Button.Restriction = (PositionRestriction)restrictionCombo.SelectedIndex;
            Button.Text = LetterButton.GetText(Button);

            if (Button.IsRequired)
            {
                Button.BackColor = SystemColors.ControlDark;
            }
            else
            {
                Button.BackColor = SystemColors.Control;
            }
        }
    }
}
