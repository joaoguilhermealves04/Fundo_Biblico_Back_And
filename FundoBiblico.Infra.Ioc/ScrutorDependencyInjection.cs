using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using Scrutor;
using System.Reflection;

namespace FundoBiblico.Infra.Ioc
{
    public static  class ScrutorDependencyInjection
    {
        public static IServiceCollection AddClassesMatchingInterfaces(this IServiceCollection services, string @namespace)
        {
            var assemblies = DependencyContext.Default.GetDefaultAssemblyNames().Where(assembly => assembly.FullName.StartsWith(@namespace)).Select(Assembly.Load);

            services.Scan(scan => scan.FromAssemblies(assemblies).AddClasses().UsingRegistrationStrategy(RegistrationStrategy.Skip).AsMatchingInterface().WithScopedLifetime());

            return services;
        }
    }
}
