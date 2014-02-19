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
    /// Class for holding the dictionary tree
    /// </summary>
    public class DictTree : TreeTraverse
    {
        /// <summary>
        /// The minimum length of the words to find
        /// </summary>
        public const int MIN_WORD_LENGTH = 3;

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

            Children.Add(new DictNode(charEnum, 0));
            WordCount++;
            return true;
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
        /// Find all the words in the dictionary given a starting node in the LetterGrid
        /// </summary>
        /// <param name="node">The node in the LetterGrid to start with</param>
        public void FindAllWords(LetterGrid.Node node)
        {
            foreach (DictNode n in Children)
            {
                if (n.LetterEnum == node.GetLetter())
                {
                    n.FindAllWords(node);
                    node.Release();
                    break;
                }
            }
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

        public void WordSearch(String partialWord, List<String> solns)
        {
            CharEnumerator wordEnum = partialWord.GetEnumerator();
            if (!wordEnum.MoveNext())
            {
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
                    return n.RemoveWord(charEnum);
                }
            }
            return false;
        }
    }
}
