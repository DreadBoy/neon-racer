using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace NeonRacer
{
    public class Grid : MonoBehaviour
    {
        public Piece[] grid;
        private int w, h;

        public void InitGrid(int w, int h)
        {
            this.w = w;
            this.h = h;
            grid = new int[w * h - 1].Select(i => Piece.Random()).Concat(new Piece[] {null}).ToArray();
            // Knuth shuffle algorithm :: courtesy of Wikipedia :)
            for (var t = 0; t < grid.Length; t++)
            {
                var r = Random.Range(t, grid.Length);
                var tmp = grid[t];
                grid[t] = grid[r];
                grid[r] = tmp;
            }
        }

        public int[] GetIndexesForMove(Direction direction)
        {
            var nullIndex = 0;
            for (var i = 0; i < grid.Length; i++)
                if (grid[i] == null)
                {
                    nullIndex = i;
                    break;
                }

            var index = DirectionToIndex(nullIndex, OppositesDirection(direction));
            return new[] {index, nullIndex};
        }

        public int[] MovePiece(Direction direction)
        {
            var indexes = GetIndexesForMove(direction);
            if (indexes[0] == indexes[1])
                return indexes;
            SwitchPieces(grid, indexes[0], indexes[1]);
            return indexes;
        }

        private static Direction OppositesDirection(Direction direction)
        {
            var dict = new Dictionary<Direction, Direction>
            {
                {Direction.down, Direction.up},
                {Direction.up, Direction.down},
                {Direction.left, Direction.right},
                {Direction.right, Direction.left},
            };
            return dict[direction];
        }

        public int DirectionToIndex(int index, Direction direction)
        {
            switch (direction)
            {
                case Direction.up:
                    if (index < w)
                        return index;
                    return index - w;
                case Direction.right:
                    if (index % w == w - 1)
                        return index;
                    return index + 1;
                case Direction.down:
                    if (index > w * h - w - 1)
                        return index;
                    return index + w;
                case Direction.left:
                    if (index % w == 0)
                        return index;
                    return index - 1;
                default:
                    return index;
            }
        }

        private static void SwitchPieces(IList<Piece> grid, int index1, int index2)
        {
            var temp = grid[index1];
            grid[index1] = grid[index2];
            grid[index2] = temp;
        }
    }
}