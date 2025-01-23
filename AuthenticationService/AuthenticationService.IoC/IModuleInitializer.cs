using Microsoft.AspNetCore.Builder;

namespace AuthenticationService.IoC
{
    public interface IModuleInitializer
    {
        void Initialize(WebApplicationBuilder builder);
    }
}
