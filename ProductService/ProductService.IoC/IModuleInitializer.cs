using Microsoft.AspNetCore.Builder;


namespace ProductService.IoC
{
    public interface IModuleInitializer
    {
        void Initialize(WebApplicationBuilder builder);
    }
}
