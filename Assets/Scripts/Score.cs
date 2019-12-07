using System;
using UnityEngine;
using UnityEngine.UI;

namespace NeonRacer
{
    public class Score : MonoBehaviour
    {
        public int score = 0;
        [SerializeField] private Text text;
        [SerializeField] private Ship ship;
        private int prevScore;
        private static readonly int Pop = Animator.StringToHash("Pop");

        private void Reset()
        {
            text = GetComponent<Text>();
        }

        private void Start()
        {
            ship = FindObjectOfType<Ship>();
        }

        private void Update()
        {
            text.text = ship.speed > 0 || score > 0 ? score.ToString() : "";
            if (prevScore != score)
                GetComponent<Animator>().SetTrigger(Pop);
            prevScore = score;
        }
    }
}