using UnityEngine;

namespace TestTask
{
    //todo разбить на множество предикатов
    public class IsNotBox : IPredicate
    {
        public bool IsReady(ITarget target)
        {
            if (target is IFactoryTarget factoryTarget)
            {
                return !factoryTarget?.targetObject.GetComponent<BoxCollider>();
            }

            return false;
        }
        
    }
}