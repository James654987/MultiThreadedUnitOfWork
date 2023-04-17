using MultiThreadedUnitOfWork.IoC;
using MultiThreadedUnitOfWork.RequestStates;

namespace MultiThreadedUnitOfWork.UnitOfWorkAndRepositories
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