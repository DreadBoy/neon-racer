using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace NeonRacer
{
    public class Section : MonoBehaviour
    {
        [SerializeField] private Ship ship;
        [SerializeField] private Sections sections;

        private float length;

        private void Reset()
        {
            ship = FindObjectOfType<Ship>();
            sections = FindObjectOfType<Sections>();
        }

        private void Start()
        {
            length = GetComponent<BoxCollider>().size.z;
            ship = FindObjectOfType<Ship>();
            sections = FindObjectOfType<Sections>();
        }

        private void OnTriggerExit(Collider other)
        {
            var shipCollider = other.GetComponent<Ship>();
            if (!shipCollider)
                return;
            Destroy(gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            var shipCollider = other.GetComponent<Ship>();
            if (!shipCollider)
                return;
            var transform1 = transform;
            Instantiate(sections.sections[Random.Range(0, sections.sections.Length)],
                transform1.position + transform1.forward * length,
                Quaternion.identity);
        }
    }
}