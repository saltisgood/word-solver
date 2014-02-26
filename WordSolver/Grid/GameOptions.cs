using System;

namespace WordSolver.Grid
{
    public class GameOptions
    {
        /// <summary>
        /// Determines whether letters must be adjacent to one another in the grid. True means no, false means yes.
        /// </summary>
        public bool IsAnagram { get; private set; }

        /// <summary>
        /// Is the anagram at the maximum length allowed by the size of the game grid
        /// </summary>
        public bool IsMaxAnagramLength
        {
            get
            {
                if (!IsAnagram)
                {
                    throw new InvalidOperationException("Game is not an anagram");
                }
                return _anagramLength >= LetterGrid.GRID_MAX_X * LetterGrid.GRID_MAX_Y;
            }
        }

        /// <summary>
        /// The current length of the anagram. Cannot be set to less than 0 or greater than the size of the grid.
        /// </summary>
        public int AnagramLength 
        { 
            get
            {
                if (!IsAnagram)
                {
                    throw new InvalidOperationException("Game is not an anagram");
                }
                return _anagramLength;
            }
            set
            {
                _anagramLength = (value < 0 ) ? 0 : ((value <= LetterGrid.GRID_MAX_X * LetterGrid.GRID_MAX_Y) ? value : LetterGrid.GRID_MAX_X * LetterGrid.GRID_MAX_Y);
            }
        }
        /// <summary>
        /// The private data store for AnagramLength
        /// </summary>
        private int _anagramLength;

        /// <summary>
        /// Whether letters in the grid must be adjacent to one another
        /// </summary>
        public bool AreConnectingLettersRequired 
        {
            get
            {
                if (IsAnagram)
                {
                    return false;
                }
                return _areConnectingLettersRequired;
            }
            set
            {
                _areConnectingLettersRequired = value;
            }
        }
        /// <summary>
        /// The private data store for AreConnectingLettersRequired
        /// </summary>
        private bool _areConnectingLettersRequired;

        /// <summary>
        /// Whether word matches made up of multiple words are allowed
        /// </summary>
        public bool AreMultipleWordsAllowed
        {
            get
            {
                if (!IsAnagram)
                {
                    return false;
                }
                return _areMultipleWordsAllowed;
            }
            set
            {
                _areMultipleWordsAllowed = value;
            }
        }
        /// <summary>
        /// The private data store for AreMultipleWordsAllowed
        /// </summary>
        private bool _areMultipleWordsAllowed;

        /// <summary>
        /// Constructor used when the game is not an anagram. Can choose whether the letters need to be adjacent.
        /// <param name="connectingLetters">Whether the solutions need to have adjacent letters</param>
        /// </summary>
        public GameOptions(bool connectingLetters)
        {
            IsAnagram = false;
            _areConnectingLettersRequired = connectingLetters;
        }

        /// <summary>
        /// Constructor used when the game is an anagram
        /// </summary>
        /// <param name="anagramLength">The length of the anagram to be solved</param>
        public GameOptions(int anagramLength)
        {
            IsAnagram = true;
            _anagramLength = anagramLength;
        }
    }
}
