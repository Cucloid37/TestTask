using System;
using UnityEngine;

namespace TestTask
{
    public class RectangleView : MonoBehaviour
    {
        private Transform _transform;
        private Renderer _renderer;

        public void Init()
        {
            _transform = gameObject.GetComponent<Transform>();
            _renderer = gameObject.GetComponent<Renderer>();
        }

        public void SetColor(Color color)
        {
            _renderer.material.color = color;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.transform.GetComponent<BoxCollider>())
            {
                Destroy(gameObject);
            }
        }

        /*private void OnTriggerEnter(Collider other)
        {
            if (other.transform.GetComponent<BoxCollider>())
            {
                Destroy(gameObject);
            }
        }*/

        private void OnDestroy()
        {
            Debug.Log($"{gameObject.GetHashCode()} не может быть здесь размещён");
        }
    }
}