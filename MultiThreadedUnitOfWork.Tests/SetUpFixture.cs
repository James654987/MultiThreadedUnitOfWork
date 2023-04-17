using Castle.MicroKernel.Registration;
using MultiThreadedUnitOfWork.IoC;
using MultiThreadedUnitOfWork.NHibernateConfiguration;
using MultiThreadedUnitOfWork.RequestStates;
using MultiThreadedUnitOfWork.UnitOfWorkAndRepositories;
using NHibernate;
using NUnit.Framework;

namespace MultiThreadedUnitOfWork.Tests
{
    [SetUpFixture]
    public class SetUpFixture
    {
        private static string _connectionString;
        private DefaultTransientWindsorContainer _container;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            DeployTestDatabase();
            ConfigureContainer();
            ConfigureNHibernate();
            ConfigureMediatR();
        }

        private static void DeployTestDatabase()
        {
            _connectionString = TestDatabase.Deploy("AsynchronousSessionManagementTests");
        }

        private void ConfigureContainer()
        {
            _container = new DefaultTransientWindsorContainer();

            _container.Register(Component.For<IRepository>().ImplementedBy<NHibernateRepository>());
            _container.Register(Component.For<IRequestState>().ImplementedBy<PerThreadRequestState>());
        }

        private void ConfigureNHibernate()
        {
            _container.Register(Component.For<ISessionFactory>()
                .UsingFactoryMethod(x => NHibernateSessionFactory.CreateSessionFactory(_connectionString))
                .LifestyleSingleton());

            NHibernateHelper.SessionProvider = new SessionProvider();
        }

        private void ConfigureMediatR()
        {
            _container.Install(new MediatRRegistry());
        }
    }
}