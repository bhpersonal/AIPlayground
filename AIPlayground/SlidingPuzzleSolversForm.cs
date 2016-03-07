using AIPlayground.Algorithms.Search;
using AIPlayground.DataStructures;
using AIPlayground.Problems;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIPlayground
{
    public partial class SlidingPuzzlesSolversForm : Form
    {
        public SlidingPuzzlesSolversForm()
        {
            InitializeComponent();

            RecreatePuzzle();
            
        }

        private Problems.SlidingTilesPuzzle _problem;

        private Problems.SlidingTilesPuzzle.State _currentState;

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            if (_problem == null) return;

            var scaleX = panel1.Width - 1;
            var scaleY = panel1.Height - 1;

            var size = _problem.Size;
            

            if (_currentState != null)
            {
                var fontSize = 200f / _problem.Size;
                var font = new Font(FontFamily.GenericSansSerif, fontSize);

                var margin = (1f / size) * .1f;
                var step = (1f / size);
                var boxSize = (1f / size) * .8f;
                var brush = new SolidBrush(Color.Red);
                for (var x = 0; x < _problem.Size; x++)
                {
                    for (var y = 0; y < _problem.Size; y++)
                    {
                        var i = y * _problem.Size + x;

                        var tile = _currentState.Tiles[i];
                        var tileString = tile == 0 ? " " : tile.ToString();

                        e.Graphics.DrawString(tileString, font, brush, (x / (float)_problem.Size) * scaleX + margin, y / ((float)_problem.Size) * scaleY + margin);

                    }
                }
            }

        }

        private Random _random = new System.Random();

        private void RandomSolveButton_Click(object sender, EventArgs e)
        {
            var i = 0;
            
            while (true)
            {
                if (_currentState.IsSolution) break;

                var actions = _currentState.GetActions();
                var action = actions[_random.Next(actions.Count)];

                _currentState.ApplyAction(action);

                if (++i % 100 == 0 || _currentState.IsSolution)
                {
                    panel1.Invalidate();
                    Application.DoEvents();
                }
                
            }
        }


        #region DFS
        
        private void DfsButton_Click(object sender, EventArgs e)
        {
            // Without any I/D or heuristics this is the same as random search
            
            var tree = new SearchTree<Problems.SlidingTilesPuzzle.State>(_currentState);
            var dfs = new DepthFirstSearcher<Problems.SlidingTilesPuzzle.State, int>(
                tree,
                x => x.GetActions().RandomizeOrder(),
                (x, a) => x.ApplyAction(a), // Don't need to clone because DFS is one way
                (x, a) => 1,
                x => x.IsSolution);
            
            var updateCount = 0;
            var start = DateTime.Now;
            Action<bool> updateCounts = (force) =>
            {
                if (!force && ++updateCount % 10000 > 0) return;
                NodesGeneratedLabel.Text = "Generated = " + dfs.NodesGeneratedCount + " ";
                ExpandedNodesLabel.Text = "Expanded = " + dfs.NodesExpandedCount + " ";
                RetainedNodesLabel.Text = "Retained = " + dfs.NodesRetainedCount + " ";
                SecondsLabel.Text = DateTime.Now.Subtract(start).TotalSeconds.ToString();
                _currentState = dfs.CurrentNode.Data;
                panel1.Invalidate();
                Application.DoEvents();
            };

            dfs.NodeExpanded += (s,a) => updateCounts(false);
            dfs.NodeGenerated += (s, a) => updateCounts(false);
            
            var solution = dfs.Search();

            updateCounts(true);
        }

        private static Random rnd = new Random();

        public static List<int> GetPossibleActions(Problems.QueensPuzzle.State state)
        {
            var result = new List<int>();
            var newPlacement = state.PlacementsCount;
            for (var action = 0; action < state.ColumnPlacements.Length; action++)
            {
                var isAttacking = false;
                for (var placement = 0; placement < newPlacement; placement++)
                {
                    if (Problems.QueensPuzzle.State.IsAttacking(placement, state.ColumnPlacements[placement], newPlacement, action))
                    {
                        isAttacking = true;
                        break;
                    }
                }

                if (!isAttacking) result.Add(action);
            }

            return result.OrderBy(x => rnd.Next()).ToList();
        }

        public static Problems.QueensPuzzle.State ApplyAction(Problems.QueensPuzzle.State state, int action)
        {
            var copy = new int[state.ColumnPlacements.Length];
            state.ColumnPlacements.CopyTo(copy, 0);
            copy[state.PlacementsCount] = action;
            return new Problems.QueensPuzzle.State(copy);
        }

        #endregion

        private void QueensSolversForm_Resize(object sender, EventArgs e)
        {
            panel1.Invalidate();
        }
        

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            RecreatePuzzle();
        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            RecreatePuzzle();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RecreatePuzzle();
        }

        private void RecreatePuzzle()
        {
            Text = "Size: " + trackBar1.Value + ", moves: " + trackBar2.Value;
            _problem = new Problems.SlidingTilesPuzzle(trackBar1.Value);
            _currentState = _problem.CreateJumbledState(trackBar2.Value);
            panel1.Invalidate();
        }

        private void IDNaiveButton_Click(object sender, EventArgs e)
        {
            var tree = new SearchTree<Problems.SlidingTilesPuzzle.State>(_currentState);
            var dfs = new DepthFirstSearcher<Problems.SlidingTilesPuzzle.State, int>(
                tree,
                x => x.GetActions(),
                (x, a) => x.Clone().ApplyAction(a), 
                (x, a) => 1,
                x => x.IsSolution);
            var id = new IterativeDeepeningDepthFirstSearch<Problems.SlidingTilesPuzzle.State, int>(dfs);

            var updateCount = 0;
            var start = DateTime.Now;
            Action<bool> updateCounts = (force) =>
            {
                if (!force && ++updateCount % 10000 > 0) return;
                NodesGeneratedLabel.Text = "Generated = " + dfs.NodesGeneratedCount + " ";
                ExpandedNodesLabel.Text = "Expanded = " + dfs.NodesExpandedCount + " ";
                RetainedNodesLabel.Text = "Retained = " + dfs.NodesRetainedCount + " ";
                SecondsLabel.Text = DateTime.Now.Subtract(start).TotalSeconds.ToString() + " (next depth = " + dfs.NextCostThreshhold + ")";
                _currentState = dfs.CurrentNode.Data;
                panel1.Invalidate();
                Application.DoEvents();
            };

            dfs.NodeExpanded += (s, a) => updateCounts(false);
            dfs.NodeGenerated += (s, a) => updateCounts(false);

            var solution = id.Search();

            updateCounts(true);
        }

        private void AStarButton_Click(object sender, EventArgs e)
        {

            
            var astar = new AStarSearcher<Problems.SlidingTilesPuzzle.State, int>(config => 
            {
                config.ActionsListFunc = x =>
                {
                    return x.Data.GetActions().Where(a => x.Parent == null || x.Parent.Data.Blank != a);
                };
                config.ActionApplierFunc = (x, a) => x.Data.Clone().ApplyAction(a);
                config.ActionCostFunc = (x, a) => 1;
                config.HeuristicFunc = SlidingTilePuzzleHeuristics.GetManhattanDistance;
                config.IsGoalFunc = x => x.Data.IsSolution;
            });
                
            var updateCount = 0;
            var start = DateTime.Now;
            Action<bool> updateCounts = (force) =>
            {
                if (!force && ++updateCount % 10000 > 0) return;
                NodesGeneratedLabel.Text = "Generated = " + astar.NodesGeneratedCount + " ";
                ExpandedNodesLabel.Text = "Expanded = " + astar.NodesExpandedCount + " ";
                RetainedNodesLabel.Text = "Retained = " + astar.NodesRetainedCount + " ";
                SecondsLabel.Text = DateTime.Now.Subtract(start).TotalSeconds.ToString() + " (next depth = " + astar.NextCostLimitThreshhold + ")";
                _currentState = astar.CurrentNode.Data;
                panel1.Invalidate();
                Application.DoEvents();
            };

            astar.NodeExpanded += (s, a) => updateCounts(false);
            astar.NodeGenerated += (s, a) => updateCounts(false);

            var solution = astar.Search(_currentState);

            updateCounts(true);
        }

        private void IdaButton_Click(object sender, EventArgs e)
        {
            var astar = new IteratedDeepeningAStarSearcher<SlidingTilesPuzzle.State, int>(config =>
            {
                config.ActionsListFunc = x =>
                {
                    return x.Data.GetActions().Where(a => x.Parent == null || x.Parent.Data.Blank != a);
                };
                config.ActionApplierFunc = (x, a) => x.Data.Clone().ApplyAction(a);
                config.ActionCostFunc = (x, a) => 1;
                config.HeuristicFunc = SlidingTilePuzzleHeuristics.GetManhattanDistance;
                config.IsGoalFunc = x => x.Data.IsSolution;
            });

            var updateCount = 0;
            var start = DateTime.Now;
            Action<bool> updateCounts = (force) =>
            {
                if (!force && ++updateCount % 10000 > 0) return;
                NodesGeneratedLabel.Text = "Generated = " + astar.NodesGeneratedCount + " ";
                ExpandedNodesLabel.Text = "Expanded = " + astar.NodesExpandedCount + " ";
                RetainedNodesLabel.Text = "Retained = " + astar.NodesRetainedCount + " ";
                SecondsLabel.Text = DateTime.Now.Subtract(start).TotalSeconds.ToString() + " (current depth = " + astar.CurrentDepth + ")";
                _currentState = astar.CurrentNode.Data;
                panel1.Invalidate();
                Application.DoEvents();
            };

            astar.NodeExpanded += (s, a) => updateCounts(false);
            astar.NodeGenerated += (s, a) => updateCounts(false);

            var solution = astar.Search(_currentState);

            updateCounts(true);
        }

        private void WidaButton_Click(object sender, EventArgs e)
        {
            var astar = new IteratedDeepeningAStarSearcher<SlidingTilesPuzzle.State, int>(config =>
            {
                config.ActionsListFunc = x =>
                {
                    return x.Data.GetActions().Where(a => x.Parent == null || x.Parent.Data.Blank != a);
                };
                config.ActionApplierFunc = (x, a) => x.Data.Clone().ApplyAction(a);
                config.ActionCostFunc = (x, a) => 1;
                config.HeuristicFunc = SlidingTilePuzzleHeuristics.GetManhattanDistance;
                config.IsGoalFunc = x => x.Data.IsSolution;
                config.HeuristicWeighting = float.Parse(WidaValueText.Text);
                config.RoundEstimatedRemainingCost = true;
            });

            var updateCount = 0;
            var start = DateTime.Now;
            Action<bool> updateCounts = (force) =>
            {
                if (!force && ++updateCount % 100000 > 0) return;
                NodesGeneratedLabel.Text = "Generated = " + astar.NodesGeneratedCount + " ";
                ExpandedNodesLabel.Text = "Expanded = " + astar.NodesExpandedCount + " ";
                RetainedNodesLabel.Text = "Retained = " + astar.NodesRetainedCount + " ";
                SecondsLabel.Text = DateTime.Now.Subtract(start).TotalSeconds.ToString() + " (current depth = " + astar.CurrentDepth + ")";
                _currentState = astar.CurrentNode.Data;
                panel1.Invalidate();
                Application.DoEvents();
            };

            astar.NodeExpanded += (s, a) => updateCounts(false);
            astar.NodeGenerated += (s, a) => updateCounts(false);

            var solution = astar.Search(_currentState);

            updateCounts(true);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var values = textBox1.Text.Split(' ').Select(x => int.Parse(x)).ToArray();
                if (values.Length != _problem.Size * _problem.Size) return;

                _currentState.Tiles = values;
                _currentState.Blank = values.Select((x, i) => new { val = x, index = i }).First(x => x.val == 0).index;
                panel1.Invalidate();
            }
            catch { }
        }
    }
}
