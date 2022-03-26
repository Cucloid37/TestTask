using UnityEngine;

namespace TestTask
{
    public class RectangleFactory : MonoBehaviour
    {
        private GameObject rectanglePrefab;
        private RandomColor rndColor;

        public void Init(GameObject prefab, Color[] colors)
        {
            rectanglePrefab = prefab;
            rndColor = new RandomColor(colors);

        }
        
        // В зависимости от задачи можно сделать CreateGameObject(GameObject prefab, Transform position),
        // для быстроты, поскольку сейчас создаётся только прямоугольник одним единственным образом, я решил сделать конкретную фабрику 
        public RectangleView CreateRectangle(Vector3 point)
        {
            var product = Instantiate(rectanglePrefab, point, Quaternion.identity);
            var view = product.AddComponent<RectangleView>();
            view.Init();
            view.SetColor(rndColor.GetRndColor());

            return view;
        }
    }
}