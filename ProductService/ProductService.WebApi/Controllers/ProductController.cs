using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductService.Application.Products.Queries.GetAllProducts;
using ProductService.Application.Products.Queries.GetProduct;
using ProductService.Application.Products.Command.CreateProduct;
using ProductService.WebApi.Features.Products.GetProduct;
using ProductService.WebApi.Features.Products.CreateProduct;
using ProductService.WebApi.Features.Products.UpdateProduct;
using ProductService.Application.Products.Command.UpdateProduct;
using ProductService.WebApi.Features.Products.DeleteProduct;
using ProductService.Application.Products.Command.DeleteProduct;
using ProductService.Contracts.Models.Messages;
using ProductService.Infra.Interfaces;
using Azure.Core;
using ProductService.WebApi.Features.Products.GetAllProducts;
using ProductService.Domain.Entities;

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
        private static async Task<IResult> GetAllProducts(IMediator mediator, IMapper mapper, CancellationToken cancellationToken)
        {
            try
            {
                GetAllProductsResult result = await mediator.Send(new GetAllProductsQuerie(), cancellationToken);

                GetAllProductsResponse response = mapper.Map<GetAllProductsResponse>(result);
 
                return Results.Ok(response);
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
                GetProductRequest request = new GetProductRequest{Id = id };

                GetProductQuerie querie = mapper.Map<GetProductQuerie>(request.Id);
                GetProductResult result = await mediator.Send(querie, cancellationToken);
                
                if (result == null) return Results.NotFound();

                return Results.Ok(mapper.Map<GetProductResponse>(result));
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }

        [Authorize(Roles = "Manager")]
        [HttpPost]
        private static async Task<IResult> CreateProduct(CreateProductRequest product, IMediator mediator, IMapper mapper, CancellationToken cancellationToken, IRabbitMQMessageSender message)
        {
            try
            {
                CreateProductCommand command = mapper.Map<CreateProductCommand>(product);

                CreateProductResult result = await mediator.Send(command, cancellationToken);

                if (result == null) return Results.BadRequest();

                message.SendMessage(mapper.Map<ProductMessage>(result));

                return Results.Ok(mapper.Map<GetProductResponse>(result));
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }

        [Authorize(Roles = "Manager")]
        [HttpPut]
        private static async Task<IResult> UpdateProduct(UpdateProductRequest product, IMediator mediator, IMapper mapper, CancellationToken cancellationToken)
        {
            try
            {
                UpdateProductCommand command = mapper.Map<UpdateProductCommand>(product);

                UpdateProductResult? result = await mediator.Send(command, cancellationToken);

                if (result == null) return Results.BadRequest();

                return Results.Ok(mapper.Map<UpdateProductResponse>(result));
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }

        [Authorize(Roles = "Manager")]
        [HttpDelete]
        private static async Task<IResult> DeleteProduct(int id, IMediator mediator, IMapper mapper, CancellationToken cancellationToken)
        {
            try
            {
                DeleteProductRequest request = new DeleteProductRequest {Id=id};
                DeleteProductCommand command = mapper.Map<DeleteProductCommand>(request.Id);

                DeleteProductResult result = await mediator.Send(command, cancellationToken);

                if (result.Success)
                    return Results.Ok("The product was successfully deleted!");

                    return Results.NotFound();
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }
    }
}
