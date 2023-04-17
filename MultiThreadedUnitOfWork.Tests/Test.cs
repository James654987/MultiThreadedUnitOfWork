using System;
using System.Threading.Tasks;
using AsynchronousSessionManagement.IoC;
using AsynchronousSessionManagement.Models;
using AsynchronousSessionManagement.RequestsAndHandlers.Multi_Threaded;
using AsynchronousSessionManagement.RequestsAndHandlers.Single_Threaded;
using AsynchronousSessionManagement.UnitOfWorkAndRepositories;
using MediatR;
using NUnit.Framework;

namespace AsynchronousSessionManagement.Tests
{
    [TestFixture]
    public class Test
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _mediator = Container.Resolve<IMediator>();
            _repository = Container.Resolve<IRepository>();

            using (var uow = UnitOfWork.Start())
            {
                var user = new User("Test User");

                _repository.Add(user);

                uow.Complete();
            }
        }

        [TearDown]
        public void TearDown()
        {
            if (UnitOfWork.Current != null)
            {
                UnitOfWork.Current.Dispose();
            }
        }

        private IMediator _mediator;
        private IRepository _repository;

        [Test]
        public async Task MultiThreadedTest()
        {
            var request = new GetUserNameByIdRequestMultiThreaded(1);

            GetUserNameByIdResponseMultiThreaded response;

            try
            {
                using (var uow = UnitOfWork.Start())
                {
                    response = await _mediator.Send(request);

                    uow.Complete();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            Assert.That(response, Is.Not.Null);
        }

        [Test]
        public async Task SingleThreadedTest()
        {
            var request = new GetUserNameByIdRequestSingleThreaded(1);

            GetUserNameByIdResponseSingleThreaded response;

            using (var uow = UnitOfWork.Start())
            {
                response = await _mediator.Send(request);

                uow.Complete();
            }

            Assert.That(response, Is.Not.Null);
        }
    }
}