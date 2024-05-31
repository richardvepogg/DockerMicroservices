using AcessoDados.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;


namespace APIRefit.Negocio.Extensoes
{
    public static class ServiceCollectionExtensions
    {
        private const string ConfigExternalCadastroProduto = "External:CadastroProduto";

        public static IServiceCollection AddExternalApiClients(this IServiceCollection services, IConfiguration configuration)
        {
            var baseUrlCadastroProduto = configuration[ConfigExternalCadastroProduto];

            services.AddRefitClient<IProdutoRefit>()
                .ConfigureHttpClient(config => config.BaseAddress = new Uri(baseUrlCadastroProduto!));


            return services;
        }
    }
}
