using System.Collections.Generic;

namespace WordSolver.Dictionary
{
    /// <summary>
    /// Simple singleton class used for sorting the nodes alphabetically
    /// </summary>
    class NodeSorter : IComparer<DictNode>
    {
        /// <summary>
        /// The cached instance of the NodeSorter
        /// </summary>
        private static NodeSorter _instance;

        /// <summary>
        /// Retrieve the cached instance of the NodeSorter
        /// </summary>
        /// <returns></returns>
        public static NodeSorter GetInstance()
        {
            if (_instance == null)
            {
                _instance = new NodeSorter();
            }
            return _instance;
        }

        /// <summary>
        /// The comparison method that implements the IComparer interface
        /// </summary>
        /// <param name="a">The left node</param>
        /// <param name="b">The right node</param>
        /// <returns>The comparison of the letter values of the 2 nodes</returns>
        int IComparer<DictNode>.Compare(DictNode a, DictNode b)
        {
            return a.LetterEnum - b.LetterEnum;
        }
    }
}
