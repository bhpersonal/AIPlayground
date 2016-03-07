using AIPlayground.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPlayground.Algorithms.Traversal
{
    public static class BinaryTreeTraversal
    {

        #region Left-to-right traversal

        public static void TraverseLeftToRightRecursively<T>(this SearchTree<T> tree, Action<T> action)
            where T : class
        {
            TraverseLeftToRightRecursively(tree.Root, action);
        }

        private static void TraverseLeftToRightRecursively<T>(this TreeNode<T> node, Action<T> action)
            where T : class
        {
            if (node.Children.Count >= 1)
                node.Children[0].TraverseLeftToRightRecursively(action);

            action(node.Data);

            if (node.Children.Count >= 2)
                node.Children[1].TraverseLeftToRightRecursively(action);
        }

        #endregion
    }
}
