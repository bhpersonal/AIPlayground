using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPlayground.Problems
{
    public class SlidingTilesPuzzle
    {
        public int Size;

        public SlidingTilesPuzzle(int size)
        {
            Size = size;
        }

        public State CreateDefaultState()
        {
            return CreateState(Enumerable.Range(0, Size * Size).ToArray());
        }

        public State CreateJumbledState(int moveCount)
        {
            var state = CreateDefaultState();
            return ApplyRandomMoves(state, moveCount);
        }

        public State CreateState(int[] tiles)
        {
            var blank = 0;
            for (var i = 0; i < tiles.Length; i++)
                if (tiles[i] == 0)
                {
                    blank = i;
                    break;
                }

            return new State(Size, tiles, blank);
        }

        private static Random _random = new Random();

        public State ApplyRandomMoves(State state, int moveCount)
        {
            for (var i = 0; i < moveCount; i++)
            {
                var actions = state.GetActions();
                
                var action = actions[_random.Next(actions.Count)];

                state.ApplyAction(action);
            }

            return state;
        }

        public class State
        {
            public State Clone()
            {
                return new State(Size, Tiles, Blank);
            }

            public State(int size, int[] tiles, int blank)
            {
                Size = size;
                Tiles = new int[tiles.Length];
                Array.Copy(tiles, Tiles, tiles.Length);
                //tiles.CopyTo(Tiles, 0);

                Blank = blank;
            }
            
            public State ApplyAction(int action)
            {
                Tiles[Blank] = Tiles[action];
                Tiles[action] = 0;
                Blank = action;
                return this;
            }

            public int[] Tiles;

            public int Blank;

            public int Size;

            public List<int> GetActions()
            {
                var actions = new List<int>(4);
                

                var row = (int)Math.Floor((double)Blank / Size);
                var col = Blank - (row * Size);

                if (row > 0) actions.Add(Blank - Size);
                if (row < Size - 1) actions.Add(Blank + Size);
                if (col > 0) actions.Add(Blank - 1);
                if (col < Size - 1) actions.Add(Blank + 1);

                return actions;
            }

            public bool IsSolution
            {
                get
                {
                    //if (Blank != 0) return false;

                    for (var i = 0; i < Tiles.Length - 1; i++)
                    {
                        if (Tiles[i] != i ) return false;
                    }

                    return true;
                }

            }
        }

    }

    public static class SlidingTilePuzzleHeuristics
    {
        private static IDictionary<int, Cell[]> _cache = new Dictionary<int, Cell[]>();

        private class Cell
        {
            public int Row;

            public int Col;
        }

        public static float GetManhattanDistance(SlidingTilesPuzzle.State state)
        {
            Cell[] coords;
            if (!_cache.TryGetValue(state.Size * state.Size, out coords))
            {
                coords = new Cell[state.Size * state.Size];

                for (var i = 0; i < state.Size * state.Size; i++)
                {
                    coords[i] = new Cell { Row = (int)(i / (state.Size)), Col = i % (state.Size) };
                }

                _cache.Add(state.Size * state.Size, coords);
            }

            var result = 0;

            for (var i = 0; i < state.Size * state.Size; i++)
            {
                if (i == state.Blank) continue;

                var v1 = coords[state.Tiles[i]].Row - coords[i].Row;
                var v2 = coords[state.Tiles[i]].Col - coords[i].Col;

                result += (v1 < 0 ? -v1 : v1) + (v2 < 0 ? -v2 : v2);
            }

            return result;
        }
    }
}

