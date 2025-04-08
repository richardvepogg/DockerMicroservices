using UserService.IoC;
using UserService.WebApi.Extensions;
using UserService.WebApi.Features.Users.CreateUser;
using UserService.WebApi.Features.Users.DeleteUser;
using UserService.WebApi.Features.Users.GetAllUsers;
using UserService.WebApi.Features.Users.GetUser;
using UserService.WebApi.Features.Users.UpdateUser;

var builder = WebApplication.CreateBuilder(args);

builder.RegisterDependencies();
builder.Services.AddAutoMapper(typeof(CreateUserProfile).Assembly);
builder.Services.AddAutoMapper(typeof(DeleteUserProfile).Assembly);
builder.Services.AddAutoMapper(typeof(GetAllUsersProfile).Assembly);
builder.Services.AddAutoMapper(typeof(GetUserProfile).Assembly);
builder.Services.AddAutoMapper(typeof(UpdateUserProfile).Assembly);


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
