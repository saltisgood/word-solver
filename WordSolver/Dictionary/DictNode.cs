using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using WordSolver.Grid;
using WordSolver.Util;

namespace WordSolver.Dictionary
{
    /// <summary>
    /// A class for a node in the dictionary tree
    /// </summary>
    public class DictNode : TreeTraverse
    {
        /// <summary>
        /// The char representation of the letter at this node
        /// </summary>
        public char Letter
        {
            get;
            private set;
        }

        /// <summary>
        /// The Letter enum representation of the letter at this node
        /// </summary>
        public LetterUtil.Letter LetterEnum
        {
            get;
            private set;
        }

        /// <summary>
        /// Cached value for the value of all the letters up to and including this node
        /// </summary>
        private String _word;

        /// <summary>
        /// Whether this node represents a word (i.e. it's a possible terminating node)
        /// </summary>
        private bool IsWord;
        
        /// <summary>
        /// The depth of the node in the tree
        /// </summary>
        private int Depth;

        /// <summary>
        /// Constructor used when there is no parent node, i.e. the root of the tree
        /// </summary>
        /// <param name="subword">The enumeration of the word to populate the tree</param>
        /// <param name="depth">The depth of the node</param>
        public DictNode(CharEnumerator subword, int depth) : base()
        {
            Depth = depth;
            Letter = subword.Current;
            LetterEnum = LetterUtil.GetLetter(Letter);

            if (subword.MoveNext())
            {
                Children.Add(new DictNode(subword, Depth + 1, this));
                IsWord = false;
            }
            else
            {
                IsWord = true;
            }
        }

        /// <summary>
        /// Constructor used with a parent node
        /// </summary>
        /// <param name="subword">The enumeration of the word to populate the tree</param>
        /// <param name="depth">The depth of the node</param>
        /// <param name="parent">The parent node</param>
        public DictNode(CharEnumerator subword, int depth, DictNode parent) : this(subword, depth)
        {
            Parent = parent;
        }

        /// <summary>
        /// Add a word to the node.
        /// </summary>
        /// <param name="subword">The enumeration of the word to be added</param>
        /// <returns>True if the word didn't already exist, false if the word already existed</returns>
        public bool AddWord(CharEnumerator subword)
        {
            if (!subword.MoveNext())
            {
                if (IsWord)
                {
                    return false;
                }
                IsWord = true;
                return true;
            }

            char c = subword.Current;
            foreach (DictNode n in Children)
            {
                if (n.Letter == c)
                {
                    return n.AddWord(subword);
                }
            }

            Children.Add(new DictNode(subword, Depth + 1, this));
            return true;
        }

        /// <summary>
        /// Find whether a word exists in this node and its subnodes
        /// </summary>
        /// <param name="subword">The enumeration of the word to find</param>
        /// <returns>True if the word exists, false if not</returns>
        public bool FindWord(CharEnumerator subword)
        {
            if (!subword.MoveNext())
            {
                return IsWord;
            }

            char c = subword.Current;
            foreach (DictNode n in Children)
            {
                if (n.Letter == c)
                {
                    return n.FindWord(subword);
                }
            }

            return false;
        }

        /// <summary>
        /// Find all words in the sub-tree from here
        /// </summary>
        /// <param name="node">The node in the LetterGrid that should align with this node in the dictionary tree</param>
        public void FindAllWords(LetterGrid.Node node)
        {
            if (IsWord && Depth >= (DictTree.MIN_WORD_LENGTH - 1))
            {
                Solutions.AddWord(this.ToString());
            }

            node.IsUsed = true;
            foreach (LetterGrid.Node n in node.AdjacentNodes)
            {
                if (!n.IsUsed)
                {
                    foreach (DictNode n2 in Children)
                    {
                        if (n.Letter == n2.LetterEnum)
                        {
                            n2.FindAllWords(n);
                            n.IsUsed = false;
                            break;
                        }
                    }
                }
            }
        }

        public void WriteToStream(StreamWriter sw, bool sortFirst)
        {
            if (sortFirst)
            {
                Children.Sort(NodeSorter.GetInstance());
            }

            if (IsWord)
            {
                sw.WriteLine(this.ToString());
            }

            foreach (DictNode n in Children)
            {
                n.WriteToStream(sw, sortFirst);
            }
        }

        public override string ToString()
        {
            if (_word == null)
            {
                if (Parent != null)
                {
                    _word = Parent.ToString() + Letter;
                }
                else
                {
                    _word = Char.ToString(Letter);
                }
            }
            return _word;
        }

        public void WordSearch(List<String> solns)
        {
            if (IsWord)
            {
                solns.Add(this.ToString());
                if (solns.Count >= 100)
                {
                    return;
                }
            }

            foreach (DictNode n in Children)
            {
                n.WordSearch(solns);
            }
        }

        public void WordSearch(CharEnumerator wordEnum, List<String> solns)
        {
            if (!wordEnum.MoveNext())
            {
                if (IsWord)
                {
                    solns.Add(this.ToString());
                    if (solns.Count >= 100)
                    {
                        return;
                    }
                }

                foreach (DictNode n in Children)
                {
                    n.WordSearch(solns);
                    if (solns.Count >= 100)
                    {
                        return;
                    }
                }
                return;
            }

            LetterUtil.Letter letter = LetterUtil.GetLetter(wordEnum.Current);
            foreach (DictNode n in Children)
            {
                if (letter == n.LetterEnum)
                {
                    n.WordSearch(wordEnum, solns);
                }
            }
        }
    }
}
