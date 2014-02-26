using System;
using System.Drawing;
using System.Windows.Forms;
using WordSolver.Grid;
using WordSolver.Util;

namespace WordSolver.Gui
{
    /// <summary>
    /// Extension to the standard Button component for convenience of use at runtime
    /// </summary>
    public class LetterButton : Button
    {
        /// <summary>
        /// Is the button representing an add letter button. i.e. does it have a "+" and when the user
        /// clicks on it, should it add a new letter ot the grid.
        /// </summary>
        public bool IsAddLetter
        {
            get
            {
                return _isAddLetter;
            }

            set
            {
                if (_isAddLetter == value)
                {
                    return;
                }
                _isAddLetter = value;
                if (value)
                {
                    this.Text = "+";
                    this.Click -= SelectFormOnClick;
                    this.Click += AddLetterOnClick;
                    this.ContextMenuStrip = null;
                }
                else
                {
                    this.Text = GetText(this);
                    this.Click -= AddLetterOnClick;
                    this.Click += SelectFormOnClick;
                    this.ContextMenuStrip = this._contextMenu;
                }
            }
        }
        /// <summary>
        /// The private data store for the IsAddLetter property
        /// </summary>
        private bool _isAddLetter;

        /// <summary>
        /// Whether this letter is required to be used in a word
        /// </summary>
        public bool IsRequired = false;

        /// <summary>
        /// The restriction of the position of the letter in the word
        /// </summary>
        public PositionRestriction Restriction = PositionRestriction.NONE;

        /// <summary>
        /// The selected letter to display on the button
        /// </summary>
        public LetterUtil.Letter SelectedLetter
        {
            get
            {
                return _selectedLetter;
            }
            set
            {
                _selectedLetter = value;
                this.Text = GetText(this);
            }
        }
        /// <summary>
        /// The private data store for the SelectedLetter property
        /// </summary>
        private LetterUtil.Letter _selectedLetter = LetterUtil.Letter.A;

        

        /// <summary>
        /// A reference to the grid which this button is being displayed in
        /// </summary>
        private LetterGrid _parentGrid;

        /// <summary>
        /// The context menu to be displayed on a right-click on this button
        /// </summary>
        private ContextMenuStrip _contextMenu;



        /// <summary>
        /// Standard constructor. Initialises all the event handlers and appearance of the button
        /// </summary>
        /// <param name="x">The x-coordinate of the button in the grid</param>
        /// <param name="y">The y-coordinate of the button in the grid</param>
        public LetterButton(int x, int y) : base()
        {
            _isAddLetter = false;

            this.Size = new System.Drawing.Size(100, 100);
            this.Font = new Font("Calibri", 30, FontStyle.Bold);
            this.Text = "A";

            this.Location = new Point(105 * x, 105 * y);

            this.Click += SelectFormOnClick;
            this.MouseEnter += mouseEnter;
            this.MouseLeave += mouseLeave;
            this.KeyDown += keyDown;
            this.UseVisualStyleBackColor = false;
            this._contextMenu = new LetterButtonContextMenu(this);
        }



        /// <summary>
        /// Remove this letter from the grid
        /// </summary>
        public void Remove()
        {
            _parentGrid.RemoveLetter(this);
        }

        /// <summary>
        /// Synchronise this button with a LetterGrid and sets options on this button
        /// </summary>
        /// <param name="parentGrid">The grid which this button is being displayed on</param>
        /// <returns>A reference to this button for method chaining</returns>
        public LetterButton Sync(LetterGrid parentGrid)
        {
            _parentGrid = parentGrid;
            if (_parentGrid.Options.IsAnagram && !_isAddLetter)
            {
                this.ContextMenuStrip = _contextMenu;
            }
            return this;
        }



        /// <summary>
        /// The click handler to be invoked when the button is supposed to add a letter to the grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddLetterOnClick(object sender, EventArgs e)
        {
            this.IsAddLetter = false;
            _parentGrid.AddLetter();
        }

