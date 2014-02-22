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
        public bool IsMaxAnagramLength
        {
            get
            {
                return _anagramLength >= LetterGrid.GRID_MAX_X * LetterGrid.GRID_MAX_Y;
            }
        }

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

        public bool ConnectingLetters 
        {
            get
            {
                if (IsAnagram)
                {
                    return false;
                }
                return _connectingLetters;
            }
            set
            {
                _connectingLetters = value;
            }
        }

        public bool MultiWords
        {
            get
            {
                if (!IsAnagram)
                {
                    return false;
                }
                return _multiWords;
            }
            set
            {
                _multiWords = value;
            }
        }
        private bool _multiWords;

        private int _anagramLength;
        private bool _connectingLetters;

        /// <summary>
        /// Constructor used when the game is not an anagram. Can choose whether the letters need to be adjacent.
        /// <param name="connectingLetters">Whether the solutions need to have adjacent letters</param>
        /// </summary>
        public GameOptions(bool connectingLetters)
        {
            IsAnagram = false;
            _connectingLetters = connectingLetters;
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
