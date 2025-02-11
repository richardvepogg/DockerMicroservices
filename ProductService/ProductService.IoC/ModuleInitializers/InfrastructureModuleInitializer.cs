using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductService.Application.Services;
using ProductService.Contracts.Interfaces;
using ProductService.Domain.Interfaces;
using ProductService.Domain.Services;
using ProductService.Infra.Services.MessageConsumer;
using ProductService.Infra.Services.RabbitMQSender;

namespace ProductService.IoC.ModuleInitializers
{
    internal class InfrastructureModuleInitializer : IModuleInitializer
    {
        public void Initialize(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<DbContext>(provider => provider.GetRequiredService<ProductDbContext>());
           
            builder.Services.AddDbContext<ProductDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("Default") ?? "",
            p => p.MigrationsHistoryTable("__Migrations")), ServiceLifetime.Scoped
            );

            builder.Services.AddTransient<IProductRepository, ProductRepository>();
            builder.Services.AddHostedService<RabbitMQCheckoutConsumer>();
            builder.Services.AddSingleton<IRabbitMQMessageSender, RabbitMQMessageSender>();
            builder.Services.AddAutoMapper(typeof(Profile));
            builder.Services.AddScoped<IProductService, ProductServices>();

            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.Load("ProductService.Application")));
        }
    }
}
