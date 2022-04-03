namespace TestTask
{
    public class IsDoubleClick : IPredicate
    {
        public bool IsReady(ITarget target)
        {
            if (target is IDoubleTarget doubleTarget)
            {
                if (doubleTarget.countClick > 1)
                    return true;
                else
                {
                    doubleTarget.countPlus();
                    return false;
                }
            }

            return false;
        }
    }
}