namespace TestTask
{
    public class IsComparer : IPredicate
    {
        public bool IsReady(ITarget target)
        {
            if (target is IDoubleTarget doubleTarget)
            {
                return doubleTarget.comparer.Equals(doubleTarget.targetObject, doubleTarget.toComparer);
            }

            return false;
        }
    }
}