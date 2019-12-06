using UnityEngine;
using UnityEngine.UI;

namespace NeonRacer
{
    [RequireComponent(typeof(Text))]
    [RequireComponent(typeof(Input))]
    public class Command : MonoBehaviour
    {
        [SerializeField] private Input input;
        [SerializeField] private Text text;

        private void Reset()
        {
            input = GetComponent<Input>();
            text = GetComponent<Text>();
        }

        private void Update()
        {
            text.text = string.Join(",", input.commands.ToArray());
        }
    }
}