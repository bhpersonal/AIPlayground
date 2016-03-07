using AIPlayground.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPlayground.Algorithms.Search
{
    public class IterativeDeepeningDepthFirstSearch<TData, TAction>
        where TData : class
    {

        private DepthFirstSearcher<TData, TAction> _dfs;
        public IterativeDeepeningDepthFirstSearch(
            DepthFirstSearcher<TData, TAction> dfs)
        {
            _dfs = dfs;
        }

        public TData Search(float initialCostDepthLimit = 0)
        {
            var costDepthLimit = initialCostDepthLimit;
            while (true)
            {
                var solution = _dfs.Search(costDepthLimit);
                if (solution != null)
                    return solution;

                costDepthLimit = _dfs.NextCostThreshhold;
            }
        }
    }
}
