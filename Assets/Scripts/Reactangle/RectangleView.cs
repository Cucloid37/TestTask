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
        
    }
}