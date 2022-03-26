using System.Collections.Generic;
using UnityEngine;

namespace TestTask
{
    public class GameController : BaseController
    {
        private readonly RectangleFactory factory;
        private readonly RayCastManager rayCast;
        private readonly EqualityComparer<GameObject> comparer;
        private GameObject toComparer;

        private int countClick;
        private float timeSinceTheLastClick;

        private const float LIMIT = -1.2f;
        public GameController(Descriptions descriptions, ProfilePlayer profile, PrefabsManager prefabsManager, UpdateController updateController)
        {
            rayCast = new RayCastManager();
            var input = new InputController();
            comparer = EqualityComparer<GameObject>.Default;
            
            factory = new GameObject("Factory").AddComponent<RectangleFactory>();
            factory.Init(prefabsManager.Rectangle, descriptions.Colors);
            /*var x = factory.CreateRectangle();*/
            // input.OnClickMouseLeft += OnClickMouseLeft;
            input.OnClickMouseLeft += DoubleClickMouseLeft;
            updateController.Add(input);
        }

        private void OnClickMouseLeft()
        {
           //todo сделать проверку, не на коробку ли мы нажали
           var x = rayCast.GoReturn();
           factory.CreateRectangle(rayCast.Point.CurrentValue);
        }

        // примитивная реализация, признаться
        private void DoubleClickMouseLeft()
        {
            var go = rayCast.GoReturn();
            
            //todo вот это всё выносится в Predicate
            if(go.GetComponent<BoxCollider>())
            {
                countClick++;
                
                if (countClick > 1)
                {
                    if(timeSinceTheLastClick - Time.time > LIMIT)
                    {
                        if (comparer.Equals(go, toComparer))
                        {
                            Object.Destroy(go);
                            countClick = 0;
                            toComparer = null;
                            return;
                        }
                        
                    }
                    
                    countClick = 0;
                    toComparer = null;
                    return;
                }
                
                timeSinceTheLastClick = Time.time;
                toComparer = go;
                return;
                    
            }
            
            factory.CreateRectangle(rayCast.Point.CurrentValue);
            
        }
        
        
    }
}