using UnityEngine;

namespace NeonRacer
{
    public class ConfirmPuzzle : MonoBehaviour
    {
        [SerializeField] private AudioClip clip;
        
        private void OnTriggerExit(Collider other)
        {
            var ship = other.GetComponent<Ship>();
            if (!ship)
                return;
            FindObjectOfType<GameOver>().Play(clip);
        }
    }
}