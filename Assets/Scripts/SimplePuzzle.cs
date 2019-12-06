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
    public class SimplePuzzle : MonoBehaviour
    {
        [SerializeField] private Grid grid;
        [SerializeField] private Input input;

        [SerializeField] private PieceSetup[] setup = new PieceSetup[0];
        private Dictionary<Shape, GameObject> _prefabs = new Dictionary<Shape, GameObject>();

        private void Reset()
        {
            grid = GetComponent<Grid>();
            input = GetComponent<Input>();
        }

        public void Start()
        {
            foreach (var piece in setup)
                _prefabs.Add(piece.shape, piece.gameObject);
            grid.InitGrid();
            RenderGrid();
        }

        private void RenderGrid()
        {
            foreach (Transform child in transform)
                Destroy(child.gameObject);
            for (var i = 0; i < grid.grid.Length; i++)
            {
                var piece = grid.grid[i];
                if (piece == null)
                    continue;
                var position = new Vector3(i % 3, Mathf.Ceil(i / -3f));
                Instantiate(_prefabs[piece.shape],
                        position,
                        Quaternion.identity,
                        transform)
                    .GetComponent<SpriteRenderer>()
                    .color = piece.color;
            }
        }

        private void Update()
        {
            if (input.commands.Count > 0)
            {
                var direction = input.directions[input.commands.Dequeue()];
                grid.MovePiece(direction);
                RenderGrid();
            }
        }
    }
}