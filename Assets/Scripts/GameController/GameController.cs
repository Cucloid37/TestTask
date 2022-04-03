using System.Collections.Generic;
using UnityEngine;

namespace TestTask
{
    public class GameController : BaseController
    {
        private readonly RectangleFactory factory;
        private readonly RayCastManager rayCast;
        // public EqualityComparer<GameObject> comparer { get; }
        private readonly IPredicate isNotBox;
        private readonly List<IPredicate> isCanDelete;
        private FactoryTarget target;
       

       
        public GameController(Descriptions descriptions, ProfilePlayer profile, PrefabsManager prefabsManager, UpdateController updateController)
        {
            rayCast = new RayCastManager();
            var input = new InputController();
            // comparer = EqualityComparer<GameObject>.Default;

            isNotBox = new IsNotBox();

            isCanDelete = new List<IPredicate>()
            {
                new IsDoubleClick(),
                new WasEnoughTime(),
                new IsComparer()
            };

            target = new FactoryTarget(null, descriptions);
            
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
           /*var x = rayCast.GoReturn();
           factory.CreateRectangle(rayCast.Point.CurrentValue);*/
        }

        // примитивная реализация
        private void DoubleClickMouseLeft()
        {
            target.countPlus();
            target.SetTarget(rayCast.GoReturn());

            if (target.targetObject == null)
            {
                Debug.LogWarning($"RayCastReturn == null");
                return;
            }
            
             //todo вот это всё выносится в Predicate
            if(!isNotBox.IsReady(target))
            {
                
                foreach (var predicate in isCanDelete)
                {
                    if(!predicate.IsReady(target))
                        return;
                }
                
                Object.Destroy(target.targetObject);
                target.Reset();
                target.toComparer = null;
                return;
                
                /*if (countClick > 1)
                {
                    if(timeSinceTheLastClick - Time.time > LIMIT)
                    {
                        if (comparer.Equals(target.targetObject, toComparer))
                        {
                            Object.Destroy(target.targetObject);
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
                toComparer = target.targetObject;
                return;*/
                    
            }
            
            factory.CreateRectangle(rayCast.Point.CurrentValue, target);
            
        }
        
        
    }
}