using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserService.Application.Users.Command.CreateUser;
using UserService.Application.Users.Command.UpdateUser;
using UserService.Application.Users.Queries.GetAllUsers;
using UserService.Application.Users.Queries.GetUser;
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
            builder.Services.AddAutoMapper(typeof(CreateUserProfile));
            builder.Services.AddAutoMapper(typeof(UpdateUserProfile));
            builder.Services.AddAutoMapper(typeof(GetUserProfile));
            builder.Services.AddAutoMapper(typeof(GetAllUsersProfile));


            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.Load("UserService.Application")));
        }
    }
}
