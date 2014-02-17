using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordSolver
{
    class Node : TreeTraverse
    {
        private String _word;
        private bool IsWord;
        public char Letter 
        {
            get; private set; 
        }
        public LetterUtil.Letter LetterEnum
        {
            get; private set;
        }
        private int Depth;

        public Node(CharEnumerator subword, int depth) : base()
        {
            Depth = depth;
            Letter = subword.Current;
            LetterEnum = LetterUtil.GetLetter(Letter);

            if (subword.MoveNext())
            {
                Children.Add(new Node(subword, Depth + 1, this));
                IsWord = false;
            }
            else
            {
                IsWord = true;
            }
        }

        public Node(CharEnumerator subword, int depth, Node parent) : this(subword, depth)
        {
            Parent = parent;
        }

        public bool AddWord(CharEnumerator subword)
        {
            if (!subword.MoveNext())
            {
                if (IsWord)
                {
                    return false;
                }
                IsWord = true;
                return true;
            }

            char c = subword.Current;
            foreach (Node n in Children)
            {
                if (n.Letter == c)
                {
                    return n.AddWord(subword);
                }
            }

            Children.Add(new Node(subword, Depth + 1, this));
            return true;
        }

        public bool FindWord(CharEnumerator subword)
        {
            if (!subword.MoveNext())
            {
                return IsWord;
            }

            char c = subword.Current;
            foreach (Node n in Children)
            {
                if (n.Letter == c)
                {
                    return n.FindWord(subword);
                }
            }

            return false;
        }
    }
}
