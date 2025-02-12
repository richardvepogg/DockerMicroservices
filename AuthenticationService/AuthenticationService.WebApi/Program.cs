using AuthenticationService.Controllers;
using AuthenticationService.IoC;


var builder = WebApplication.CreateBuilder(args);

builder.RegisterDependencies();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<UsuarioDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
});

app.UseAuthorization();

app.MapControllers();


app.Run();
