using System;
using System.Windows.Forms;
using WordSolver.Gui;
using WordSolver.Util;

namespace WordSolver.Grid
{
    /// <summary>
    /// A representation of the grid of letters that the user has chosen
    /// </summary>
    public class LetterGrid
    {
        /// <summary>
        /// The max size of the grid in the x-direction
        /// </summary>
        public const int GRID_MAX_X = 4;

        /// <summary>
        /// The max size of the grid in the y-direction
        /// </summary>
        public const int GRID_MAX_Y = 4;



        /// <summary>
        /// The GameOptions used in this game
        /// </summary>
        public GameOptions Options { get; private set; }

        /// <summary>
        /// The current size of the grid in the x-direction
        /// </summary>
        public int SizeX { get; private set; }

        /// <summary>
        /// The current size of the grid in the y-direction
        /// </summary>
        public int SizeY { get; private set; }

        

        /// <summary>
        /// The 2-D array of buttons that are used in this grid
        /// </summary>
        private LetterButton[][] Buttons;

        /// <summary>
        /// The 2-D array of Nodes that represent the buttons in the grid
        /// </summary>
        private GridNode[][] NodeList;

        /// <summary>
        /// The MainWindow form associated with this grid
        /// </summary>
        private MainWindow ParentWindow;



        /// <summary>
        /// Constructor. Nothing much to say.
        /// </summary>
        /// <param name="x">The initial size of the grid in the x-direction, must be less than GRID_MAX_X</param>
        /// <param name="y">The initial size of the grid in the y-direction, must be less than GRID_MAX_Y</param>
        /// <param name="window">A reference to the parent form of this grid</param>
        public LetterGrid(int x, int y, MainWindow window)
        {
            ParentWindow = window;

            if (x > GRID_MAX_X || y > GRID_MAX_Y)
            {
                throw new ArgumentOutOfRangeException("X or Y values greater than allowed size");
            }
            SizeX = x;
            SizeY = y;

            Options = new GameOptions(false);

            Buttons = new LetterButton[GRID_MAX_Y][];
            for (int i = 0; i < GRID_MAX_Y; i++)
            {
                Buttons[i] = new LetterButton[GRID_MAX_X];
                for (int j = 0; j < GRID_MAX_X; j++)
                {
                    Buttons[i][j] = new LetterButton(j, i).Sync(this);
                }
            }

            
        }

        /// <summary>
        /// Constructor used for an empty anagram initialisation
        /// </summary>
        /// <param name="window">A reference to the parent form of this grid</param>
        public LetterGrid(MainWindow window) : this(string.Empty, window)
        {
        }

        /// <summary>
        /// Constructor used when initialising an anagram with a given word
        /// </summary>
        /// <param name="word">The word to initialise with</param>
        /// <param name="window">A reference to the parent form of this grid</param>
        public LetterGrid(String word, MainWindow window) : this(GRID_MAX_X, word.Length / GRID_MAX_X + (((word.Length % GRID_MAX_X) == 0) ? 0 : 1), window)
        {
            Options = new GameOptions(word.Length);

            CharEnumerator charEnum = word.GetEnumerator();
            int count = 0;
            while (charEnum.MoveNext())
            {
                SetButtonValue(count++, LetterUtil.GetLetter(charEnum.Current));
            }

            if (!Options.IsMaxAnagramLength)
            {
                SetIsAddLetter(count, true);
            }

            foreach (LetterButton[] buttons in Buttons)
            {
                foreach (LetterButton button in buttons)
                {
                    button.Sync(this);
                }
            }
        }


        /// <summary>
        /// Add a letter to the anagram (i.e. the user has clicked on the new letter button)
        /// </summary>
        public void AddLetter()
        {
            if (!Options.IsAnagram)
            {
                throw new InvalidOperationException("Letters can only be added in anagram mode!");
            }

            Options.AnagramLength++;
            if (!Options.IsMaxAnagramLength)
            {
                SetIsAddLetter(Options.AnagramLength, true);
            }

            ParentWindow.RefreshPanel();
        }

