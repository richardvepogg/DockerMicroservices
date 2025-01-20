
using Microsoft.Extensions.Hosting;

namespace RPAMercadoLivre.IoC
{
    public interface IModuleInitializer
    {
        void Initialize(IHostBuilder hostBuilder);
    }
}
