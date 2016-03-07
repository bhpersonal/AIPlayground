using AIPlayground.DataStructures;
using AIPlayground.DataStructures.Abstracts;
using AIPlayground.DataStructures.Concretes;
using System;
using System.Linq;

namespace AIPlayground.Algorithms.Tree
{
    public static class BreadthFirst
    {
        #region Tree

        public static T BreadthFirstSearch<T>(this SearchTree<T> tree, Func<T, bool> matchFunc)
            where T : class
        {
            IQueue<TreeNode<T>> queue = new QueueLinkedList<TreeNode<T>>();

            queue.Enqueue(tree.Root);

            while (!queue.IsEmpty)
            {
                var node = queue.Dequeue();
                if (matchFunc(node.Data)) return node.Data;
                node.Children.ForEach(queue.Enqueue);
            }

            return null;
        }

        #endregion

        #region Graph

        public static T BreadthFirstSearch<T>(this Graph<T> graph, Func<T, bool> matchFunc)
            where T : class
        {
            if (graph.IsEmpty) return null;
            
            graph.Nodes.ForEach(x => x._isVisited = false);

            IQueue<GraphNode<T>> queue = new QueueLinkedList<GraphNode<T>>();

            queue.Enqueue(graph.Nodes[0]);

            while (!queue.IsEmpty)
            {
                var node = queue.Dequeue();
                if (node._isVisited) continue;
                
                if (matchFunc(node.Data)) return node.Data;
                
                node.Edges.ForEach(x => queue.Enqueue(x.To));
                node._isVisited = true;
            }

            return null;
        }
        
        #endregion

    }
}
