using System;
using System.Collections;
using UnityEngine;

namespace NeonRacer
{
    public class MovePiece : MonoBehaviour
    {
        private GameObject[] objects;

        public void Init(GameObject[] objects)
        {
            this.objects = objects;
        }

        public void Move(int[] indexes)
        {
            StartCoroutine(MoveC(objects[indexes[0]], PositionForPiece(indexes[0]), PositionForPiece(indexes[1])));
            objects[indexes[1]] = objects[indexes[0]];
        }

        public static Vector3 PositionForPiece(int index)
        {
            return new Vector3(index % 3, Mathf.Ceil(index / -3f));
        }

        private static IEnumerator MoveC(GameObject go, Vector3 from, Vector3 to)
        {
            for (var ft = 0f; ft >= 0; ft += Time.deltaTime * 10)
            {
                go.transform.position = Vector3.Lerp(from, to, Mathf.Min(ft, 1));
                if (ft > 1)
                    break;
                yield return null;
            }
        }
    }
}