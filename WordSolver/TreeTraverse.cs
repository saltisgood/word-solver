using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordSolver
{
    class TreeTraverse
    {
        public TreeTraverse()
        {
            Children = new List<Node>();
        }

        public TreeTraverse Parent
        {
            get;
            protected set;
        }

        public List<Node> Children 
        {
            get;
            protected set;
        } 
    }
}
