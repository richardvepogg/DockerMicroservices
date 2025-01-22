using Microsoft.AspNetCore.Builder;
using UserService.IoC.ModuleInitializers;

namespace UserService.IoC
{
    public static class DependencyResolver
    {
        public static void RegisterDependencies(this WebApplicationBuilder builder)
        {
            new InfrastructureModuleInitializer().Initialize(builder);
            new WebApiModuleInitializer().Initialize(builder);
        }
    }
}
