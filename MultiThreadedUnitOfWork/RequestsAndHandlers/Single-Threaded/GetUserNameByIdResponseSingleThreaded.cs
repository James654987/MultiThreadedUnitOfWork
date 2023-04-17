namespace MultiThreadedUnitOfWork.RequestsAndHandlers.Single_Threaded
{
    public class GetUserNameByIdResponseSingleThreaded
    {
        public GetUserNameByIdResponseSingleThreaded(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}