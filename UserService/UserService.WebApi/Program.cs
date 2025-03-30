using UserService.Controllers;
using UserService.IoC;
using UserService.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.RegisterDependencies();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();
builder.Services.AddAutenticationJwt(builder.Configuration);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


app.Run();
