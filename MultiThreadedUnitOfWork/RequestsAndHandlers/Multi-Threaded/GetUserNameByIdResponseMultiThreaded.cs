namespace MultiThreadedUnitOfWork.RequestsAndHandlers.Multi_Threaded
{
    public class GetUserNameByIdResponseMultiThreaded
    {
        public GetUserNameByIdResponseMultiThreaded(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}