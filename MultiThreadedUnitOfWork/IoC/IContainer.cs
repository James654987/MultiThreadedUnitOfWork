namespace AsynchronousSessionManagement.IoC
{
    public interface IContainer
    {
        T Resolve<T>();
    }
}