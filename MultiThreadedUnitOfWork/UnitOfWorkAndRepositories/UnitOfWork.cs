using AsynchronousSessionManagement.IoC;
using AsynchronousSessionManagement.RequestStates;

namespace AsynchronousSessionManagement.UnitOfWorkAndRepositories
{
    public static class UnitOfWork
    {
        public static IUnitOfWork Current => Container.Resolve<IRequestState>().Get<IUnitOfWork>();

        public static IUnitOfWork Start()
        {
            return new UnitOfWorkWithNHibernateTransaction();
        }
    }
}