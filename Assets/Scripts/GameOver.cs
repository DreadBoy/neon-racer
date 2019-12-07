using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace NeonRacer
{
    [RequireComponent(typeof(AudioSource))]
    public class GameOver : MonoBehaviour
    {
        private static readonly int Pop = Animator.StringToHash("Pop");
        [SerializeField] private AudioClip clip;

        private bool gameOver = false;

        public void Show()
        {
            Play(clip);
            foreach (var text in GetComponentsInChildren<Text>())
                text.enabled = true;
            foreach (var animator in GetComponentsInChildren<Animator>())
                animator.SetTrigger(Pop);
            gameOver = true;
        }

        public void Play(AudioClip clip)
        {
            GetComponent<AudioSource>().PlayOneShot(clip);
        }

        void Update()
        {
            if (gameOver && UnityEngine.Input.GetKeyDown(KeyCode.Space))
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}