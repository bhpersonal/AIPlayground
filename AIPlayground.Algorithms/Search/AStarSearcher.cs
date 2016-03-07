using AIPlayground.DataStructures;
using AIPlayground.DataStructures.Abstracts;
using AIPlayground.DataStructures.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPlayground.Algorithms.Search
{
    public class AStarSearcher<TData, TAction> : GraphSearchBase
        where TData : class
    {
        public class Configuration
        {
            public Func<SearchNode, IEnumerable<TAction>> ActionsListFunc;

            public Func<SearchNode, TAction, TData> ActionApplierFunc;

            public Func<SearchNode, TAction, float> ActionCostFunc;

            public Func<TData, float> HeuristicFunc;

            public Func<SearchNode, bool> IsGoalFunc;
        }

        public class SearchNode
        {
            public TData Data;

            public TAction Action;

            public SearchNode Parent;
            
            public float Cost;

            public float EstimatedRemainingCost;

            public float EstimatedTotalCost => Cost + EstimatedRemainingCost;

        }

        public Configuration Config;
        
        public AStarSearcher(Action<Configuration> configAction)
        {
            Config = new Configuration();
            configAction(Config);
        }

        private List<SearchNode> ReconstructPath(SearchNode node)
        {
            var result = new List<SearchNode>();
            while (node!= null)
            {
                result.Add(node);
                node = node.Parent;
            }
            result.Reverse();
            return result;
        }

        public List<SearchNode> Search(TData root, float costLimit = float.MaxValue)
        {
            NextCostLimitThreshhold = float.MaxValue;

            var priorityQueue = new PriorityQueueHeap<SearchNode>();

            // Start at root
            var rootNode = new SearchNode
            {
                Data = root,
                Action = default(TAction),
                Parent = null,
                Cost = 0,
                EstimatedRemainingCost = Config.HeuristicFunc(root),
            };
            priorityQueue.Insert(rootNode.EstimatedTotalCost, rootNode);

            while (!priorityQueue.IsEmpty)
            {
                CurrentNode = priorityQueue.ExtractTop();
                if (Config.IsGoalFunc(CurrentNode))
                    return ReconstructPath(CurrentNode);

                

                var actions = Config.ActionsListFunc(CurrentNode);
                foreach (var action in actions)
                {
                    var newNode = new SearchNode
                    {
                        Parent = CurrentNode,
                        Data = Config.ActionApplierFunc(CurrentNode, action),
                        Action = action,
                        Cost = CurrentNode.Cost + Config.ActionCostFunc(CurrentNode, action),
                    };
                    newNode.EstimatedRemainingCost = Config.HeuristicFunc(newNode.Data);
                    
                    if (newNode.Cost <= costLimit)
                    {
                        priorityQueue.Insert(newNode.EstimatedTotalCost, newNode);

                        OnNodeGenerated();
                    }
                    else
                    {
                        if (newNode.Cost < NextCostLimitThreshhold)
                            NextCostLimitThreshhold = newNode.Cost; 
                    }
                }

                OnNodeExpanded();
                NodesRetainedCount = priorityQueue.Count;
            }

            return null;
        }
        
        // Outputs

        public SearchNode CurrentNode;

        public float NextCostLimitThreshhold;
    }
}

