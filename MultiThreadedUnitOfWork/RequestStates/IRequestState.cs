namespace MultiThreadedUnitOfWork.RequestStates
{
    public interface IRequestState
    {
        void Store<T>(T something);
        T Get<T>();
    }
}