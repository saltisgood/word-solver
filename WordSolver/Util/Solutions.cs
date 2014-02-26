using System;
using System.Collections.Generic;
using System.Linq;

namespace WordSolver.Util
{
    /// <summary>
    /// Static class that contains the solutions from searching the tree
    /// </summary>
    public static class Solutions
    {
        /// <summary>
        /// The number of solutions found
        /// </summary>
        public static int Count
        {
            get
            {
                return _solutionList.Count();
            }
        }



        /// <summary>
        /// The list of solutions found
        /// </summary>
        private static List<String> _solutionList = new List<string>();



        /// <summary>
        /// Attempt to add a word to the solution list
        /// </summary>
        /// <param name="word">The word to add</param>
        /// <returns>True if it's a new solution, false if it's already been found</returns>
        public static bool AddWord(String word)
        {
            if (_solutionList.Contains(word))
            {
                return false;
            }
            _solutionList.Add(word);
            return true;
        }

        /// <summary>
        /// Attempt to add a word to the solution list
        /// </summary>
        /// <param name="soln">The completed partial solution</param>
        /// <returns>True if it's a new solution, false if it's already been found</returns>
        public static bool AddWord(PartialSoln soln)
        {
            String fullWord = String.Empty;
            foreach (String word in soln.Words)
            {
                fullWord += word + " ";
            }
            return AddWord(fullWord);
        }

        /// <summary>
        /// Get an enumeration of the solutions
        /// </summary>
        /// <returns>The enum of solutions</returns>
        public static List<String>.Enumerator Enumerate()
        {
            return _solutionList.GetEnumerator();
        }

        /// <summary>
        /// Sort the completed solution list
        /// </summary>
        public static void Finish()
        {
            _solutionList.Sort(new SolutionSorter());
        }

        /// <summary>
        /// Reset the solutions to an empty state
        /// </summary>
        public static void Reset()
        {
            _solutionList = new List<string>();
        }
        


        /// <summary>
        /// A representation of a partially found solution. Contains a list of words that make up a solution of
        /// multiple words.
        /// </summary>
        public class PartialSoln
        {
            /// <summary>
            /// The list of words that make up a solution.
            /// </summary>
            public readonly List<String> Words;



            /// <summary>
            /// Simplest constructor. Initialises an empty list of solutions.
            /// </summary>
            public PartialSoln() 
            {
                Words = new List<string>();
            }

            /// <summary>
            /// A constructor which copies across the list of words from another partial solution
            /// </summary>
            /// <param name="prevSoln">The other solution to copy values from</param>
            public PartialSoln(PartialSoln prevSoln)
            {
                if (prevSoln == null)
                {
                    Words = new List<string>();
                }
                else
                {
                    Words = new List<string>(prevSoln.Words);
                }
            }

            /// <summary>
            /// Convenience constructor used when you have a previous partial solution and a word to add at the same time.
            /// </summary>
            /// <param name="prevSoln">The partial solution to copy across</param>
            /// <param name="nextWord">The word to add</param>
            public PartialSoln(PartialSoln prevSoln, String nextWord) : this(prevSoln)
            {
                Words.Add(nextWord);
            }



            /// <summary>
            /// Convenience method to add a word to the list of partial solutions and return a reference to itself for
            /// method chaining.
            /// </summary>
            /// <param name="word">The word to add</param>
            /// <returns>A reference to this object for method chaining</returns>
            public PartialSoln AddWord(String word)
            {
                Words.Add(word);
                return this;
            }
        }
    }
}
