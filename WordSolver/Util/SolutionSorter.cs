using System;
using System.Collections.Generic;

namespace WordSolver.Util
{
    /// <summary>
    /// A class used for sorting the solutions obtained from the dictionary search
    /// </summary>
    class SolutionSorter : IComparer<String>
    {
        int IComparer<String>.Compare(String a, String b)
        {
            return LetterUtil.GetWordScore(b) - LetterUtil.GetWordScore(a);
        }
    }
}
