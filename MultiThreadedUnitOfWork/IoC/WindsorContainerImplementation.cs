using Castle.Windsor;

namespace MultiThreadedUnitOfWork.IoC
{
    public class WindsorContainerImplementation : IContainer
    {
        public WindsorContainerImplementation(IWindsorContainer underlyingContainer)
        {
            UnderlyingContainer = underlyingContainer;
        }

        private IWindsorContainer UnderlyingContainer { get; }

        public T Resolve<T>()
        {
            return UnderlyingContainer.Resolve<T>();
        }
    }
}