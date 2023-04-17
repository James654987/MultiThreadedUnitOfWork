using System.Threading;
using System.Threading.Tasks;
using AsynchronousSessionManagement.Models;
using AsynchronousSessionManagement.UnitOfWorkAndRepositories;
using MediatR;

namespace AsynchronousSessionManagement.RequestsAndHandlers.Single_Threaded
{
    public class GetUserNameByIdRequestHanlerSingleThreaded : IRequestHandler<GetUserNameByIdRequestSingleThreaded, GetUserNameByIdResponseSingleThreaded>
    {
        private readonly IRepository _repository;

        public GetUserNameByIdRequestHanlerSingleThreaded(IRepository repository)
        {
            _repository = repository;
        }

        public Task<GetUserNameByIdResponseSingleThreaded> Handle(GetUserNameByIdRequestSingleThreaded request, CancellationToken cancellationToken)
        {
            var user = _repository.Get<User>(request.Id);

            Task.Delay(1000, cancellationToken).GetAwaiter().GetResult();

            var auditEntry = new Audit(nameof(User));

            _repository.Add(auditEntry);

            return Task.FromResult(new GetUserNameByIdResponseSingleThreaded(user.Name));
        }
    }
}