using ProductService.IoC;
using ProductService.WebApi.Extensions;
using ProductService.WebApi.Features.Products.CreateProduct;
using ProductService.WebApi.Features.Products.DeleteProduct;
using ProductService.WebApi.Features.Products.GetAllProducts;
using ProductService.WebApi.Features.Products.GetPriceDifference;
using ProductService.WebApi.Features.Products.GetProduct;
using ProductService.WebApi.Features.Products.UpdateProduct;

var builder = WebApplication.CreateBuilder(args);

builder.RegisterDependencies();
builder.Services.AddAutoMapper(typeof(GetAllProductsProfileWeb).Assembly);
builder.Services.AddAutoMapper(typeof(CreateProductProfile).Assembly);
builder.Services.AddAutoMapper(typeof(DeleteProductProfile).Assembly);
builder.Services.AddAutoMapper(typeof(PriceDifferenceProfile).Assembly);
builder.Services.AddAutoMapper(typeof(GetProductProfile).Assembly);
builder.Services.AddAutoMapper(typeof(UpdateProductProfile).Assembly);

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
