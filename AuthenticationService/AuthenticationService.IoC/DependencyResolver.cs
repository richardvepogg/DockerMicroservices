using AuthenticationService.IoC.ModuleInitializers;
using Microsoft.AspNetCore.Builder;

namespace AuthenticationService.IoC
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
