using UnityEngine;

namespace NeonRacer
{
    public class StartScreen : MonoBehaviour
    {
        private void Start()
        {
            if (FindObjectsOfType<StartScreen>(true).Length > 1)
            {
                StartEffect();
                Destroy(gameObject);
            }
            else
                DontDestroyOnLoad(gameObject);
        }

        void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
            {
                StartEffect();
                gameObject.SetActive(false);
            }
        }

        private static void StartEffect()
        {
            FindObjectOfType<Ship>().speed = 20;
        }
    }
}