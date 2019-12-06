using System;
using System.Collections.Generic;
using UnityEngine;

namespace NeonRacer
{
    public class Grid : MonoBehaviour
    {
        public Piece[] grid;

        public void initGrid()
        {
            grid = new[]
            {
                Piece.Random(), Piece.Random(), Piece.Random(),
                Piece.Random(), null, Piece.Random(),
                Piece.Random(), Piece.Random(), Piece.Random(),
            };
        }

        public void movePiece(int index, Direction direction)
        {
            if (index < 0 || index >= grid.Length || grid[index] == null)
                return;
            SwitchPieces(grid, index, DirectionToIndex(index, direction));
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