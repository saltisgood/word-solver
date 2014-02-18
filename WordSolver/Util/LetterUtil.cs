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
            V = 21, W = 22, X = 23, Y = 24, Z = 25, UNKNOWN = 26
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
                case Letter.UNKNOWN: default:
                    return "UNKNOWN";
            }
        }
    }
}
