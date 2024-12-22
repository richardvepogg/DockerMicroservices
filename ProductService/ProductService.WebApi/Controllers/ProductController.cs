using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductService.Contracts.Models.Messages;
using ProductService.Contracts.ValueObjects;
using ProductService.Infra.Interfaces;

namespace ProductService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public static class ProductController
    {

        public static void ConfigureApi(this WebApplication app)
        {
            app.MapGet("/Produtos", ObterProdutos);
            app.MapGet("/Produto/{id}", ObterProduto);
            app.MapPost("/Produto", Inserirproduto);
            app.MapPut("/Produto", AtualizarProduto);
            app.MapDelete("/Produto/{id}", DeletarProduto);

        }

        [Authorize(Roles = "Employe, Manager")]
        [HttpGet]
        private static IResult ObterProdutos(IProductRepository data)
        {
            try
            {
                return Results.Ok(data.GetAll());
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }

        [Authorize(Roles = "Employe, Manager")]
        [HttpGet("{id}")]
        private static IResult ObterProduto(int id, IProductRepository data)
        {
            try
            {
                ProductVO produtoVO = data.Find(id);
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
        private static IResult Inserirproduto(ProductVO produtoVO, IProductRepository data, IRabbitMQMessageSender message)
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
        private static IResult AtualizarProduto(ProductVO produtoVO, IProductRepository data)
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
        private static IResult DeletarProduto(int id, IProductRepository data)
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
