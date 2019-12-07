using System;
using System.Collections;
using UnityEngine;

namespace NeonRacer
{
    public class MovePiece : MonoBehaviour
    {
        private GameObject[] objects;
        [SerializeField] private AudioClip clip;

        public void Init(GameObject[] objects)
        {
            this.objects = objects;
        }

        public void Move(int[] indexes, int w, int h)
        {
            FindObjectOfType<GameOver>().Play(clip);
            StartCoroutine(MoveC(objects[indexes[0]], PositionForPiece(indexes[0], w, h),
                PositionForPiece(indexes[1], w, h)));
            objects[indexes[1]] = objects[indexes[0]];
        }

        public static Vector3 PositionForPiece(int index, int w, int h)
        {
            return new Vector3(index % w - 2, h - Mathf.Floor(index / (float) w) - 2, 0);
        }

        private static IEnumerator MoveC(GameObject go, Vector3 from, Vector3 to)
        {
            for (var ft = 0f; ft >= 0; ft += Time.deltaTime * 10)
            {
                go.transform.localPosition = Vector3.Lerp(from, to, Mathf.Min(ft, 1));
                if (ft > 1)
                    break;
                yield return null;
            }
        }
    }
}