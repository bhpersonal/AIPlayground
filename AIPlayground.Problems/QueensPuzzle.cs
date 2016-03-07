using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPlayground.Problems
{
    public class QueensPuzzle
    {
        public  int Size;

        public QueensPuzzle(int size)
        {
            Size = size;
        }

        public State CreateState(int[] columnPlacements)
        {
            return new State(columnPlacements);
        }


        public class State
        {
            public State(int[] columnPlacements)
            {
                ColumnPlacements = columnPlacements;

                CalculateAttacks();
            }

            public int[] ColumnPlacements;

            public int PlacementsCount;

            public int AttackCount;

            public bool IsComplete;

            public bool IsSolution;

            public void CalculateAttacks()
            {
                AttackCount = 0;
                for (var i = 0; i < ColumnPlacements.Length - 1; i++)
                {
                    if (ColumnPlacements[i] == -1) continue;
                    for (var j = i + 1; j < ColumnPlacements.Length; j++)
                    {
                        if (IsAttacking(i, ColumnPlacements[i], j, ColumnPlacements[j]))
                            AttackCount++;
                    }
                }
                PlacementsCount = ColumnPlacements.Count(x => x >= 0);

                IsComplete = ColumnPlacements.All(x => x >= 0);

                IsSolution = IsComplete && AttackCount == 0;
            }

            public static bool IsAttacking(int x1, int y1, int x2, int y2)
            {
                return y1 == y2 || Math.Abs(x2 - x1) == Math.Abs(y2 - y1); // No need to check x1 == x2 in this implementation
            }
        }
    }
}
