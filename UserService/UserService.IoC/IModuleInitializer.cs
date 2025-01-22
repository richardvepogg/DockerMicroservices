
using Microsoft.AspNetCore.Builder;

namespace UserService.IoC
{
    public interface IModuleInitializer
    {
        void Initialize(WebApplicationBuilder builder);
    }
}
