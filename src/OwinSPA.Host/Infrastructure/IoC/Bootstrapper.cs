using System.Reflection;
using Autofac;
using Autofac.Integration.WebApi;

namespace OwinSPA.Host.Infrastructure.IoC
{
    internal static class Bootstrapper
    {
        public static IContainer Init()
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            RegisterModules(builder);

            return builder.Build();
        }

        private static void RegisterModules(ContainerBuilder builder)
        {
        }
    }
}
