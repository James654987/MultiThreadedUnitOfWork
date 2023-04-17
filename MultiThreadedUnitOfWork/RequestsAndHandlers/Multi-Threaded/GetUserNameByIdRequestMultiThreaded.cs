using MediatR;

namespace AsynchronousSessionManagement.RequestsAndHandlers.Multi_Threaded
{
    public class GetUserNameByIdRequestMultiThreaded : IRequest<GetUserNameByIdResponseMultiThreaded>
    {
        public GetUserNameByIdRequestMultiThreaded(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}