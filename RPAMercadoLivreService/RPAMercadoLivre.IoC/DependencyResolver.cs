using Microsoft.Extensions.Hosting;
using RPAMercadoLivre.IoC.ModuleInitializers;


namespace RPAMercadoLivre.IoC
{
    public static class DependencyResolver
    {
        public static void RegisterDependencies(this IHostBuilder hostBuilder)
        {
            new InfrastructureModuleInitializer().Initialize(hostBuilder);
        }
    }
}
