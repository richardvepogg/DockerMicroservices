using Microsoft.AspNetCore.Builder;
using ProductService.IoC.ModuleInitializers;


namespace ProductService.IoC
{
    public static class DependencyResolver
    {
        public static void RegisterDependencies(this WebApplicationBuilder builder)
        {
            new InfrastructureModuleInitializer().Initialize(builder);
        }
    }
}
