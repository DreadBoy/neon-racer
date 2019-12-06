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
        [SerializeField] private PieceSetup[] setup = new PieceSetup[0];
        private Dictionary<Shape, GameObject> _prefabs = new Dictionary<Shape, GameObject>();

        private void Reset()
        {
            grid = GetComponent<Grid>();
        }

        public void Start()
        {
            foreach (var piece in setup)
                _prefabs.Add(piece.shape, piece.gameObject);
            grid.initGrid();
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
    }
}