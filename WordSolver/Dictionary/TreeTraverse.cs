using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordSolver.Dictionary
{
    /// <summary>
    /// A base class for the tree and nodes that has definitions for Children and Parent nodes
    /// </summary>
    public abstract class TreeTraverse
    {
        /// <summary>
        /// The parent node of the node
        /// </summary>
        public TreeTraverse Parent
        {
            get;
            private set;
        }

        /// <summary>
        /// The list of child nodes
        /// </summary>
        public List<DictNode> Children 
        {
            get;
            protected set;
        }

        public DictTree Root
        {
            get
            {
                if (Parent != null)
                {
                    return Parent.Root;
                }
                else
                {
                    return this as DictTree;
                }
            }
        }

        /// <summary>
        /// Base constructor. Should always be called from sub-classes to initialise the list of children
        /// </summary>
        public TreeTraverse(TreeTraverse parent) : this()
        {
            Parent = parent;
        }

        public TreeTraverse()
        {
            Children = new List<DictNode>();
        }
    }
}
