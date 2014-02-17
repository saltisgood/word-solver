using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordSolver
{
    class DictTree : TreeTraverse
    {
        public int WordCount
        {
            get;
            private set;
        }

        public DictTree() : base()
        {
            WordCount = 0;
        }

        public bool AddWord(String word)
        {
            CharEnumerator charEnum = word.GetEnumerator();
            if (!charEnum.MoveNext())
            {
                return false;
            }

            char c = charEnum.Current;
            foreach (Node n in Children) 
            {
                if (n.Letter == c)
                {
                    if (n.AddWord(charEnum))
                    {
                        WordCount++;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            Children.Add(new Node(charEnum, 0));
            WordCount++;
            return true;
        }

        public bool FindWord(String word)
        {
            CharEnumerator charEnum = word.GetEnumerator();
            if (!charEnum.MoveNext())
            {
                return false;
            }

            char c = charEnum.Current;
            foreach (Node n in Children)
            {
                if (n.Letter == c)
                {
                    return n.FindWord(charEnum);
                }
            }
            return false;
        }
    }
}
