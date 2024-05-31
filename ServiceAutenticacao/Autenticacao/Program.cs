using AcessoDados.AcessoBanco;
using AcessoDados.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Negocio.Servicos;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();




var app = builder.Build();



app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
});

app.UseAuthorization();

app.MapControllers();

app.Run();
