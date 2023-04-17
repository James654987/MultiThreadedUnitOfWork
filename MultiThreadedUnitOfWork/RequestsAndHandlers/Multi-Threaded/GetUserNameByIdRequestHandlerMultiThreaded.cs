using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MultiThreadedUnitOfWork.Models;
using MultiThreadedUnitOfWork.UnitOfWorkAndRepositories;

namespace MultiThreadedUnitOfWork.RequestsAndHandlers.Multi_Threaded
{
    public class GetUserNameByIdRequestHandlerMultiThreaded : IRequestHandler<GetUserNameByIdRequestMultiThreaded, GetUserNameByIdResponseMultiThreaded>
    {
        private readonly IRepository _repository;

        public GetUserNameByIdRequestHandlerMultiThreaded(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetUserNameByIdResponseMultiThreaded> Handle(GetUserNameByIdRequestMultiThreaded request, CancellationToken cancellationToken)
        {
            var user = _repository.Get<User>(request.Id);

            await Task.Delay(1000, cancellationToken);

            var auditEntry = new Audit(nameof(User));

            _repository.Add(auditEntry);

            return new GetUserNameByIdResponseMultiThreaded(user.Name);
        }
    }
}