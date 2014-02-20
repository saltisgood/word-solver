﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using WordSolver.Util;
using WordSolver.Grid;

namespace WordSolver.Gui
{
    /// <summary>
    /// Extension to the standard Button component for convenience of use at runtime
    /// </summary>
    public class LetterButton : Button
    {
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


        private LetterUtil.Letter _selectedLetter = LetterUtil.Letter.A;

        /// <summary>
        /// Whether this letter is required to be used in a word
        /// </summary>
        public bool IsRequired = false;
        /// <summary>
        /// The restriction of the position of the letter in the word
        /// </summary>
        public PositionRestriction Restriction = PositionRestriction.NONE;

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
        private bool _isAddLetter;

        private LetterGrid ParentGrid;

        private ContextMenuStrip _contextMenu;

        /// <summary>
        /// Standard constructor. Initialises all the event handlers and appearance of the button
        /// </summary>
        /// <param name="x">The x-coordinate of the button in the grid</param>
        /// <param name="y">The y-coordinate of the button in the grid</param>
        public LetterButton(int x, int y, LetterGrid grid) : base()
        {
            ParentGrid = grid;
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
            this._contextMenu = this.ContextMenuStrip = new LetterButtonContextMenu(this);
        }

        /// <summary>
        /// Button click event handler. Opens the LetterSelectForm to select options to do with this button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectFormOnClick(object sender, EventArgs e)
        {
            new LetterSelectForm(this).ShowDialog();
        }

        private void AddLetterOnClick(object sender, EventArgs e)
        {
            this.IsAddLetter = false;
            ParentGrid.AddLetter();
        }

        /// <summary>
        /// Remove this letter from the grid
        /// </summary>
        public void Remove()
        {
            ParentGrid.RemoveLetter(this);
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