        /// <summary>
        /// Key press event handler. When the user's mouse is focused on the button and the user presses a button this is called
        /// to be an easy way to set the selected letter on the button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z)
            {
                switch (e.KeyCode)
                {
                    case Keys.A:
                        SelectedLetter = LetterUtil.Letter.A;
                        this.Text = "A";
                        break;
                    case Keys.B:
                        SelectedLetter = LetterUtil.Letter.B;
                        this.Text = "B";
                        break;
                    case Keys.C:
                        SelectedLetter = LetterUtil.Letter.C;
                        this.Text = "C";
                        break;
                    case Keys.D:
                        SelectedLetter = LetterUtil.Letter.D;
                        this.Text = "D";
                        break;
                    case Keys.E:
                        SelectedLetter = LetterUtil.Letter.E;
                        this.Text = "E";
                        break;
                    case Keys.F:
                        SelectedLetter = LetterUtil.Letter.F;
                        this.Text = "F";
                        break;
                    case Keys.G:
                        SelectedLetter = LetterUtil.Letter.G;
                        this.Text = "G";
                        break;
                    case Keys.H:
                        SelectedLetter = LetterUtil.Letter.H;
                        this.Text = "H";
                        break;
                    case Keys.I:
                        SelectedLetter = LetterUtil.Letter.I;
                        this.Text = "I";
                        break;
                    case Keys.J:
                        SelectedLetter = LetterUtil.Letter.J;
                        this.Text = "J";
                        break;
                    case Keys.K:
                        SelectedLetter = LetterUtil.Letter.K;
                        this.Text = "K";
                        break;
                    case Keys.L:
                        SelectedLetter = LetterUtil.Letter.L;
                        this.Text = "L";
                        break;
                    case Keys.M:
                        SelectedLetter = LetterUtil.Letter.M;
                        this.Text = "M";
                        break;
                    case Keys.N:
                        SelectedLetter = LetterUtil.Letter.N;
                        this.Text = "N";
                        break;
                    case Keys.O:
                        SelectedLetter = LetterUtil.Letter.O;
                        this.Text = "O";
                        break;
                    case Keys.P:
                        SelectedLetter = LetterUtil.Letter.P;
                        this.Text = "P";
                        break;
                    case Keys.Q:
                        SelectedLetter = LetterUtil.Letter.Q;
                        this.Text = "Q";
                        break;
                    case Keys.R:
                        SelectedLetter = LetterUtil.Letter.R;
                        this.Text = "R";
                        break;
                    case Keys.S:
                        SelectedLetter = LetterUtil.Letter.S;
                        this.Text = "S";
                        break;
                    case Keys.T:
                        SelectedLetter = LetterUtil.Letter.T;
                        this.Text = "T";
                        break;
                    case Keys.U:
                        SelectedLetter = LetterUtil.Letter.U;
                        this.Text = "U";
                        break;
                    case Keys.V:
                        SelectedLetter = LetterUtil.Letter.V;
                        this.Text = "V";
                        break;
                    case Keys.W:
                        SelectedLetter = LetterUtil.Letter.W;
                        this.Text = "W";
                        break;
                    case Keys.X:
                        SelectedLetter = LetterUtil.Letter.X;
                        this.Text = "X";
                        break;
                    case Keys.Y:
                        SelectedLetter = LetterUtil.Letter.Y;
                        this.Text = "Y";
                        break;
                    case Keys.Z:
                        SelectedLetter = LetterUtil.Letter.Z;
                        this.Text = "Z";
                        break;
                }
            }
        }

        /// <summary>
        /// Mouse entry event handler. This is called whenever the user's mouse enters the button's area and is used
        /// to set the correct background colour as well as to focus on the control so that key presses are captured.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mouseEnter(object sender, EventArgs e)
        {
            this.BackColor = SystemColors.ButtonHighlight;
            this.Focus();
        }

        /// <summary>
        /// Mouse leaving event handler. This is called whenever the user's mouse leaves the button's area and is used
        /// to restore the correct background colour.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mouseLeave(object sender, EventArgs e)
        {
            if (IsRequired)
            {
                this.BackColor = SystemColors.ControlDark;
            }
            else
            {
                this.BackColor = SystemColors.Control;
            }
        }

        /// <summary>
        /// Button click event handler when the button is not supposed to add a letter. Opens the LetterSelectForm 
        /// to select options to do with this button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectFormOnClick(object sender, EventArgs e)
        {
            new LetterSelectForm(this).ShowDialog();
        }

        

        /// <summary>
        /// Convenience method for getting the text to be displayed on the button
        /// </summary>
        /// <param name="button">The button which the text will be displayed on</param>
        /// <returns>The text that should be shown on the button</returns>
        public static String GetText(LetterButton button)
        {
            if (button.IsAddLetter)
            {
                return "+";
            }

            String text = LetterUtil.ConvertToString(button.SelectedLetter);

            switch (button.Restriction)
            {
                case PositionRestriction.START:
                    text += "-";
                    break;
                case PositionRestriction.END:
                    text = "-" + text;
                    break;
            }

            return text;
        }
    }
}
