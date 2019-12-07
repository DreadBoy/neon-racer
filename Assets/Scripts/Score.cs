using System;
using UnityEngine;
using UnityEngine.UI;

namespace NeonRacer
{
    public class Score : MonoBehaviour
    {
        public int score = 0;
        [SerializeField] private Text text;
        private int prevScore;
        private static readonly int Pop = Animator.StringToHash("Pop");

        private void Reset()
        {
            text = GetComponent<Text>();
        }

        private void Update()
        {
            text.text = score.ToString();
            if(prevScore != score)
                GetComponent<Animator>().SetTrigger(Pop);
            prevScore = score;
        }
    }
}