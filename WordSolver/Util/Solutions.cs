using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                return SolutionList.Count();
            }
        }

        /// <summary>
        /// The list of solutions found
        /// </summary>
        private static List<String> SolutionList = new List<string>();

        /// <summary>
        /// Reset the solutions to an empty state
        /// </summary>
        public static void Reset()
        {
            SolutionList = new List<string>();
        }

        /// <summary>
        /// Attempt to add a word to the solution list
        /// </summary>
        /// <param name="word">The word to add</param>
        /// <returns>True if it's a new solution, false if it's already been found</returns>
        public static bool AddWord(String word)
        {
            if (SolutionList.Contains(word))
            {
                return false;
            }
            SolutionList.Add(word);
            return true;
        }

        /// <summary>
        /// Sort the completed solution list
        /// </summary>
        public static void Finish()
        {
            SolutionList.Sort(new SolutionSorter());
        }

        /// <summary>
        /// Get an enumeration of the solutions
        /// </summary>
        /// <returns>The enum of solutions</returns>
        public static List<String>.Enumerator Enumerate()
        {
            return SolutionList.GetEnumerator();
        }
    }
}
