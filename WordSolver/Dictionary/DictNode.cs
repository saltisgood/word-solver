using System;
using System.Collections.Generic;
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
        private const int WORD_SEARCH_LIMIT = 100;

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
        /// The depth of the node in the tree
        /// </summary>
        private readonly int _depth;

        /// <summary>
        /// Whether this node represents a word (i.e. it's a possible terminating node)
        /// </summary>
        private bool _isWord;

        /// <summary>
        /// Cached value for the value of all the letters up to and including this node
        /// </summary>
        private String _word;

        /// <summary>
        /// Constructor used when there is no parent node, i.e. the root of the tree
        /// </summary>
        /// <param name="subword">The enumeration of the word to populate the tree</param>
        /// <param name="depth">The depth of the node</param>
        /// <param name="parent">The node immediately above this node in the tree</param>
        public DictNode(CharEnumerator subword, int depth, TreeTraverse parent) : base(parent)
        {
            _depth = depth;
            Letter = subword.Current;
            LetterEnum = LetterUtil.GetLetter(Letter);

            if (subword.MoveNext())
            {
                Children.Add(new DictNode(subword, _depth + 1, this));
                _isWord = false;
            }
            else
            {
                _isWord = true;
            }
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
                if (_isWord)
                {
                    return false;
                }
                _isWord = true;
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

            Children.Add(new DictNode(subword, _depth + 1, this));
            return true;
        }

        /// <summary>
        /// Find all words in the sub-tree from here
        /// </summary>
        /// <param name="node">The node in the LetterGrid that should align with this node in the dictionary tree</param>
        /// <param name="allowMultiWords">Allow matches which are made up of multiple words</param>
        /// <param name="soln">A partial solution to start with</param>
        public void FindAllWords(GridNode node, bool allowMultiWords, Solutions.PartialSoln soln = null)
        {
            node.Use();

            if (_isWord)
            {
                if (allowMultiWords)
                {
                    if (!node.ParentGrid.CheckForMandatoryNodes())
                    {
                        if (soln == null)
                        {
                            soln = new Solutions.PartialSoln();
                        }
                        this.Root.FindAllWords(node, true, new Solutions.PartialSoln(soln, this.ToString()));
                    }
                    else
                    {
                        if (soln == null)
                        {
                            Solutions.AddWord(this.ToString());
                        }
                        else
                        {
                            Solutions.AddWord(new Solutions.PartialSoln(soln, this.ToString()));
                        }
                    }
                }
                else if (_depth >= (Properties.Settings.Default.MinWordLength - 1) && node.IsUsed && node.ParentGrid.CheckForMandatoryNodes())
                {
                    Solutions.AddWord(this.ToString());
                }
            }

            foreach (GridNode n in node.GetAdjacentNodes())
            {
                if (!n.IsUsed)
                {
                    foreach (DictNode n2 in Children)
                    {
                        if (n.GetLetter() == n2.LetterEnum)
                        {
                            n2.FindAllWords(n, allowMultiWords, new Solutions.PartialSoln(soln));
                            n.Release();
                            break;
                        }
                    }
                }
            }
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
                return _isWord;
            }

            char c = subword.Current;
// ReSharper disable once LoopCanBeConvertedToQuery
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
        /// Remove a partial word from the node and subnodes
        /// </summary>
        /// <param name="wordEnum">The enumerated word to remove</param>
        /// <returns>True if the word was removed, false if it couldn't be found</returns>
        public bool RemoveWord(CharEnumerator wordEnum)
        {
            if (!wordEnum.MoveNext())
            {
                bool wasWord = _isWord;
                _isWord = false;
                return wasWord;
            }

            char c = wordEnum.Current;

            foreach (DictNode n in Children)
            {
                if (n.Letter == c)
                {
                    return n.RemoveWord(wordEnum);
                }
            }
            return false;
        }

        /// <summary>
        /// Append all words (up to the value of WORD_SEARCH_LIMIT) and append them to the list parameter
        /// </summary>
        /// <param name="solns">The list of solutions to be added to</param>
        public void WordSearch(List<String> solns)
        {
            if (_isWord)
            {
                solns.Add(this.ToString());
                if (solns.Count >= WORD_SEARCH_LIMIT)
                {
                    return;
                }
            }

            foreach (DictNode n in Children)
            {
                n.WordSearch(solns);
            }
        }

        /// <summary>
        /// Search this node for all partial matches of a word (up to the value of WORD_SEARCH_LIMIT) and append them to the list parameter
        /// </summary>
        /// <param name="wordEnum">The partial word to match</param>
        /// <param name="solns">The list of solutions to be added to</param>
        public void WordSearch(CharEnumerator wordEnum, List<String> solns)
        {
            if (!wordEnum.MoveNext())
            {
                if (_isWord)
                {
                    solns.Add(this.ToString());
                    if (solns.Count >= WORD_SEARCH_LIMIT)
                    {
                        return;
                    }
                }

                foreach (DictNode n in Children)
                {
                    n.WordSearch(solns);
                    if (solns.Count >= WORD_SEARCH_LIMIT)
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

        /// <summary>
        /// Serialise the node as part of a full tree write
        /// </summary>
        /// <param name="sw">The stream to write to</param>
        /// <param name="sortFirst">True to alphabetically sort the child nodes first</param>
        public void WriteToStream(StreamWriter sw, bool sortFirst)
        {
            if (sortFirst)
            {
                Children.Sort(NodeSorter.GetInstance());
            }

            if (_isWord)
            {
                sw.WriteLine(this.ToString());
            }

            foreach (DictNode n in Children)
            {
                n.WriteToStream(sw, sortFirst);
            }
        }

        /// <summary>
        /// Override of Object.ToString() that is used to provide a human readable representation of the node
        /// </summary>
        /// <returns>The word representation of the node</returns>
        public override string ToString()
        {
            if (_word == null)
            {
                if (Parent as DictNode != null)
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
    }
}
