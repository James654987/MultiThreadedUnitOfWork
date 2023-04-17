using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Engine;
using NHibernate.Metadata;
using NHibernate.Stat;

namespace AsynchronousSessionManagement.NHibernateConfiguration
{
    public sealed class NHibernateHelperSessionFactoryAdapter : ISessionFactory
    {
        private static ISessionFactory CurrentSessionFactoryInUnitOfWork => UnitOfWorkAndRepositories.UnitOfWork.Current.Session.SessionFactory;

        public void Dispose()
        {
            CurrentSessionFactoryInUnitOfWork.Dispose();
        }

        public async Task CloseAsync(CancellationToken cancellationToken = default)
        {
            await CurrentSessionFactoryInUnitOfWork.CloseAsync(cancellationToken);
        }

        public async Task EvictAsync(Type persistentClass, CancellationToken cancellationToken = default)
        {
            await CurrentSessionFactoryInUnitOfWork.EvictAsync(persistentClass, cancellationToken);
        }

        public async Task EvictAsync(Type persistentClass, object id, CancellationToken cancellationToken = default)
        {
            await CurrentSessionFactoryInUnitOfWork.EvictAsync(persistentClass, id, cancellationToken);
        }

        public async Task EvictEntityAsync(string entityName, CancellationToken cancellationToken = default)
        {
            await CurrentSessionFactoryInUnitOfWork.EvictEntityAsync(entityName, cancellationToken);
        }

        public async Task EvictEntityAsync(string entityName, object id, CancellationToken cancellationToken = default)
        {
            await CurrentSessionFactoryInUnitOfWork.EvictEntityAsync(entityName, id, cancellationToken);
        }

        public async Task EvictCollectionAsync(string roleName, CancellationToken cancellationToken = default)
        {
            await CurrentSessionFactoryInUnitOfWork.EvictCollectionAsync(roleName, cancellationToken);
        }

        public async Task EvictCollectionAsync(string roleName, object id, CancellationToken cancellationToken = default)
        {
            await CurrentSessionFactoryInUnitOfWork.EvictCollectionAsync(roleName, id, cancellationToken);
        }

        public async Task EvictQueriesAsync(CancellationToken cancellationToken = default)
        {
            await CurrentSessionFactoryInUnitOfWork.EvictQueriesAsync(cancellationToken);
        }

        public async Task EvictQueriesAsync(string cacheRegion, CancellationToken cancellationToken = default)
        {
            await CurrentSessionFactoryInUnitOfWork.EvictQueriesAsync(cacheRegion, cancellationToken);
        }

        public ISessionBuilder WithOptions()
        {
            return CurrentSessionFactoryInUnitOfWork.WithOptions();
        }

        public ISession OpenSession(DbConnection connection)
        {
            return UnitOfWorkAndRepositories.UnitOfWork.Current.Session;
        }

        public ISession OpenSession(IInterceptor sessionLocalInterceptor)
        {
            return UnitOfWorkAndRepositories.UnitOfWork.Current.Session;
        }

        public ISession OpenSession(DbConnection conn, IInterceptor sessionLocalInterceptor)
        {
            return UnitOfWorkAndRepositories.UnitOfWork.Current.Session;
        }

        public ISession OpenSession()
        {
            return UnitOfWorkAndRepositories.UnitOfWork.Current.Session;
        }

        public IStatelessSessionBuilder WithStatelessOptions()
        {
            throw new NotSupportedException();
        }

        public IStatelessSession OpenStatelessSession()
        {
            throw new NotSupportedException();
        }

        public IStatelessSession OpenStatelessSession(DbConnection connection)
        {
            throw new NotSupportedException();
        }

        public IClassMetadata GetClassMetadata(Type persistentClass)
        {
            return CurrentSessionFactoryInUnitOfWork.GetClassMetadata(persistentClass);
        }

        public IClassMetadata GetClassMetadata(string entityName)
        {
            return CurrentSessionFactoryInUnitOfWork.GetClassMetadata(entityName);
        }

        public ICollectionMetadata GetCollectionMetadata(string roleName)
        {
            return CurrentSessionFactoryInUnitOfWork.GetCollectionMetadata(roleName);
        }

        public IDictionary<string, IClassMetadata> GetAllClassMetadata()
        {
            return CurrentSessionFactoryInUnitOfWork.GetAllClassMetadata();
        }

        public IDictionary<string, ICollectionMetadata> GetAllCollectionMetadata()
        {
            return CurrentSessionFactoryInUnitOfWork.GetAllCollectionMetadata();
        }

        public void Close()
        {
            CurrentSessionFactoryInUnitOfWork.Close();
        }

        public void Evict(Type persistentClass)
        {
            CurrentSessionFactoryInUnitOfWork.Evict(persistentClass);
        }

        public void Evict(Type persistentClass, object id)
        {
            CurrentSessionFactoryInUnitOfWork.Evict(persistentClass, id);
        }

        public void EvictEntity(string entityName)
        {
            CurrentSessionFactoryInUnitOfWork.EvictEntity(entityName);
        }

        public void EvictEntity(string entityName, object id)
        {
            CurrentSessionFactoryInUnitOfWork.EvictEntity(entityName, id);
        }

        public void EvictCollection(string roleName)
        {
            CurrentSessionFactoryInUnitOfWork.EvictCollection(roleName);
        }

        public void EvictCollection(string roleName, object id)
        {
            CurrentSessionFactoryInUnitOfWork.EvictCollection(roleName, id);
        }

        public void EvictQueries()
        {
            CurrentSessionFactoryInUnitOfWork.EvictQueries();
        }

        public void EvictQueries(string cacheRegion)
        {
            CurrentSessionFactoryInUnitOfWork.EvictQueries(cacheRegion);
        }

        public FilterDefinition GetFilterDefinition(string filterName)
        {
            return CurrentSessionFactoryInUnitOfWork.GetFilterDefinition(filterName);
        }

        public ISession GetCurrentSession()
        {
            return UnitOfWorkAndRepositories.UnitOfWork.Current.Session;
        }

        public IStatistics Statistics => CurrentSessionFactoryInUnitOfWork.Statistics;
        public bool IsClosed => CurrentSessionFactoryInUnitOfWork.IsClosed;
        public ICollection<string> DefinedFilterNames => CurrentSessionFactoryInUnitOfWork.DefinedFilterNames;
    }
}