        /// <summary>
        /// Check whether all the required nodes have been used.
        /// </summary>
        /// <returns>True if all required nodes have been used, false otherwise</returns>
        public bool CheckForMandatoryNodes()
        {
            foreach (GridNode[] nodes in NodeList)
            {
                foreach (GridNode n in nodes)
                {
                    if (n.IsMandatory && !n.IsUsed)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Find all the possible words in the grid
        /// </summary>
        public void FindWords()
        {
            if (!Options.IsAnagram)
            {
                NodeList = new GridNode[SizeY][];
                for (int y = 0; y < SizeY; y++)
                {
                    NodeList[y] = new GridNode[SizeX];
                    for (int x = 0; x < SizeX; x++)
                    {
                        NodeList[y][x] = new GridNode(this, Buttons[y][x]);
                    }
                }
            }
            else
            {
                NodeList = new GridNode[1][];
                NodeList[0] = new GridNode[Options.AnagramLength];
                for (int i = 0; i < Options.AnagramLength; i++)
                {
                    NodeList[0][i] = new GridNode(this, GetButton(i));
                }
            }

            SetupAdjNodes(Options.AreConnectingLettersRequired);
            Solve();
        }

        /// <summary>
        /// Get the buttons so that they can be added using Control.AddRange(Control[])
        /// </summary>
        /// <returns>The array of buttons</returns>
        public Control[] GetControls()
        {
            if (!Options.IsAnagram)
            {
                Control[] controls = new Control[SizeX * SizeY];

                int i = 0;
                for (int x = 0; x < SizeX; x++)
                {
                    for (int y = 0; y < SizeY; y++)
                    {
                        controls[i++] = Buttons[y][x];
                    }
                }

                return controls;
            }
            else
            {
                int maxSize = (Options.AnagramLength + 1 <= GRID_MAX_X * GRID_MAX_Y) ? Options.AnagramLength + 1 : GRID_MAX_X * GRID_MAX_Y;
                Control[] controls = new Control[maxSize];
                int i = 0;
                for (int y = 0; y < GRID_MAX_Y; y++)
                {
                    for (int x = 0; x < GRID_MAX_X; x++)
                    {
                        controls[i++] = Buttons[y][x];
                        if (i == maxSize)
                        {
                            SizeY = y + 1;
                            return controls;
                        }
                    }
                }
                return controls;
            }
        }

        /// <summary>
        /// Remove a letter from the grid (i.e. the user has right-clicked and selected remove letter on a button)
        /// </summary>
        /// <param name="button">The button to be removed</param>
        public void RemoveLetter(LetterButton button)
        {
            if (!Options.IsAnagram)
            {
                throw new InvalidOperationException("Letters can only be removed in anagram mode!");
            }

            if (Options.AnagramLength-- == 0)
            {
                return;
            }

            bool found = false;
            int x = 0, y = 0;
            for (; y < SizeY; y++)
            {
                for (x = 0; x < SizeX; x++)
                {
                    if (Buttons[y][x] == button)
                    {
                        found = true;
                        break;
                    }
                }
                if (found)
                {
                    break;
                }
            }

            if (!found)
            {
                throw new ArgumentException("Button was not found in grid!");
            }

            for (; x < SizeX; x++)
            {
                if (x == SizeX - 1)
                {
                    Buttons[y][x].SelectedLetter = Buttons[y + 1][0].SelectedLetter;
                    Buttons[y][x].IsRequired = Buttons[y + 1][0].IsRequired;
                    Buttons[y][x].Restriction = Buttons[y + 1][0].Restriction;
                    if (Buttons[y][x].IsAddLetter = Buttons[y + 1][0].IsAddLetter)
                    {
                        ParentWindow.RefreshPanel();
                        return;
                    }
                }
                else
                {
                    Buttons[y][x].SelectedLetter = Buttons[y][x + 1].SelectedLetter;
                    Buttons[y][x].IsRequired = Buttons[y][x + 1].IsRequired;
                    Buttons[y][x].Restriction = Buttons[y][x + 1].Restriction;
                    if (Buttons[y][x].IsAddLetter = Buttons[y][x + 1].IsAddLetter)
                    {
                        ParentWindow.RefreshPanel();
                        return;
                    }
                }
            }

            for (y++; y < SizeY; y++)
            {
                for (x = 0; x < SizeX; x++)
                {
                    if (x == SizeX - 1)
                    {
                        Buttons[y][x].SelectedLetter = Buttons[y + 1][0].SelectedLetter;
                        Buttons[y][x].IsRequired = Buttons[y + 1][0].IsRequired;
                        Buttons[y][x].Restriction = Buttons[y + 1][0].Restriction;
                        if (Buttons[y][x].IsAddLetter = Buttons[y + 1][0].IsAddLetter)
                        {
                            ParentWindow.RefreshPanel();
                            return;
                        }
                    }
                    else
                    {
                        Buttons[y][x].SelectedLetter = Buttons[y][x + 1].SelectedLetter;
                        Buttons[y][x].IsRequired = Buttons[y][x + 1].IsRequired;
                        Buttons[y][x].Restriction = Buttons[y][x + 1].Restriction;
                        if (Buttons[y][x].IsAddLetter = Buttons[y][x + 1].IsAddLetter)
                        {
                            ParentWindow.RefreshPanel();
                            return;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Set the new grid size
        /// </summary>
        /// <param name="x">The new size of the grid in the x-direction, must be less than GRID_MAX_X</param>
        /// <param name="y">The new size of the grid in the y-direction, must be less than GRID_MAX_Y</param>
        public void SetGridSize(int x, int y)
        {
            if (x > GRID_MAX_X || y > GRID_MAX_Y)
            {
                throw new ArgumentOutOfRangeException("X or Y values greater than allowed size");
            }
            SizeX = x;
            SizeY = y;
        }

        /// <summary>
        /// Set the value of one of the buttons in the grid with a letter
        /// </summary>
        /// <param name="x">The x position of the button</param>
        /// <param name="y">The y position of the button</param>
        /// <param name="letter">The new letter value</param>
        public void SetButtonValue(int x, int y, LetterUtil.Letter letter)
        {
            Buttons[y][x].Text = LetterUtil.ConvertToString(letter);
            Buttons[y][x].SelectedLetter = letter;
        }

        /// <summary>
        /// Set the value of one of the buttons in the grid with a letter
        /// </summary>
        /// <param name="count">The 1-D position of the button</param>
        /// <param name="letter">The new letter value</param>
        public void SetButtonValue(int count, LetterUtil.Letter letter)
        {
            SetButtonValue(count % SizeX, count / SizeX, letter);
        }



        /// <summary>
        /// Convenience method for getting a button without having to constantly calculate the X and Y positions
        /// </summary>
        /// <param name="count">The 1-D count position of the button</param>
        /// <returns>The required button</returns>
        private LetterButton GetButton(int count)
        {
            return Buttons[count / SizeX][count % SizeX];
        }

        /// <summary>
        /// Set a button to represent "add letter" rather than an actual letter
        /// </summary>
        /// <param name="x">The x-position of the button</param>
        /// <param name="y">The y-position of the button</param>
        /// <param name="isAdd">Whether the button should be an "add letter"</param>
        private void SetIsAddLetter(int x, int y, bool isAdd)
        {
            Buttons[y][x].IsAddLetter = true;
        }

        /// <summary>
        /// Convenience call for SetIsAddLetter(int, int, bool) that only uses a 1-D count
        /// </summary>
        /// <param name="count">The 1-D position of the button</param>
        /// <param name="isAdd">Whether the button represents an "add letter" button or not</param>
        private void SetIsAddLetter(int count, bool isAdd)
        {
            SetIsAddLetter(count % SizeX, count / SizeX, isAdd);
        }

        /// <summary>
        /// Setup the adjacent node list in the 2-D node list. These are the nodes that are directly
        /// adjacent to each node, cached for speed. Note that this doesn't always refer to spatial adjacency but
        /// can be a theoretical representation as a generalisation of the original case.
        /// </summary>
        /// <param name="isConnected">Whether letters are required to be connected to each other in the grid</param>
        private void SetupAdjNodes(bool isConnected)
        {
            if (Options.IsAnagram)
            {
                for (int i = 0; i < Options.AnagramLength; i++)
                {
                    if (NodeList[0][i].Restriction == PositionRestriction.END)
                    {
                        continue;
                    }

                    for (int j = 0; j < Options.AnagramLength; j++)
                    {
                        if (i == j)
                        {
                            continue;
                        }

                        if (NodeList[0][j].Restriction != PositionRestriction.START)
                        {
                            NodeList[0][i].AddAdjacentNode(NodeList[0][j]);
                        }
                    }
                }
                return;
            }

            if (isConnected)
            {
                #region lots of space
                for (int y = 0; y < SizeY; y++)
                {
                    for (int x = 0; x < SizeX; x++)
                    {
                        if (NodeList[y][x].Restriction == PositionRestriction.END)
                        {
                            continue;
                        }
                        if (y != 0)
                        {
                            if (NodeList[y - 1][x].Restriction != PositionRestriction.START)
                            {
                                NodeList[y][x].AddAdjacentNode(NodeList[y - 1][x]);
                            }

                            if (x != 0)
                            {
                                if (NodeList[y - 1][x - 1].Restriction != PositionRestriction.START)
                                {
                                    NodeList[y][x].AddAdjacentNode(NodeList[y - 1][x - 1]);
                                }
                            }

                            if (x < (SizeX - 1))
                            {
                                if (NodeList[y - 1][x + 1].Restriction != PositionRestriction.START)
                                {
                                    NodeList[y][x].AddAdjacentNode(NodeList[y - 1][x + 1]);
                                }
                            }
                        }

                        if (y < (SizeY - 1))
                        {
                            if (NodeList[y + 1][x].Restriction != PositionRestriction.START)
                            {
                                NodeList[y][x].AddAdjacentNode(NodeList[y + 1][x]);
                            }

                            if (x != 0)
                            {
                                if (NodeList[y + 1][x - 1].Restriction != PositionRestriction.START)
                                {
                                    NodeList[y][x].AddAdjacentNode(NodeList[y + 1][x - 1]);
                                }
                            }

                            if (x < (SizeX - 1))
                            {
                                if (NodeList[y + 1][x + 1].Restriction != PositionRestriction.START)
                                {
                                    NodeList[y][x].AddAdjacentNode(NodeList[y + 1][x + 1]);
                                }
                            }
                        }

                        if (x != 0)
                        {
                            if (NodeList[y][x - 1].Restriction != PositionRestriction.START)
                            {
                                NodeList[y][x].AddAdjacentNode(NodeList[y][x - 1]);
                            }
                        }

                        if (x < (SizeX - 1))
                        {
                            if (NodeList[y][x + 1].Restriction != PositionRestriction.START)
                            {
                                NodeList[y][x].AddAdjacentNode(NodeList[y][x + 1]);
                            }
                        }
                    }
                }
                #endregion
            }
            else
            {
                #region Lots o' Loops
                for (int y = 0; y < SizeY; y++)
                {
                    for (int x = 0; x < SizeX; x++)
                    {
                        if (NodeList[y][x].Restriction == PositionRestriction.END)
                        {
                            continue;
                        }

                        for (int y1 = 0; y1 < SizeY; y1++)
                        {
                            for (int x1 = 0; x1 < SizeX; x1++)
                            {
                                if ((x == x1 && y == y1) || NodeList[y1][x1].Restriction == PositionRestriction.START)
                                {
                                    continue;
                                }
                                NodeList[y][x].AddAdjacentNode(NodeList[y1][x1]);
                            }
                        }
                    }
                }
                #endregion
            }
        }

        /// <summary>
        /// Perform the actual word search of the 2-D node array with the dictionary tree
        /// </summary>
        private void Solve()
        {
            foreach (GridNode[] nodes in NodeList)
            {
                foreach (GridNode n in nodes)
                {
                    ParentWindow.Tree.FindAllWords(n, Options.AreMultipleWordsAllowed);
                }
            }
        }
    }
}
