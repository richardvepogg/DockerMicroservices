using AcessoDados.AcessoBanco;
using AcessoDados.Contexto;
using CadastroProduto.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Negocio.Servicos;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<ProdutoDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Default") ?? "",
p => p.MigrationsHistoryTable("Default")), ServiceLifetime.Scoped
);

builder.Services.AddTransient<IProdutoRepository, ProdutoRepository>();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CadastroProduto", Version = "v1" });
});

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
