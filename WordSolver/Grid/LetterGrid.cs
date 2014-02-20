using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordSolver.Dictionary;
using WordSolver.Grid;
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
        /// The current size of the grid in the x-direction
        /// </summary>
        public int X { get; private set; }
        /// <summary>
        /// The current size of the grid in the y-direction
        /// </summary>
        public int Y { get; private set; }
        public GameOptions Options { get; private set; }

        /// <summary>
        /// The 2-D array of buttons that are used in this grid
        /// </summary>
        private LetterButton[][] Buttons;
        private Node[][] NodeList;
        private MainWindow ParentWindow;

        /// <summary>
        /// Constructor. Nothing much to say.
        /// </summary>
        /// <param name="x">The initial size of the grid in the x-direction, must be less than GRID_MAX_X</param>
        /// <param name="y">The initial size of the grid in the y-direction, must be less than GRID_MAX_Y</param>
        public LetterGrid(int x, int y, MainWindow window)
        {
            ParentWindow = window;

            if (x > GRID_MAX_X || y > GRID_MAX_Y)
            {
                throw new ArgumentOutOfRangeException("X or Y values greater than allowed size");
            }
            X = x;
            Y = y;
            Buttons = new LetterButton[GRID_MAX_Y][];
            for (int i = 0; i < GRID_MAX_Y; i++)
            {
                Buttons[i] = new LetterButton[GRID_MAX_X];
                for (int j = 0; j < GRID_MAX_X; j++)
                {
                    Buttons[i][j] = new LetterButton(j, i, this);
                }
            }

            Options = new GameOptions(false);
        }

        /// <summary>
        /// Constructor used for an empty anagram initialisation
        /// </summary>
        //public LetterGrid(MainWindow window) : this(GRID_MAX_X, GRID_MAX_Y, window)
        public LetterGrid(MainWindow window) : this(string.Empty, window)
        {
            /* Options = new GameOptions(0);
            X = 0;
            Y = 0; */
        }

        /// <summary>
        /// Constructor used when initialising an anagram with a given word
        /// </summary>
        /// <param name="word"></param>
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
            X = x;
            Y = y;
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
            SetButtonValue(count % X, count / X, letter);
        }

        private void SetIsAddLetter(int x, int y, bool isAdd)
        {
            Buttons[y][x].IsAddLetter = true;
        }

        private void SetIsAddLetter(int count, bool isAdd)
        {
            SetIsAddLetter(count % X, count / X, isAdd);
        }

        /// <summary>
        /// Get the buttons so that they can be added using Control.AddRange(Control[])
        /// </summary>
        /// <returns>The array of buttons</returns>
        public Control[] GetControls()
        {
            if (!Options.IsAnagram)
            {
                Control[] controls = new Control[X * Y];

                int i = 0;
                for (int x = 0; x < X; x++)
                {
                    for (int y = 0; y < Y; y++)
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
                            Y = y + 1;
                            return controls;
                        }
                    }
                }
                return controls;
            }
        }

        /// <summary>
        /// Find all the words in the given dictionary tree
        /// </summary>
        /// <param name="tree">The tree to search</param>
        /// <param name="options">The options that the game is played with</param>
        public void FindWords(DictTree tree)
        {
            NodeList = new Node[Y][];
            for (int y = 0; y < Y; y++)
            {
                NodeList[y] = new Node[X];
                for (int x = 0; x < X; x++)
                {
                    NodeList[y][x] = new Node(this, Buttons[y][x]);
                }
            }

            SetupAdjNodes(Options.ConnectingLetters);
            Solve(tree);
        }

        /// <summary>
        /// Setup the adjacent node list in the 2-D node list. These are the nodes that are directly
        /// adjacent to each node, cached for speed.
        /// </summary>
        private void SetupAdjNodes(bool isConnected)
        {
            if (isConnected)
            {
                #region lots of space
                for (int y = 0; y < Y; y++)
                {
                    for (int x = 0; x < X; x++)
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

                            if (x < (X - 1))
                            {
                                if (NodeList[y - 1][x + 1].Restriction != PositionRestriction.START)
                                {
                                    NodeList[y][x].AddAdjacentNode(NodeList[y - 1][x + 1]);
                                }
                            }
                        }

                        if (y < (Y - 1))
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

                            if (x < (X - 1))
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

                        if (x < (X - 1))
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
                for (int y = 0; y < Y; y++)
                {
                    for (int x = 0; x < X; x++)
                    {
                        if (NodeList[y][x].Restriction == PositionRestriction.END)
                        {
                            continue;
                        }

                        for (int y1 = 0; y1 < Y; y1++)
                        {
                            for (int x1 = 0; x1 < X; x1++)
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
        /// <param name="tree">The dictionary tree to search</param>
        private void Solve(DictTree tree)
        {
            for (int y = 0; y < Y; y++)
            {
                for (int x = 0; x < X; x++)
                {
                    tree.FindAllWords(NodeList[y][x]);
                }
            }
        }

        public bool CheckForMandatoryNodes()
        {
            foreach (Node[] nodes in NodeList)
            {
                foreach (Node n in nodes)
                {
                    if (n.IsMandatory && !n.IsUsed())
                    {
                        return false;
                    }
                }
            }
            return true;
        }

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
            for (; y < Y; y++)
            {
                for (x = 0; x < X; x++)
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

            for (; x < X; x++)
            {
                if (x == X - 1)
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

            for (y++; y < Y; y++)
            {
                for (x = 0; x < X; x++)
                {
                    if (x == X - 1)
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
        /// A helper node class for nodes in the grid of letters, not the dictionary tree
        /// </summary>
        public class Node
        {
            /// <summary>
            /// A boolean that is used to determine whether a node has been used or is still available for use.
            /// Should be used when deciding whether moving to this adjacent node is a valid move or not.
            /// </summary>
            //public bool IsUsed = false;
            
            public bool IsMandatory { get; private set; }
            public LetterGrid ParentGrid { get; private set; }
            public PositionRestriction Restriction { get; private set; }

            /// <summary>
            /// The Letter enum representatino of this node
            /// </summary>
            private LetterUtil.Letter Letter;
            /// <summary>
            /// A list of the other nodes in the grid that are directly adjacent to this one
            /// </summary>
            private List<Node> AdjacentNodes;
            private int UseCount = 0;
            private int LetterLength;

            /// <summary>
            /// Constructor.
            /// </summary>
            /// <param name="x">The X-coordinate of this node in the grid</param>
            /// <param name="y">The Y-coordinate of this node in the grid</param>
            /// <param name="letter">The Letter enum to be used for this node</param>
            public Node(LetterGrid parentGrid, LetterUtil.Letter letter, bool isMandatory, PositionRestriction restriction)
            {
                ParentGrid = parentGrid;
                Letter = letter;
                AdjacentNodes = new List<Node>();
                IsMandatory = isMandatory;
                Restriction = restriction;
                LetterLength = LetterUtil.GetLetterLength(Letter);
            }

            public Node(LetterGrid parentGrid, LetterButton button) : this(parentGrid, button.SelectedLetter, button.IsRequired, button.Restriction)
            {
            }

            /// <summary>
            /// Add a node to the list of adjacent nodes
            /// </summary>
            /// <param name="node">The adjacent node to add</param>
            public void AddAdjacentNode(Node node)
            {
                AdjacentNodes.Add(node);
            }

            /// <summary>
            /// The string representation of this node. (Is just the letter)
            /// </summary>
            /// <returns>The letter of the node</returns>
            public override String ToString()
            {
                return LetterUtil.ConvertToString(Letter);
            }

            private bool IsDigram()
            {
                return LetterLength > 1;
            }

            public LetterUtil.Letter GetLetter()
            {
                if (IsDigram())
                {
                    return LetterUtil.SplitDigram(Letter, UseCount);
                }
                else
                {
                    return Letter;
                }
            }

            public bool IsUsed()
            {
                return UseCount >= LetterLength;
            }

            public List<Node> GetAdjacentNodes()
            {
                if (IsDigram() && UseCount < LetterLength)
                {
                    List<Node> fakeList = new List<Node>();
                    fakeList.Add(this);
                    return fakeList;
                }
                else
                {
                    return AdjacentNodes;
                }
            }

            public bool UsedUp()
            {
                return UseCount >= LetterLength;
            }

            public void Use()
            {
                UseCount++;
            }

            public void Release()
            {
                UseCount--;
            }
        }
    }
}
