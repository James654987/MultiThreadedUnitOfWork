using AsynchronousSessionManagement.IoC;
using AsynchronousSessionManagement.NHibernateConfiguration;
using AsynchronousSessionManagement.UnitOfWorkAndRepositories;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using NHibernate;

namespace AsynchronousSessionManagement
{
    internal static class Program
    {
        private static WindsorContainer _container;

        private static void Main()
        {
            ConfigureContainer();
            ConfigureNHibernate();
            ConfigureMediatR();
        }

        private static void ConfigureContainer()
        {
            _container = new DefaultTransientWindsorContainer();

            _container.Register(Component.For<IRepository>().ImplementedBy<NHibernateRepository>());
        }

        private static void ConfigureNHibernate()
        {
            _container.Register(Component.For<ISessionFactory>()
                .UsingFactoryMethod(x => NHibernateSessionFactory.CreateSessionFactory("connection string"))
                .LifestyleSingleton());
        }

        private static void ConfigureMediatR()
        {
            _container.Install(new MediatRRegistry());
        }
    }
}