using System.Collections.Generic;
using UnityEngine;

namespace NeonRacer
{
    public class Input : MonoBehaviour
    {
        private string[] keys = {"left", "right", "up", "down"};

        public Dictionary<string, Direction> directions = new Dictionary<string, Direction>
        {
            {"left", Direction.left},
            {"right", Direction.right},
            {"up", Direction.up},
            {"down", Direction.down},
        };

        private int[] pressed = new int[4];
        public Queue<string> commands = new Queue<string>();

        private void Update()
        {
            UpdateKeys();
            for (var i = pressed.Length - 1; i >= 0; i--)
                if (pressed[i] == 1)
                {
                    commands.Enqueue(keys[i]);
                    break;
                }
        }

        private void UpdateKeys()
        {
            for (var i = 0; i < keys.Length; i++)
            {
                var press = UnityEngine.Input.GetAxisRaw(keys[i]) > 0;
                if (press && pressed[i] == 0)
                    pressed[i] = 1;
                else if (press && pressed[i] == 1)
                    pressed[i] = 2;
                else if (!press)
                    pressed[i] = 0;
            }
        }
    }
}