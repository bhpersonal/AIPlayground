using AIPlayground.DataStructures;
using AIPlayground.DataStructures.Abstracts;
using AIPlayground.DataStructures.Concretes;
using System;
using System.Collections.Generic;

namespace AIPlayground.Algorithms.Search
{
    public static class DepthFirst
    {
        #region Tree

        public static T DepthFirstSearchRecursive<T>(
            this SearchTree<T> tree, 
            Func<T, bool> matchFunc)
            where T : class
        {

            return tree.Root.DepthFirstSearchRecursive( matchFunc);
        }

        private static T DepthFirstSearchRecursive<T>(
            this TreeNode<T> node,
            Func<T, bool> matchFunc
            )
            where T : class
        {

            if (matchFunc(node.Data) == true) return node.Data;
            
            foreach (var child in node.Children)
            {
                var result = child.DepthFirstSearchRecursive(matchFunc);
                if (result != null) return result;
            }

            return null;
        }

        #endregion

        #region Graph

        public static T DepthFirstSearch<T>(this Graph<T> graph, Func<T, bool> matchFunc)
            where T : class
        {
            if (graph.IsEmpty) return null;

            graph.Nodes.ForEach(x => x._isVisited = false);

            IStack<GraphNode<T>> queue = new StackList<GraphNode<T>>();

            queue.Push(graph.Nodes[0]);

            while (!queue.IsEmpty)
            {
                var node = queue.Pop();
                if (node._isVisited) continue;

                if (matchFunc(node.Data)) return node.Data;

                node.Edges.ForEach(x => queue.Push(x.To));
                node._isVisited = true;
            }

            return null;
        }

        #endregion
    }
}
