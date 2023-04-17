namespace MultiThreadedUnitOfWork.UnitOfWorkAndRepositories
{
    public interface IRepository
    {
        T Get<T>(int id);
        void Add<T>(T entity);
    }
}