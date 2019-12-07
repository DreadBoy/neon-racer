using System;
using UnityEngine;

namespace NeonRacer
{
    public class StartScreen : MonoBehaviour
    {
        private void Start()
        {
            if (FindObjectsOfType<StartScreen>(true).Length > 1)
            {
                FindObjectOfType<Ship>().speed = 20;
                Destroy(gameObject);
            }
            else
                DontDestroyOnLoad(gameObject);
        }

        void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
            {
                FindObjectOfType<Ship>().speed = 20;
                gameObject.SetActive(false);
            }
        }
    }
}