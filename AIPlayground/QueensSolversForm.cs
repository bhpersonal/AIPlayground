using AIPlayground.Algorithms.Search;
using AIPlayground.DataStructures;
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
    public partial class QueensSolversForm : Form
    {
        public QueensSolversForm()
        {
            InitializeComponent();
            trackBar1.Value = 4;
        }

        private Problems.QueensPuzzle _problem;

        private Problems.QueensPuzzle.State _currentState;

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            if (_problem == null) return;

            var scaleX = panel1.Width - 1;
            var scaleY = panel1.Height - 1;

            var size = _problem.Size;

            /*
            var pen = new Pen(Color.LightBlue);
            for (var i = 0f; i <= 1f; i += 1f / size)
            {
                e.Graphics.DrawLine(pen, new PointF(i * scaleX, 0), new PointF(i * scaleX, 1 * scaleY));
                e.Graphics.DrawLine(pen, new PointF(0, i * scaleY), new PointF(1 * scaleX, i * scaleY));
            }
            */

            if (_currentState != null)
            {
                var margin = (1f / size) * .1f;
                var step = (1f / size);
                var boxSize = (1f / size) * .8f;
                //var brush = new HatchBrush(HatchStyle.Max, Color.Green, Color.Gold);
                var brush = new SolidBrush(Color.Red);
                for (var i = 0; i < _problem.Size; i++)
                {
                    if (_currentState.ColumnPlacements[i] >= 0)
                    {
                        e.Graphics.FillRectangle(brush,
                            ((i * step) + margin) * scaleX,
                            ((_currentState.ColumnPlacements[i] * step) + margin) * scaleY,
                            boxSize * scaleX,
                            boxSize * scaleY);
                    }
                }
            }

        }

        private System.Random _random = new System.Random();

        private void button1_Click(object sender, EventArgs e)
        {
            var i = 0;
            while (true)
            {
                _currentState = new Problems.QueensPuzzle.State(
                    Enumerable.Range(0, _problem.Size)
                    .Select(x => _random.Next(_problem.Size)).ToArray());

                if (++i % 500000 == 0 || _currentState.AttackCount == 0)
                {
                    panel1.Invalidate();
                    Application.DoEvents();
                }
                if (_currentState.AttackCount == 0) break;
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Text = "Size: " + trackBar1.Value;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            _problem = new Problems.QueensPuzzle(trackBar1.Value);

            _currentState = new Problems.QueensPuzzle.State(Enumerable.Range(0, _problem.Size).Select(x => (x * 393342739) % _problem.Size).ToArray());
            panel1.Invalidate();
        }

        #region DFS
        
        private void button2_Click(object sender, EventArgs e)
        {

            var initialState = Enumerable.Range(0, _problem.Size).Select(x => -1).ToArray();
            var tree = new SearchTree<Problems.QueensPuzzle.State>(_problem.CreateState(initialState));
            var dfs = new DepthFirstSearcher<Problems.QueensPuzzle.State, int>(
                tree,
                GetPossibleActions,
                ApplyAction,
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
    }
}
