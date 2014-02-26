using System;
using System.Collections.Generic;
using WordSolver.Gui;
using WordSolver.Util;

namespace WordSolver.Grid
{
    /// <summary>
    /// A helper node class for nodes in the grid of letters, not the dictionary tree
    /// </summary>
    public class GridNode
    {
        /// <summary>
        /// Is this node in the grid required to be used
        /// </summary>
        public bool IsMandatory { get; private set; }

        /// <summary>
        /// Has this node been fully used up (i.e. if it's a multi-letter node, has it been used that
        /// many times?)
        /// </summary>
        public bool IsUsed
        {
            get
            {
                return UseCount >= LetterLength;
            }
        }

        /// <summary>
        /// The parent grid of this node
        /// </summary>
        public LetterGrid ParentGrid { get; private set; }

        /// <summary>
        /// Any restrictions on the use of this node
        /// </summary>
        public PositionRestriction Restriction { get; private set; }



        /// <summary>
        /// A list of the other nodes in the grid that are directly adjacent to this one
        /// </summary>
        private List<GridNode> AdjacentNodes;

        /// <summary>
        /// The Letter enum representation of this node
        /// </summary>
        private LetterUtil.Letter Letter;

        /// <summary>
        /// The letter length of this node (to account for di/trigrams)
        /// </summary>
        private int LetterLength;

        /// <summary>
        /// The number of uses of this node (to account for di/trigrams)
        /// </summary>
        private int UseCount = 0;
        


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="parentGrid">The parent grid for the node</param>
        /// <param name="letter">The letter enum used for the node</param>
        /// <param name="isMandatory">Is the node required to be used in word searches</param>
        /// <param name="restriction">The restrictions on the use of this node</param>
        public GridNode(LetterGrid parentGrid, LetterUtil.Letter letter, bool isMandatory, PositionRestriction restriction)
        {
            ParentGrid = parentGrid;
            Letter = letter;
            AdjacentNodes = new List<GridNode>();
            IsMandatory = isMandatory;
            Restriction = restriction;
            LetterLength = LetterUtil.GetLetterLength(Letter);

            if (ParentGrid.Options.IsAnagram)
            {
                IsMandatory = true;
            }
        }

        /// <summary>
        /// Convenience constructor to go straight from a button
        /// </summary>
        /// <param name="parentGrid">The parent grid for the node</param>
        /// <param name="button">The button to convert</param>
        public GridNode(LetterGrid parentGrid, LetterButton button)
            : this(parentGrid, button.SelectedLetter, button.IsRequired, button.Restriction)
        {
        }



        /// <summary>
        /// Add a node to the list of adjacent nodes
        /// </summary>
        /// <param name="node">The adjacent node to add</param>
        public void AddAdjacentNode(GridNode node)
        {
            AdjacentNodes.Add(node);
        }

        /// <summary>
        /// Get the list of nodes that are adjacent to this one. If this is a multi-letter node then it may 
        /// return a list with just itself as a kind of virtual node.
        /// </summary>
        /// <returns>The list of adjacent nodes</returns>
        public List<GridNode> GetAdjacentNodes()
        {
            if (IsDigram() && UseCount < LetterLength)
            {
                List<GridNode> fakeList = new List<GridNode>();
                fakeList.Add(this);
                return fakeList;
            }
            else
            {
                return AdjacentNodes;
            }
        }
        
        /// <summary>
        /// Get the letter enum representation for this node. If this is a multi-letter node, it will
        /// return the current position in the di/trigram
        /// </summary>
        /// <returns>The letter in enum form</returns>
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
        
        /// <summary>
        /// Release a node from use
        /// </summary>
        public void Release()
        {
            UseCount--;
        }

        /// <summary>
        /// "Use" a node. This means you are searching "down-stream" from this node in the tree search of
        /// adjacent nodes.
        /// </summary>
        public void Use()
        {
            UseCount++;
        }



        /// <summary>
        /// The string representation of this node. (Is just the letter)
        /// </summary>
        /// <returns>The letter of the node</returns>
        public override String ToString()
        {
            return LetterUtil.ConvertToString(Letter);
        }

        /// <summary>
        /// Is the node a di/trigram (multi-letter "letter")
        /// </summary>
        /// <returns></returns>
        private bool IsDigram()
        {
            return LetterLength > 1;
        }
    }
}
