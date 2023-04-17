using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using MediatR;
using MultiThreadedUnitOfWork.RequestsAndHandlers.Multi_Threaded;

namespace MultiThreadedUnitOfWork.IoC
{
    public class MediatRRegistry : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel));
            container.Kernel.AddHandlersFilter(new ContravariantFilter());

            var assembly = Classes.FromAssemblyContaining(typeof(GetUserNameByIdRequestMultiThreaded));
            container.Register(assembly.BasedOn(typeof(IRequestHandler<>)).WithServiceAllInterfaces().AllowMultipleMatches());
            container.Register(assembly.BasedOn(typeof(IRequestHandler<,>)).WithServiceAllInterfaces().AllowMultipleMatches());

            container.Register(Component.For<IMediator>().ImplementedBy<Mediator>());

            container.Register(Component.For<ServiceFactory>().UsingFactoryMethod<ServiceFactory>(k => type =>
            {
                var enumerableType = type.GetInterfaces().Concat(new[] { type }).FirstOrDefault(t =>
                    t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IEnumerable<>));
                var service = enumerableType?.GetGenericArguments()[0];
                var resolvedType = enumerableType != null ? k.ResolveAll(service) : k.Resolve(type);

                return resolvedType;
            }));
        }
    }

    public class ContravariantFilter : IHandlersFilter
    {
        public bool HasOpinionAbout(Type service)
        {
            if (!service.IsGenericType)
                return false;

            var genericType = service.GetGenericTypeDefinition();
            var genericArguments = genericType.GetGenericArguments();
            return genericArguments.Length == 1 && genericArguments.Single().GenericParameterAttributes
                .HasFlag(GenericParameterAttributes.Contravariant);
        }

        public IHandler[] SelectHandlers(Type service, IHandler[] handlers)
        {
            return handlers;
        }
    }
}