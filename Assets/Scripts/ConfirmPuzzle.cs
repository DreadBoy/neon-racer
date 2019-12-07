using UnityEngine;

namespace NeonRacer
{
    [RequireComponent(typeof(AudioSource))]
    public class ConfirmPuzzle : MonoBehaviour
    {
        [SerializeField] private AudioClip clip;
        
        private void OnTriggerEnter(Collider other)
        {
            var ship = other.GetComponent<Ship>();
            if (!ship)
                return;
            GetComponent<AudioSource>().PlayOneShot(clip);
        }
    }
}