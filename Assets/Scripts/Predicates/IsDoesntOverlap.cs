using TestTask;

namespace Predicates
{
    public class IsDoesntOverlap : IPredicate
    {
        
        public bool IsReady(ITarget target)
        {
            if (target is IFactoryTarget factoryTarget)
            {
                return factoryTarget.IsOverlap();
            }

            return false;
        }
    }
}