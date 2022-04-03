using UnityEngine;

namespace TestTask
{
    public class WasEnoughTime : IPredicate
    {
        private const float LIMIT = -0.7f;

        public bool IsReady(ITarget target)
        {
            if (target is IDoubleTarget doubleTarget)
            {
                if (doubleTarget.timeSinceTheLastClick - Time.time > LIMIT)
                    return true;
                else
                {
                    doubleTarget.timeSinceTheLastClick = Time.time;
                    doubleTarget.toComparer = doubleTarget.targetObject;
                    doubleTarget.countPlus();
                }
            }

            return false;
        }
    }
}