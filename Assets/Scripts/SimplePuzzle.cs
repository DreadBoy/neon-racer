using System;
using System.Collections.Generic;
using UnityEngine;


namespace NeonRacer
{
    [Serializable]
    struct PieceSetup
    {
        public Shape shape;
        public GameObject gameObject;
    }

    [RequireComponent(typeof(Grid))]
    [RequireComponent(typeof(MovePiece))]
    public class SimplePuzzle : MonoBehaviour
    {
        [SerializeField] private Grid grid;
        [SerializeField] private Input input;
        [SerializeField] private MovePiece movePiece;

        [SerializeField] private PieceSetup[] setup = new PieceSetup[0];
        private Dictionary<Shape, GameObject> _prefabs = new Dictionary<Shape, GameObject>();

        private void Reset()
        {
            grid = GetComponent<Grid>();
            input = GetComponent<Input>();
            movePiece = GetComponent<MovePiece>();
        }

        public void Start()
        {
            foreach (var piece in setup)
                _prefabs.Add(piece.shape, piece.gameObject);
            grid.InitGrid();
            var gos = new GameObject[9];
            for (var i = 0; i < grid.grid.Length; i++)
            {
                var piece = grid.grid[i];
                if (piece == null)
                    continue;
                var go = Instantiate(_prefabs[piece.shape],
                    NeonRacer.MovePiece.PositionForPiece(i),
                    Quaternion.identity,
                    transform);
                go.GetComponent<SpriteRenderer>()
                    .color = piece.color;
                gos[i] = go;
                movePiece.Init(gos);
            }
        }

        private void MovePiece(int[] indexes)
        {
            movePiece.Move(indexes);
            // SmoothDamp
        }

        private void Update()
        {
            if (input.commands.Count > 0)
            {
                var direction = input.directions[input.commands.Dequeue()];
                var indexes = grid.MovePiece(direction);
                if (indexes[0] != indexes[1])
                    MovePiece(indexes);
            }
        }
    }
}