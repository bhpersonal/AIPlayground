using AIPlayground.DataStructures;
using AIPlayground.DataStructures.Abstracts;
using AIPlayground.DataStructures.Concretes;
using System;
namespace AIPlayground.Algorithms.Traversal
{
    public static class TreeTraversal
    {

        #region Breadth first traversal

        public static void TraverseBreadthFirst<T>(this SearchTree<T> tree, Action<T> action)
            where T : class
        {
            IQueue<TreeNode<T>> queue = new QueueLinkedList<TreeNode<T>>(); // TODO test circular

            queue.Enqueue(tree.Root);
            while (!queue.IsEmpty)
            {
                var node = queue.Dequeue();
                action(node.Data);
                node.Children.ForEach(queue.Enqueue);
            }
        }

        public static bool TraverseBreadthFirst<T>(this SearchTree<T> tree, Func<T, bool> breakCondition)
            where T : class
        {
            IStack<TreeNode<T>> stack = new StackList<TreeNode<T>>();

            stack.Push(tree.Root);
            while (!stack.IsEmpty)
            {
                var node = stack.Pop();
                var breakResult = breakCondition(node.Data);
                if (breakResult) return true;

                node.Children.ForEach(stack.Push);
            }

            return false;
        }

        #endregion

        #region Depth first traversal

        public static void TraverseDepthFirst<T>(this SearchTree<T> tree, Action<T> action)
            where T : class
        {
            IStack<TreeNode<T>> stack = new StackList<TreeNode<T>>();

            stack.Push(tree.Root);
            while (!stack.IsEmpty)
            {
                var node = stack.Pop();
                action(node.Data);
                node.Children.ForEach(stack.Push);
            }
        }

        public static void TraverseDepthFirstRecursively<T>(this SearchTree<T> tree, Action<T> action)
            where T : class
        {
            TraverseDepthFirstRecursively(tree.Root, action);
        }

        public static bool TraverseDepthFirst<T>(this SearchTree<T> tree, Func<T, bool> breakCondition)
            where T : class
        {
            IStack<TreeNode<T>> stack = new StackList<TreeNode<T>>();

            stack.Push(tree.Root);
            while (!stack.IsEmpty)
            {
                var node = stack.Pop();
                var breakResult = breakCondition(node.Data);
                if (breakResult) return true;

                node.Children.ForEach(stack.Push);
            }

            return false;
        }

        private static void TraverseDepthFirstRecursively<T>(this TreeNode<T> node, Action<T> action)
        {
            action(node.Data);
            foreach (var child in node.Children)
            {
                child.TraverseDepthFirstRecursively(action);
            }
        }

        public static bool TraverseDepthFirstRecursively<T>(this SearchTree<T> tree, Func<T, bool> breakCondition)
            where T : class
        {
            return tree.Root.TraverseDepthFirstRecursively(breakCondition);
        }

        private static bool TraverseDepthFirstRecursively<T>(this TreeNode<T> node, Func<T, bool> breakCondition)
        {
            if (breakCondition(node.Data))
                return true;

            foreach (var child in node.Children)
            {
                if (child.TraverseDepthFirstRecursively(breakCondition))
                    return true;
            }

            return false;
        }

        #endregion

    }
}
