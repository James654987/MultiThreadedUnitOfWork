using NHibernate;

namespace MultiThreadedUnitOfWork.NHibernateConfiguration
{
    public interface ISessionProvider
    {
        ISession CurrentSession { get; }
    }
}