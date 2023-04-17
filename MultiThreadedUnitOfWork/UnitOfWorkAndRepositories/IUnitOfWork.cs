using System;
using NHibernate;

namespace MultiThreadedUnitOfWork.UnitOfWorkAndRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        ISession Session { get; }
        void Complete();
    }
}