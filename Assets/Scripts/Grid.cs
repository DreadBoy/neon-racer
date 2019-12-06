using System;
using System.Collections.Generic;
using ICSharpCode.NRefactory.Ast;
using UnityEngine;

namespace NeonRacer
{
    public class Grid : MonoBehaviour
    {
        public Piece[] grid;

        public void InitGrid()
        {
            grid = new[]
            {
                Piece.Random(), Piece.Random(), Piece.Random(),
                Piece.Random(), null, Piece.Random(),
                Piece.Random(), Piece.Random(), Piece.Random(),
            };
        }

        public void MovePiece(Direction direction)
        {
            var nullIndex = 0;
            for (var i = 0; i < grid.Length; i++)
                if (grid[i] == null)
                {
                    nullIndex = i;
                    break;
                }

            var index = DirectionToIndex(nullIndex, OppositesDirection(direction));
            if (nullIndex == index)
                return;
            SwitchPieces(grid, index, nullIndex);
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

        public static int DirectionToIndex(int index, Direction direction)
        {
            switch (direction)
            {
                case Direction.up:
                    if (index < 3)
                        return index;
                    return index - 3;
                case Direction.right:
                    if (index % 3 == 2)
                        return index;
                    return index + 1;
                case Direction.down:
                    if (index > 5)
                        return index;
                    return index + 3;
                case Direction.left:
                    if (index % 3 == 0)
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