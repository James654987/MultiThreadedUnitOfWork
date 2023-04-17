using System.Transactions;
using AsynchronousSessionManagement.IoC;
using AsynchronousSessionManagement.RequestStates;
using NHibernate;
using IsolationLevel = System.Data.IsolationLevel;

namespace AsynchronousSessionManagement.UnitOfWorkAndRepositories
{
    public sealed class UnitOfWorkWithNHibernateTransaction : IUnitOfWork
    {
        internal UnitOfWorkWithNHibernateTransaction()
        {
            if (Current != null)
                throw new UnitOfWorkException("Unit of work should not be nested");

            var sessionFactory = Container.Resolve<ISessionFactory>();
            Session = sessionFactory.OpenSession();

            if (Transaction.Current == null)
                Session.BeginTransaction(IsolationLevel.ReadCommitted);

            Current = this;
        }

        private static IUnitOfWork Current
        {
            get => Container.Resolve<IRequestState>().Get<IUnitOfWork>();
            set => Container.Resolve<IRequestState>().Store(value);
        }

        public ISession Session { get; private set; }

        public void Complete()
        {
            var transaction = Session.GetCurrentTransaction();

            if (transaction != null && transaction.IsActive) transaction.Commit();
        }

        public void Dispose()
        {
            try
            {
                if (Session != null)
                {
                    var transaction = Session.GetCurrentTransaction();
                    if (transaction != null
                        && transaction.IsActive
                        && !transaction.WasCommitted
                        && !transaction.WasRolledBack)
                        transaction.Rollback();
                    Session.Dispose();
                    Session = null;
                }
            }
            catch
            {
                // Ignored
            }
            finally
            {
                Current = null;
            }
        }
    }
}