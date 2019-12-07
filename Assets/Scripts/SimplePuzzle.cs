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
            foreach (Transform child in transform)
                Destroy(child.gameObject);
            grid.InitGrid(5, 3);
            var gos = new GameObject[5 * 3];
            for (var i = 0; i < grid.grid.Length; i++)
            {
                var piece = grid.grid[i];
                if (piece == null)
                    continue;
                var go = Instantiate(_prefabs[piece.shape],
                    transform,
                    false);
                go.transform.localPosition = NeonRacer.MovePiece.PositionForPiece(i, 5, 3);
                gos[i] = go;
            }
            movePiece.Init(gos);
        }

        private void MovePiece(int[] indexes)
        {
            movePiece.Move(indexes, 5, 3);
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