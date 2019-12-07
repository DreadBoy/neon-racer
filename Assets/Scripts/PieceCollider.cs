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
            Debug.Log("Hit");
        }
    }
}