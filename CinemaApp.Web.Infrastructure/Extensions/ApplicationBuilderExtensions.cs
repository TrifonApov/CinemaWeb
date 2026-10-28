using System.Reflection;

namespace CinemaApp.Web.Infrastructure.Extensions
{
    using Microsoft.Extensions.DependencyInjection;
    
    public static class ApplicationBuilderExtensions
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection serviceCollection, Type repositoryType)
        {
            Assembly repositoriesAssembly = repositoryType.Assembly;

            IEnumerable<Type> repositoriesInterfaces = repositoriesAssembly
                .GetTypes()
                .Where(t => t.IsInterface && t.Name.StartsWith("I") && t.Name.EndsWith("Repository"))
                .ToArray();

            foreach (Type serviceType in repositoriesInterfaces)
            {
                Type implementationType = repositoriesAssembly
                    .GetTypes()
                    .Single(t => t is { IsClass: true, IsAbstract: false } &&
                                 serviceType.IsAssignableFrom(t));

                serviceCollection.AddScoped(serviceType, implementationType);
            }

            return serviceCollection;
        }
    }
}
