using System.Collections.Generic;

namespace WordSolver.Dictionary
{
    /// <summary>
    /// A base class for the tree and nodes that has definitions for Children and Parent nodes
    /// </summary>
    public abstract class TreeTraverse
    {
        /// <summary>
        /// The parent of the node
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

        /// <summary>
        /// The root of the tree. Note that this is the actual DictTree object, not a DictNode.
        /// </summary>
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
        /// Use this constructor to set the parent of the new node. Should be used for all nodes with a parent,
        /// i.e. all but the root.
        /// </summary>
        public TreeTraverse(TreeTraverse parent) : this()
        {
            Parent = parent;
        }

        /// <summary>
        /// Base constructor. Should always be called from sub-classes to initialise the list of children.
        /// </summary>
        public TreeTraverse()
        {
            Children = new List<DictNode>();
        }
    }
}
