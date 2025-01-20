using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RPAMercadoLivre.IoC;

namespace RPAMercadoLivre.Console
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var hostBuilder = Host.CreateDefaultBuilder(args);

            // Chame o método RegisterDependencies para registrar as dependências
            DependencyResolver.RegisterDependencies(hostBuilder);

            var host = hostBuilder.Build();
            await host.RunAsync();
        }
    }
}
