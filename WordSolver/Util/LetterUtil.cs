using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordSolver.Util
{
    /// <summary>
    /// Collection of utilities for working with letters
    /// </summary>
    public static class LetterUtil
    {
        /// <summary>
        /// An enum of the alphabet
        /// </summary>
        public enum Letter
        {
            A = 0, B = 1, C = 2, D = 3, E = 4, F = 5, G = 6, H = 7, I = 8, J = 9, K = 10,
            L = 11, M = 12, N = 13, O = 14, P = 15, Q = 16, R = 17, S = 18, T = 19, U = 20,
            V = 21, W = 22, X = 23, Y = 24, Z = 25, UNKNOWN = -1, AR = 26, CH = 27, DE = 28,
            ER = 29, EST = 30, RE = 31, TO = 32, VE = 33
        }

        /// <summary>
        /// Get an enum from a char value
        /// </summary>
        /// <param name="c">The char value to convert</param>
        /// <returns>The enum representation</returns>
        public static Letter GetLetter(char c)
        {
            switch (c)
            {
                case 'a': case 'A':
                    return Letter.A;
                case 'b': case 'B':
                    return Letter.B;
                case 'c': case 'C':
                    return Letter.C;
                case 'd': case 'D':
                    return Letter.D;
                case 'e': case 'E':
                    return Letter.E;
                case 'f': case 'F':
                    return Letter.F;
                case 'g': case 'G':
                    return Letter.G;
                case 'h': case 'H':
                    return Letter.H;
                case 'i': case 'I':
                    return Letter.I;
                case 'j': case 'J':
                    return Letter.J;
                case 'k': case 'K':
                    return Letter.K;
                case 'l': case 'L':
                    return Letter.L;
                case 'm': case 'M':
                    return Letter.M;
                case 'n': case 'N':
                    return Letter.N;
                case 'o': case 'O':
                    return Letter.O;
                case 'p': case 'P':
                    return Letter.P;
                case 'q': case 'Q':
                    return Letter.Q;
                case 'r': case 'R':
                    return Letter.R;
                case 's': case 'S':
                    return Letter.S;
                case 't': case 'T':
                    return Letter.T;
                case 'u': case 'U':
                    return Letter.U;
                case 'v': case 'V':
                    return Letter.V;
                case 'w': case 'W':
                    return Letter.W;
                case 'x': case 'X':
                    return Letter.X;
                case 'y': case 'Y':
                    return Letter.Y;
                case 'z': case 'Z':
                    return Letter.Z;
                default:
                    return Letter.UNKNOWN;
            }
        }

        /// <summary>
        /// Convert an enum to a string representation
        /// </summary>
        /// <param name="letter">The enum to convert</param>
        /// <returns>The string representation</returns>
        public static String ConvertToString(Letter letter)
        {
            switch (letter)
            {
                case Letter.A:
                    return "A";
                case Letter.B:
                    return "B";
                case Letter.C:
                    return "C";
                case Letter.D:
                    return "D";
                case Letter.E:
                    return "E";
                case Letter.F:
                    return "F";
                case Letter.G:
                    return "G";
                case Letter.H:
                    return "H";
                case Letter.I:
                    return "I";
                case Letter.J:
                    return "J";
                case Letter.K:
                    return "K";
                case Letter.L:
                    return "L";
                case Letter.M:
                    return "M";
                case Letter.N:
                    return "N";
                case Letter.O:
                    return "O";
                case Letter.P:
                    return "P";
                case Letter.Q:
                    return "Q";
                case Letter.R:
                    return "R";
                case Letter.S:
                    return "S";
                case Letter.T:
                    return "T";
                case Letter.U:
                    return "U";
                case Letter.V:
                    return "V";
                case Letter.W:
                    return "W";
                case Letter.X:
                    return "X";
                case Letter.Y:
                    return "Y";
                case Letter.Z:
                    return "Z";
                case Letter.ER:
                    return "ER";
                case Letter.AR:
                    return "AR";
                case Letter.CH:
                    return "CH";
                case Letter.RE:
                    return "RE";
                case Letter.EST:
                    return "EST";
                case Letter.TO:
                    return "TO";
                case Letter.VE:
                    return "VE";
                case Letter.DE:
                    return "DE";
                case Letter.UNKNOWN: default:
                    return "UNKNOWN";
            }
        }

        public static int GetLetterScore(Letter letter)
        {
            switch (letter)
            {
                case Letter.A:
                    return 2;
                case Letter.B:
                    return 5;
                case Letter.C:
                    return 3;
                case Letter.D:
                    return 3;
                case Letter.E:
                    return 1;
                case Letter.F:
                    return 5;
                case Letter.G:
                    return 4;
                case Letter.H:
                    return 4;
                case Letter.I:
                    return 2;
                case Letter.J:
                    throw new NotImplementedException();
                case Letter.K:
                    return 6;
                case Letter.L:
                    return 3;
                case Letter.M:
                    return 4;
                case Letter.N:
                    return 2;
                case Letter.O:
                    return 2;
                case Letter.P:
                    return 4;
                case Letter.Q:
                    throw new NotImplementedException();
                case Letter.R:
                    return 2;
                case Letter.S:
                    return 2;
                case Letter.T:
                    return 2;
                case Letter.U:
                    return 4;
                case Letter.V:
                    return 6;
                case Letter.W:
                    return 6;
                case Letter.X:
                    return 9;
                case Letter.Y:
                    return 5;
                case Letter.AR:
                    return 7;
                case Letter.CH:
                    return 9;
                case Letter.ER:
                    return 6;
                case Letter.RE:
                    return 12;
                case Letter.EST:
                    return 12;
                case Letter.TO:
                    return 6;
                case Letter.VE:
                    return 6;
                case Letter.Z:
                    throw new NotImplementedException();
                case Letter.UNKNOWN:
                default:
                    throw new ArgumentException();
            }
        }

        public static int GetLetterScore(char c)
        {
            return GetLetterScore(GetLetter(c));
        }

        public static int GetWordScore(String word)
        {
            int score = 0, count = 0;

            CharEnumerator enumer = word.GetEnumerator();
            while (enumer.MoveNext())
            {
                score += GetLetterScore(enumer.Current);
                count++;
            }

            if (count >= 8)
            {
                return (int)(score * 2.5);
            }
            else if (count >= 6)
            {
                return score * 2;
            }
            else if (count == 5)
            {
                return (int)(score * 1.5);
            }
            return score;
        }

        /// <summary>
        /// Split up a digram into each of its component letters
        /// </summary>
        /// <param name="digram">The original digram</param>
        /// <param name="pos">The position of the letter to return from the digram</param>
        /// <returns>One of the 2 letters from the digram</returns>
        public static Letter SplitDigram(Letter digram, int pos)
        {
            if (GetLetterLength(digram) < 2)
            {
                throw new ArgumentException("Letter is not a digram!");
            }
            switch (digram)
            {
                case Letter.ER:
                    if (pos == 0)
                    {
                        return Letter.E;
                    }
                    else
                    {
                        return Letter.R;
                    }
                case Letter.AR:
                    if (pos == 0)
                    {
                        return Letter.A;
                    }
                    else
                    {
                        return Letter.R;
                    }
                case Letter.CH:
                    if (pos == 0)
                    {
                        return Letter.C;
                    }
                    else
                    {
                        return Letter.H;
                    }
                case Letter.RE:
                    if (pos == 0)
                    {
                        return Letter.R;
                    }
                    else
                    {
                        return Letter.E;
                    }
                case Letter.VE:
                    if (pos == 0)
                    {
                        return Letter.V;
                    }
                    else
                    {
                        return Letter.E;
                    }
                case Letter.TO:
                    if (pos == 0)
                    {
                        return Letter.T;
                    }
                    else
                    {
                        return Letter.O;
                    }
                case Letter.EST:
                    if (pos == 0)
                    {
                        return Letter.E;
                    }
                    else if (pos == 1)
                    {
                        return Letter.S;
                    }
                    else
                    {
                        return Letter.T;
                    }
                case Letter.DE:
                    if (pos == 0)
                    {
                        return Letter.D;
                    }
                    else
                    {
                        return Letter.E;
                    }
                default:
                    throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Return all the letters from a digram
        /// </summary>
        /// <param name="digram">The digram to split up</param>
        /// <returns>A 2/3-index array of letters</returns>
        public static Letter[] SplitDigram(Letter digram)
        {
            Letter[] letters = new Letter[2];
            letters[0] = SplitDigram(digram, 0);
            letters[1] = SplitDigram(digram, 1);
            return letters;
        }

        public static int GetLetterLength(Letter letter)
        {
            switch (letter)
            {
                case Letter.ER:
                case Letter.AR:
                case Letter.CH:
                case Letter.DE:
                case Letter.RE:
                case Letter.TO:
                case Letter.VE:
                    return 2;
                case Letter.EST:
                    return 3;
                default:
                    return 1;
            }
        }
    }
}
