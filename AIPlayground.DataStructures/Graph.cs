using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPlayground.DataStructures
{
    public class Graph<T>
    {
        public List<GraphNode<T>> Nodes;

        public List<GraphEdge<T>> Edges;

        public bool IsEmpty => Nodes.Count == 0;
    }

    public class GraphNode<T>
    {
        public List<GraphEdge<T>> Edges;

        public T Data;

        public bool _isVisited;
    }

    public class GraphEdge<T>
    {
        public GraphNode<T> From;

        public GraphNode<T> To;
    }
}
