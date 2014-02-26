using System;
using System.Drawing;
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
        private LetterButton _button;



        /// <summary>
        /// Standard constructor. Associates the form with a particular letter in the grid.
        /// </summary>
        /// <param name="button">The button in the grid that the otions are being set for</param>
        public LetterSelectForm(LetterButton button)
        {
            _button = button;
            InitializeComponent();

            ComBoxLetter.SelectedIndex = (int)_button.SelectedLetter;
            CheBoxIsRequired.Checked = _button.IsRequired;
            ComBoxPositionRestriction.SelectedIndex = (int)_button.Restriction;
        }



        /// <summary>
        /// The click event handler for the OK button. Takes the selected options and applies them to the button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            _button.SelectedLetter = (LetterUtil.Letter)ComBoxLetter.SelectedIndex;
            _button.IsRequired = CheBoxIsRequired.Checked;
            _button.Restriction = (PositionRestriction)ComBoxPositionRestriction.SelectedIndex;
            _button.Text = LetterButton.GetText(_button);

            if (_button.IsRequired)
            {
                _button.BackColor = SystemColors.ControlDark;
            }
            else
            {
                _button.BackColor = SystemColors.Control;
            }
        }
    }
}
