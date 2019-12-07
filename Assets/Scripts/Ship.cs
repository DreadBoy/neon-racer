using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace NeonRacer
{
    public class Ship : MonoBehaviour
    {
        public float speed;

        private void Reset()
        {
            speed = 20;
        }

        private void Update()
        {
            var trans = transform;
            trans.Translate(speed * Time.deltaTime * trans.forward);
            if (trans.position.x < -18)
            {
                var pos = trans.position;
                pos.x += 19;
                trans.position = pos;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            var puzzle = other.GetComponent<NewPuzzle>();
            if (!puzzle)
                return;
            speed = Math.Min(30, speed + 0.2f);
        }
    }
}