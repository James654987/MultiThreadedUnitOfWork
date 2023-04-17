using NHibernate;

namespace AsynchronousSessionManagement.NHibernateConfiguration
{
    public class SessionProvider : ISessionProvider
    {
        public ISession CurrentSession => UnitOfWorkAndRepositories.UnitOfWork.Current != null
            ? UnitOfWorkAndRepositories.UnitOfWork.Current.Session
            : null;
    }
}