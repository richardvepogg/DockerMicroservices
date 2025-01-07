using AutoMapper;
using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Threading;
using ProductService.Application.Products.Queries.GetAllProducts;
using ProductService.Application.Products.Queries.GetProduct;
using ProductService.Application.Products.Command.CreateProduct;

namespace ProductService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public static class ProductController
    {

        public static void ConfigureApi(this WebApplication app)
        {
            app.MapGet("/Products", GetAllProducts);
            app.MapGet("/Product/{id}", GetProduct);
            app.MapPost("/Product", CreateProduct);
            app.MapPut("/Product", UpdateProduct);
            app.MapDelete("/Product/{id}", DeleteProduct);

        }

        [Authorize(Roles = "Employe, Manager")]
        [HttpGet]
        private static async Task<IResult> GetAllProducts(IMediator mediator, CancellationToken cancellationToken)
        {
            try
            {
                GetAllProductsResult products = await mediator.Send(new GetAllProductsQuerie(), cancellationToken);

                return Results.Ok(products);
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }

        [Authorize(Roles = "Employe, Manager")]
        [HttpGet("{id}")]
        private static async Task<IResult> GetProduct(int id,IMediator mediator, IMapper mapper, CancellationToken cancellationToken)
        {
            try
            {
                GetProductQuerie querie = new GetProductQuerie(id);

                var command = mapper.Map<CreateProductCommand>(id);
                var response = await mediator.Send(command, cancellationToken);
                
                if (produtoVO == null) return Results.NotFound();

                return Results.Ok(produtoVO);
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }

        [Authorize(Roles = "Manager")]
        [HttpPost]
        private static IResult CreateProduct(ProductVO produtoVO, IProductRepository data, IRabbitMQMessageSender message)
        {
            try
            {
                produtoVO.id = data.Add(produtoVO);


                message.SendMessage(new ProductMessage(produtoVO));


                return Results.Ok("O produto foi inserido com sucesso!");
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }

        [Authorize(Roles = "Manager")]
        [HttpPut]
        private static IResult UpdateProduct(ProductVO produtoVO, IProductRepository data)
        {
            try
            {
                data.Update(produtoVO);

                return Results.Ok("O produto foi atualizado com sucesso!");
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }

        [Authorize(Roles = "Manager")]
        [HttpDelete]
        private static IResult DeleteProduct(int id, IProductRepository data)
        {
            try
            {
                data.Remove(id);

                return Results.Ok("O produto foi deletado com sucesso!");
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }
    }
}
