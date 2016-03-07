using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPlayground.Algorithms.Search
{
    public class IteratedDeepeningAStarSearcher<TData, TAction> : GraphSearchBase
        where TData : class
    {
        public class Configuration
        {
            public Func<SearchNode, IEnumerable<TAction>> ActionsListFunc;

            public Func<SearchNode, TAction, TData> ActionApplierFunc;

            public Func<SearchNode, TAction, float> ActionCostFunc;

            public Func<TData, float> HeuristicFunc;

            public Func<SearchNode, bool> IsGoalFunc;

            public float HeuristicWeighting = 1f;

            public bool RoundEstimatedRemainingCost;
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

        public IteratedDeepeningAStarSearcher(Action<Configuration> configFunc)
        {
            Config = new Configuration();
            configFunc(Config);
        }

        public List<SearchNode> Search(TData root, float maxValueDepth = float.MaxValue)
        {
            var rootNode = new SearchNode
            {
                Parent = null,
                Data = root,
                Cost = 0,
                Action = default(TAction),
                EstimatedRemainingCost = Config.HeuristicFunc(root),
            };

            CurrentDepth = rootNode.EstimatedRemainingCost;
            while (CurrentDepth <= maxValueDepth)
            {
                var nextThreshhold = float.MaxValue;
                var result = Search(rootNode, CurrentDepth, ref nextThreshhold);
                if (result != null)
                {
                    var path = ReconstructPath(result);
                    return path;
                }

                CurrentDepth = nextThreshhold;
            }

            return null;
        }

        private List<SearchNode> ReconstructPath(SearchNode node)
        {
            var result = new List<SearchNode>();
            while (node != null)
            {
                result.Add(node);
                node = node.Parent;
            }
            result.Reverse();
            return result;
        }
        
        private SearchNode Search(SearchNode node, float valueDepth, ref float nextThreshhold)
        {
            CurrentNode = node;

            if (Config.IsGoalFunc(node))
                return node;


            OnNodeExpanded();
            var actions = Config.ActionsListFunc(node);

            foreach (var action in actions)
            {
                var childNode = new SearchNode
                {
                    Parent = node,
                    Data = Config.ActionApplierFunc(node, action),
                    Action = action,
                    Cost = node.Cost + Config.ActionCostFunc(node, action),
                };

                
                childNode.EstimatedRemainingCost = Config.RoundEstimatedRemainingCost 
                    ? (int)(Config.HeuristicFunc(childNode.Data) * Config.HeuristicWeighting) 
                    : (Config.HeuristicFunc(childNode.Data) * Config.HeuristicWeighting);

                OnNodeGenerated();

                if (childNode.EstimatedTotalCost <= valueDepth)
                {
                    var result = Search(childNode, valueDepth, ref nextThreshhold);
                    if (result != null)
                        return result;
                }
                else
                {
                    if (childNode.EstimatedTotalCost < nextThreshhold)
                        nextThreshhold = childNode.EstimatedTotalCost;
                }
            }

            return null;
        }

        public SearchNode CurrentNode;

        public float CurrentDepth;
    }
}
