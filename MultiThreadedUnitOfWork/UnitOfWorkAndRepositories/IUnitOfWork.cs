using System;
using NHibernate;

namespace AsynchronousSessionManagement.UnitOfWorkAndRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        ISession Session { get; }
        void Complete();
    }
}