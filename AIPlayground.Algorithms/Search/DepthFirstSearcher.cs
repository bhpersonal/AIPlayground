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
    public class DepthFirstSearcher<TData, TAction> : GraphSearchBase
        where TData : class
    {
        private SearchTree<TData> _tree;

        private Func<TData, IEnumerable<TAction>> _actionsListFunc;

        private Func<TData, TAction, TData> _actionApplierFunc;

        private Func<TData, TAction, float> _actionCostFunc;

        private Func<TData, bool> _matchFunc;

        public TreeNode<TData> CurrentNode;

        public DepthFirstSearcher(
            SearchTree<TData> tree,
            Func<TData, IEnumerable<TAction>> actionsListFunc,
            Func<TData, TAction, TData> actionApplierFunc,
            Func<TData, TAction, float> actionCostFunc,
            Func<TData, bool> matchFunc)
        {
            _tree = tree;
            _actionsListFunc = actionsListFunc;
            _actionApplierFunc = actionApplierFunc;
            _actionCostFunc = actionCostFunc;
            _matchFunc = matchFunc;
        }

        public TData Search(float? costDepthLimit = null)
        {
            NextCostThreshhold = float.MaxValue;

            IStack<TreeNode<TData>> stack = new StackList<TreeNode<TData>>();

            stack.Push(_tree.Root);

            while (!stack.IsEmpty)
            {
                CurrentNode = stack.Pop();
                
                if (_matchFunc(CurrentNode.Data)) return CurrentNode.Data;

                var actions = _actionsListFunc(CurrentNode.Data);

                CurrentNode.Children = new List<TreeNode<TData>>();
                foreach (var action in actions)
                {
                    var newNode = new TreeNode<TData>
                    {
                        Parent = CurrentNode,
                        Data = _actionApplierFunc(CurrentNode.Data, action),
                        Cost = CurrentNode.Cost + _actionCostFunc(CurrentNode.Data, action)
                    };
                    CurrentNode.Children.Add(newNode);
                }
                
                // Load new children onto stack
                CurrentNode.Children.ForEach(x => 
                {
                    if (costDepthLimit == null || costDepthLimit.Value >= x.Cost)
                    {
                        stack.Push(x);
                    }
                    else if (x.Cost < NextCostThreshhold)
                    {
                        NextCostThreshhold = x.Cost;
                    }
                });

                // Update counts & notifications
                OnNodeExpanded();
                CurrentNode.Children.ForEach(x => OnNodeGenerated());
                NodesRetainedCount = stack.Count;
            }

            return null;
        }

        public float NextCostThreshhold = float.MaxValue;
        
    }
}

