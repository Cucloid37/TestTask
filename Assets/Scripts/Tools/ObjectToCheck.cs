using System;
using UnityEngine;

namespace TestTask
{
    public class ObjectToCheck : MonoBehaviour
    {
        private int _overlapCount;

        public int OverlapCount => _overlapCount;

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<BoxCollider>())
            {
                _overlapCount++;
                Debug.LogWarning($"Мы соприкоснулись с {other.name}");
                Debug.LogWarning($"{_overlapCount}");
            }
        }

        private void OnTriggerExit(Collider other)
        {

            if (other.GetComponent<BoxCollider>())
            {
                _overlapCount--;
                Debug.LogWarning($"Мы соприкоснулись с {other.name}");
                Debug.LogWarning($"{_overlapCount}");
            }
        }
    }
}