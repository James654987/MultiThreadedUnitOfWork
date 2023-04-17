using NHibernate;

namespace AsynchronousSessionManagement.NHibernateConfiguration
{
    public interface ISessionProvider
    {
        ISession CurrentSession { get; }
    }
}