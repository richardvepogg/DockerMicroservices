using UserService.Controllers;
using UserService.IoC;
using UserService.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.RegisterDependencies();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();
builder.Services.AddAutenticationJwt(builder.Configuration);

//builder.Services.AddDbContext<UsuarioDbContext>(options =>
//options.UseSqlServer(builder.Configuration.GetConnectionString("Default") ?? "",
//p => p.MigrationsHistoryTable("__Migrations")), ServiceLifetime.Scoped
//);

var app = builder.Build();


//using (var serviceScope = app.Services.CreateScope())
//{
//    var context = serviceScope.ServiceProvider.GetRequiredService<UsuarioDbContext>();

//    await context.Database.EnsureCreatedAsync();

//}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


app.Run();
