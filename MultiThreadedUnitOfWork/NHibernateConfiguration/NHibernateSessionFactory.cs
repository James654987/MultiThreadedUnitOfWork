using System.Collections.Generic;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using MultiThreadedUnitOfWork.Models;
using NHibernate;

namespace MultiThreadedUnitOfWork.NHibernateConfiguration
{
    public static class NHibernateSessionFactory
    {
        public static ISessionFactory CreateSessionFactory(string connectionString)
        {
            var factory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(connectionString))
                .Mappings(mappings => { mappings.FluentMappings.AddFromAssemblyOf<User>(); })
                .BuildSessionFactory();

            NHibernateHelper.SessionFactory = new NHibernateHelperSessionFactoryAdapter();
            NHibernateHelper.SessionProvider = new SessionProvider();

            return factory;
        }
    }
}