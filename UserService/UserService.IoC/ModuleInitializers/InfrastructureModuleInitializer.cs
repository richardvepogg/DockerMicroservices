using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserService.Data.Context;
using UserService.Data.Repositories;
using UserService.Domain.Interfaces;

namespace UserService.IoC.ModuleInitializers
{
    internal class InfrastructureModuleInitializer : IModuleInitializer
    {
        public void Initialize(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<DbContext>(provider => provider.GetRequiredService<UserDbContext>());

            builder.Services.AddDbContext<UserDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("Default") ?? "",
            p => p.MigrationsHistoryTable("__Migrations")), ServiceLifetime.Scoped
            );
            builder.Services.AddTransient<IUserRepository, UserRepository>();
            builder.Services.AddAutoMapper(typeof(Profile));
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.Load("UserService.Application")));
        }
    }
}
