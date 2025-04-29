using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductService.Application.Events;
using ProductService.Application.Products.Command.CreateProduct;
using ProductService.Application.Products.Command.UpdateProduct;
using ProductService.Application.Products.Command.UpdateProductPriceMessage;
using ProductService.Application.Products.Queries.GetAllProducts;
using ProductService.Application.Products.Queries.GetProduct;
using ProductService.Application.Products.Queries.PriceDifference;
using ProductService.Application.Services;
using ProductService.Contracts.Interfaces;
using ProductService.Data.Repositories;
using ProductService.Domain.Events;
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

            builder.Services.AddTransient<IEventHandler<ProductInsertedEvent>, ProductInsertedEventHandler>();
            builder.Services.AddTransient<IProductRepository, ProductRepository>();
            builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IProductUpdateHandler, ProductUpdateHandler>();


            builder.Services.AddHostedService<RabbitMQCheckoutConsumer>();
            builder.Services.AddSingleton<IRabbitMQMessageSender, RabbitMQMessageSender>();
            builder.Services.AddAutoMapper(typeof(CreateProductProfile));
            builder.Services.AddAutoMapper(typeof(UpdateProductProfile));
            builder.Services.AddAutoMapper(typeof(UpdateProductMessagePriceProfile));
            builder.Services.AddAutoMapper(typeof(GetProductProfile));
            builder.Services.AddAutoMapper(typeof(PriceDifferenceProfile));
            builder.Services.AddAutoMapper(typeof(GetAllProductsProfile));

            
            builder.Services.AddScoped<IProductService, ProductServices>();

            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.Load("ProductService.Application")));
        }
    }
}
