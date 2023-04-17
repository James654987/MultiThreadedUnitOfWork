namespace AsynchronousSessionManagement.IoC
{
    public static class Container
    {
        private static IContainer _underlyingContainer;

        public static T Resolve<T>()
        {
            return _underlyingContainer.Resolve<T>();
        }

        public static void InitializeWith(IContainer container)
        {
            _underlyingContainer = container;
        }
    }
}