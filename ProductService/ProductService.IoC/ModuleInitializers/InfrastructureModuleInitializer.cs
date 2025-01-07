using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProductService.Application.Services;
using ProductService.Data.Context;
using ProductService.Domain.Interfaces;

namespace ProductService.IoC.ModuleInitializers
{
    internal class InfrastructureModuleInitializer : IModuleInitializer
    {
        public void Initialize(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<DbContext>(provider => provider.GetRequiredService<ProductDbContext>());
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
