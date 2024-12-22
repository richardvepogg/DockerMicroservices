using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RPAMercadoLivre.Negocio.Services;
using RPAMercadoLIvre.Infraestrutura.Services.MessageConsumer;
using RPAMercadoLIvre.Infraestrutura.Services.RabbitMQSender;
using SeuRPAMercadoLivreProjeto.Negocio.Servicos;

namespace RPAMercadoLivre
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Configuração do HostBuilder
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient<IHttpService, HttpService>();
                    services.AddHostedService<RabbitMQRPAConsumer>();
                    services.AddSingleton<IRabbitMQMessageSender, RabbitMQMessageSender>();
                })
                .Build();

            // Inicia o host
            await host.RunAsync();
        }
    }
}
