using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace MultiThreadedUnitOfWork.IoC
{
    public sealed class DefaultTransientWindsorContainer : WindsorContainer
    {
        public DefaultTransientWindsorContainer()
        {
            Kernel.ComponentModelCreated += RegisterComponentAsTransientByDefault;

            var container = new WindsorContainerImplementation(this);
            Register(Component.For<IContainer>().Instance(container));
            Container.InitializeWith(container);
        }

        private static void RegisterComponentAsTransientByDefault(ComponentModel model)
        {
            if (model.LifestyleType == LifestyleType.Undefined)
                model.LifestyleType = LifestyleType.Transient;
        }
    }
}