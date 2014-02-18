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

        /// <summary>
        /// The 2-D array of buttons that are used in this grid
        /// </summary>
        private LetterButton[][] Buttons;
        private Node[][] NodeList;

        /// <summary>
        /// Constructor. Nothing much to say.
        /// </summary>
        /// <param name="x">The initial size of the grid in the x-direction, must be less than GRID_MAX_X</param>
        /// <param name="y">The initial size of the grid in the y-direction, must be less than GRID_MAX_Y</param>
        public LetterGrid(int x, int y)
        {
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
                    Buttons[i][j] = new LetterButton(j, i);
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

        /// <summary>
        /// Get the buttons so that they can be added using Control.AddRange(Control[])
        /// </summary>
        /// <returns>The array of buttons</returns>
        public Control[] GetControls()
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

        /// <summary>
        /// Find all the words in the given dictionary tree
        /// </summary>
        /// <param name="tree">The tree to search</param>
        public void FindWords(DictTree tree, GameOptions options)
        {
            NodeList = new Node[Y][];
            for (int y = 0; y < Y; y++)
            {
                NodeList[y] = new Node[X];
                for (int x = 0; x < X; x++)
                {
                    NodeList[y][x] = new Node(this, x, y, Buttons[y][x].SelectedLetter, Buttons[y][x].IsRequired);
                }
            }

            SetupAdjNodes(options.IsAnagram);
            Solve(tree);
        }

        /// <summary>
        /// Setup the adjacent node list in the 2-D node list. These are the nodes that are directly
        /// adjacent to each node, cached for speed.
        /// </summary>
        private void SetupAdjNodes(bool isAnagram)
        {
            if (!isAnagram)
            {
                #region lots of space
                for (int y = 0; y < Y; y++)
                {
                    for (int x = 0; x < X; x++)
                    {
                        if (y != 0)
                        {
                            NodeList[y][x].AddAdjacentNode(NodeList[y - 1][x]);

                            if (x != 0)
                            {
                                NodeList[y][x].AddAdjacentNode(NodeList[y - 1][x - 1]);
                            }

                            if (x < (X - 1))
                            {
                                NodeList[y][x].AddAdjacentNode(NodeList[y - 1][x + 1]);
                            }
                        }

                        if (y < (Y - 1))
                        {
                            NodeList[y][x].AddAdjacentNode(NodeList[y + 1][x]);

                            if (x != 0)
                            {
                                NodeList[y][x].AddAdjacentNode(NodeList[y + 1][x - 1]);
                            }

                            if (x < (X - 1))
                            {
                                NodeList[y][x].AddAdjacentNode(NodeList[y + 1][x + 1]);
                            }
                        }

                        if (x != 0)
                        {
                            NodeList[y][x].AddAdjacentNode(NodeList[y][x - 1]);
                        }

                        if (x < (X - 1))
                        {
                            NodeList[y][x].AddAdjacentNode(NodeList[y][x + 1]);
                        }
                    }
                }
                #endregion
            }
            else
            {
                for (int y = 0; y < Y; y++)
                {
                    for (int x = 0; x < X; x++)
                    {
                        for (int y1 = 0; y1 < Y; y1++)
                        {
                            for (int x1 = 0; x1 < X; x1++)
                            {
                                if (x == x1 && y == y1)
                                {
                                    continue;
                                }
                                NodeList[y][x].AddAdjacentNode(NodeList[y1][x1]);
                            }
                        }
                    }
                }
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

        public bool CheckForMandatoryNodes(Node finalNode)
        {
            foreach (Node[] nodes in NodeList)
            {
                foreach (Node n in nodes)
                {
                    if (n.IsMandatory && !n.IsUsed && n != finalNode)
                    {
                        return false;
                    }
                }
            }
            return true;
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
            public bool IsUsed = false;

            /// <summary>
            /// The X-coordinate of this node in the grid
            /// </summary>
            public int X { get; private set; }
            /// <summary>
            /// The Y-coordinate of this node in the grid
            /// </summary>
            public int Y { get; private set; }
            /// <summary>
            /// The Letter enum representatino of this node
            /// </summary>
            public LetterUtil.Letter Letter { get; private set; }
            /// <summary>
            /// A list of the other nodes in the grid that are directly adjacent to this one
            /// </summary>
            public List<Node> AdjacentNodes { get; private set; }
            public bool IsMandatory { get; private set; }
            public LetterGrid ParentGrid { get; private set; }

            /// <summary>
            /// Constructor.
            /// </summary>
            /// <param name="x">The X-coordinate of this node in the grid</param>
            /// <param name="y">The Y-coordinate of this node in the grid</param>
            /// <param name="letter">The Letter enum to be used for this node</param>
            public Node(LetterGrid parentGrid, int x, int y, LetterUtil.Letter letter, bool isMandatory)
            {
                ParentGrid = parentGrid;
                X = x;
                Y = y;
                Letter = letter;
                AdjacentNodes = new List<Node>();
                IsMandatory = isMandatory;
            }

            public Node(LetterGrid parentGrid, int x, int y, LetterButton button) : this(parentGrid, x, y, button.SelectedLetter, button.IsRequired)
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
        }
    }
}
