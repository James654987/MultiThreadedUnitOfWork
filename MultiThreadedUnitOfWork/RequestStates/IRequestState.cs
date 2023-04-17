namespace AsynchronousSessionManagement.RequestStates
{
    public interface IRequestState
    {
        void Store<T>(T something);
        T Get<T>();
    }
}