using System;
using UnityEngine;

namespace NeonRacer
{
    public class Track : MonoBehaviour
    {
        private void Start()
        {
            if (FindObjectsOfType<Track>().Length > 1)
                Destroy(gameObject);
            else
                DontDestroyOnLoad(gameObject);
        }
    }
}