using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPlayground.DataStructures
{
    public class SearchTree<TData>
        where TData : class
    {
        public SearchTree(TData root = null)
        {
            Root = new TreeNode<TData> { Data = root };
        }

        public TreeNode<TData> Root;

        public bool IsEmpty { get { return Root == null; } }
    }

    public class TreeNode<T>
    {
        public TreeNode<T> Parent;

        public List<TreeNode<T>> Children;

        public T Data;

        public float Cost;
    }
}
