using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordSolver.Grid
{
    public class GameOptions
    {
        /// <summary>
        /// Determines whether letters must be adjacent to one another in the grid. True means no, false means yes.
        /// </summary>
        public bool IsAnagram { get; private set; }

        public GameOptions(bool isAnagram)
        {
            IsAnagram = isAnagram;
        }
    }
}
