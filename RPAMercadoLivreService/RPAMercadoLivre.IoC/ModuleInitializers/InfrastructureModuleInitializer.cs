using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RPAMercadoLivre.Domain.Interfaces;
using RPAMercadoLivre.Infraestrutura.Services.RabbitMQSender;
using RPAMercadoLIvre.Infra.Services.MessageConsumer;
using RPAMercadoLIvre.Infra.Services.RabbitMQSender;
using RPAMercadoLivreProjeto.Application.Services;


namespace RPAMercadoLivre.IoC.ModuleInitializers
{
    internal class InfrastructureModuleInitializer : IModuleInitializer
    {
        public void Initialize(IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureServices((context, services) =>
            {
                services.AddTransient<IHttpService, HttpService>();
                services.AddHostedService<RabbitMQRPAConsumer>();
                services.AddSingleton<IRabbitMQMessageSender, RabbitMQMessageSender>();
            });
        }
    }
}

