namespace MultiThreadedUnitOfWork.IoC
{
    public interface IContainer
    {
        T Resolve<T>();
    }
}