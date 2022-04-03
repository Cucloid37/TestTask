namespace TestTask
{
    public interface IPredicate
    {
        bool IsReady(ITarget target);
        
    }
}