using AsynchronousSessionManagement.NHibernateConfiguration;
using NHibernate;

namespace AsynchronousSessionManagement.UnitOfWorkAndRepositories
{
    public class NHibernateRepository : IRepository
    {
        private static ISession Session => NHibernateHelper.CurrentSession;

        public T Get<T>(int id)
        {
            return Session.Get<T>(id);
        }

        public void Add<T>(T entity)
        {
            Session.Save(entity);
        }
    }
}