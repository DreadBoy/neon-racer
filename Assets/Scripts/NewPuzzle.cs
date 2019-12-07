using UnityEngine;

namespace NeonRacer
{
    [RequireComponent(typeof(SimplePuzzle))]
    public class NewPuzzle : MonoBehaviour
    {
        private void OnTriggerExit(Collider other)
        {
            var ship = other.GetComponent<Ship>();
            if (!ship)
                return;
            var transform1 = transform;
            var rand = Random.Range(30, 50);
            Instantiate(gameObject, transform1.position + transform1.forward * rand,
                Quaternion.identity);
            Destroy(gameObject);
            FindObjectOfType<Score>().score += 60 - rand;
        }
    }
}