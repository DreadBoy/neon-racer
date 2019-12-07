using UnityEngine;

namespace NeonRacer
{
    public class PieceCollider : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            var ship = other.GetComponent<Ship>();
            if (!ship)
                return;
            ship.speed = 0;
            FindObjectOfType<GameOver>().Show();
        }
    }
}