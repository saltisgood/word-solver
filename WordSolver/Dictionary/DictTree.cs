﻿using System;
using System.Collections.Generic;
using System.IO;
using WordSolver.Grid;
using WordSolver.Util;

namespace WordSolver.Dictionary
{
    /// <summary>
    /// Class for holding the dictionary tree
    /// </summary>
    public class DictTree : TreeTraverse
    {
        /// <summary>
        /// The total word count in the dictionary
        /// </summary>
        public int WordCount
        {
            get;
            private set;
        }

        /// <summary>
        /// Normal constructor
        /// </summary>
        public DictTree() : base()
        {
            WordCount = 0;
        }

        /// <summary>
        /// Add a word to the dictionary
        /// </summary>
        /// <param name="word">The word to be added</param>
        /// <returns>True if it's a new world, false if the word already exists</returns>
        public bool AddWord(String word)
        {
            CharEnumerator charEnum = word.GetEnumerator();
            if (!charEnum.MoveNext())
            {
                return false;
            }

            char c = charEnum.Current;
            foreach (DictNode n in Children) 
            {
                if (n.Letter == c)
                {
                    if (n.AddWord(charEnum))
                    {
                        WordCount++;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            Children.Add(new DictNode(charEnum, 0, this));
            WordCount++;
            return true;
        }

        /// <summary>
        /// Find all the words in the dictionary given a starting node in the LetterGrid
        /// </summary>
        /// <param name="node">The node in the LetterGrid to start with</param>
        /// <param name="allowMultiWords">True to allow matches made up of multiple words</param>
        public void FindAllWords(GridNode node, bool allowMultiWords)
        {
            foreach (DictNode n in Children)
            {
                if (n.LetterEnum == node.GetLetter())
                {
                    n.FindAllWords(node, allowMultiWords);
                    node.Release();
                    break;
                }
            }
        }

        /// <summary>
        /// Find all the words in the dictionary given a starting node in the LetterGrid and a partially completed solution.
        /// i.e. this method is used for adding on to an already found word
        /// </summary>
        /// <param name="node">The node in the LetterGrid to start with</param>
        /// <param name="allowMultiWords">True to allow matches made up of multiple words</param>
        /// <param name="soln">The partial solution to add to</param>
        public void FindAllWords(GridNode node, bool allowMultiWords, Solutions.PartialSoln soln)
        {
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
        /// Checks whether a word exists in the dictionary
        /// </summary>
        /// <param name="word">The word to check for</param>
        /// <returns>True if it is found, false otherwise</returns>
        public bool FindWord(String word)
        {
            CharEnumerator charEnum = word.GetEnumerator();
            if (!charEnum.MoveNext())
            {
                return false;
            }

            char c = charEnum.Current;
            foreach (DictNode n in Children)
            {
                if (n.Letter == c)
                {
                    return n.FindWord(charEnum);
                }
            }
            return false;
        }

        /// <summary>
        /// Attempt to remove a word from the dictionary
        /// </summary>
        /// <param name="word">The word to be removed</param>
        /// <returns>True if the word was found and removed, false otherwise</returns>
        public bool RemoveWord(String word)
        {
            CharEnumerator charEnum = word.GetEnumerator();
            if (!charEnum.MoveNext())
            {
                return false;
            }

            char c = charEnum.Current;

            foreach (DictNode n in Children)
            {
                if (n.Letter == c)
                {
                    if (n.RemoveWord(charEnum))
                    {
                        WordCount--;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Perform a partial word search. This will find all words (up to a certain number) that start with the first parameter.
        /// </summary>
        /// <param name="partialWord">The start of the words to search for</param>
        /// <returns>A list of matched words</returns>
        public List<String> WordSearch(String partialWord)
        {
            List<String> solns = new List<string>();

            CharEnumerator wordEnum = partialWord.GetEnumerator();
            if (!wordEnum.MoveNext())
            {
                return solns;
            }

            LetterUtil.Letter letter = LetterUtil.GetLetter(wordEnum.Current);
            foreach (DictNode n in Children)
            {
                if (letter == n.LetterEnum)
                {
                    n.WordSearch(wordEnum, solns);
                }
            }

            return solns;
        }

        /// <summary>
        /// Write the whole dictionary to a stream and sort it alphabetically
        /// </summary>
        /// <param name="sw">The stream to write to</param>
        public void WriteToStream(StreamWriter sw)
        {
            WriteToStream(sw, true);
        }

        /// <summary>
        /// Write the whole dictionary to a stream with optional alphabetical sorting
        /// </summary>
        /// <param name="sw">The stream to write to</param>
        /// <param name="sortFirst">Whether the words should be sorted</param>
        public void WriteToStream(StreamWriter sw, bool sortFirst)
        {
            if (sortFirst)
            {
                Children.Sort(NodeSorter.GetInstance());
            }

            foreach (DictNode n in Children)
            {
                n.WriteToStream(sw, true);
            }
        }
    }
}
