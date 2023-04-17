using MediatR;

namespace MultiThreadedUnitOfWork.RequestsAndHandlers.Single_Threaded
{
    public class GetUserNameByIdRequestSingleThreaded : IRequest<GetUserNameByIdResponseSingleThreaded>
    {
        public GetUserNameByIdRequestSingleThreaded(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}