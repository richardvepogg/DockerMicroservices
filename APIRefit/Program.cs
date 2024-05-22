using AcessoDados.AcessoBanco;
using APIRefit.Controllers;
using Microsoft.OpenApi.Models;
using Negocio.Extensoes;
using Negocio.Servicos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddExternalApiClients(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "APIRefit", Version = "v1" });
});
builder.Services.AddSingleton<IProdutoRepository, ProdutoRepository>();

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
