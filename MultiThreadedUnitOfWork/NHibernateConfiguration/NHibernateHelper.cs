using System;
using NHibernate;

namespace MultiThreadedUnitOfWork.NHibernateConfiguration
{
    public static class NHibernateHelper
    {
        public static ISession CurrentSession
        {
            get
            {
                if (SessionProvider == null)
                    throw new Exception("Configure NHibernateHelper.SessionProvider");

                return SessionProvider.CurrentSession ?? throw new Exception("No NHibernate session open");
            }
        }

        public static ISessionFactory SessionFactory { get; set; }
        public static ISessionProvider SessionProvider { get; set; }
    }
}