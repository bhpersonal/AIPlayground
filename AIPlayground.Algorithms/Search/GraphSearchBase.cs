using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPlayground.Algorithms.Search
{
    public abstract class GraphSearchBase
    {
        public int NodesExpandedCount { get; protected set; }

        public event EventHandler NodeExpanded;

        protected void OnNodeExpanded()
        {
            NodesExpandedCount++;
            NodeExpanded?.Invoke(null, null);
        }

        public int NodesGeneratedCount { get; protected set; }

        public event EventHandler NodeGenerated;

        protected void OnNodeGenerated()
        {
            NodesGeneratedCount++;
            NodeGenerated?.Invoke(null, null);
        }

        public int NodesRetainedCount { get; protected set;  }
    }
}
