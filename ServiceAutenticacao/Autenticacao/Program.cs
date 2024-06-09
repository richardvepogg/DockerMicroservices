using Autenticacao.AcessoDados.AcessoBanco;
using Autenticacao.AcessoDados.Contexto;
using Autenticacao.Controllers;
using Autenticacao.Negocio.Interfaces;
using Autenticacao.Negocio.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<UsuarioDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddTransient<ITokenService, TokenService>();
builder.Services.AddTransient<IUsuariosRepository, UsuariosRepository>();


var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
});

app.UseAuthorization();

app.MapControllers();
app.ConfigureApi();


app.Run();
