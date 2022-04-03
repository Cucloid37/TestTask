using Predicates;
using UnityEngine;

namespace TestTask
{
    public class RectangleFactory : MonoBehaviour
    {
        private GameObject rectanglePrefab;
        private RandomColor rndColor;

        private IsDoesntOverlap predicates;

        public void Init(GameObject prefab, Color[] colors)
        {
            rectanglePrefab = prefab;
            rndColor = new RandomColor(colors);
            predicates = new IsDoesntOverlap();

        }
        
        // В зависимости от задачи можно сделать CreateGameObject(GameObject prefab, Transform position),
        // для быстроты, поскольку сейчас создаётся только прямоугольник одним единственным образом, я решил сделать конкретную фабрику 
        public RectangleView CreateRectangle(Vector3 point, IFactoryTarget target)
        {
            if (!predicates.IsReady(target))
            {
                Debug.Log($"ставить сюда не получится");
                return null;
            }
            
            var product = Instantiate(rectanglePrefab, point, Quaternion.identity);
            var view = product.AddComponent<RectangleView>();
            view.Init();
            view.SetColor(rndColor.GetRndColor());

            return view;
        }
    }
}