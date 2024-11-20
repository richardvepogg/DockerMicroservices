using CadastroProduto.AcessoDados.AcessoBanco;
using CadastroProduto.Dominio.Entidades;
using CadastroProduto.Dominio.Messages;
using CadastroProduto.Dominio.ValueObjects;
using CadastroProduto.Infraestrutura.Services.RabbitMQSender;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CadastroProduto.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public static class ProdutoController
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
        private static IResult ObterProdutos(IProdutoRepository data)
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
        private static IResult ObterProduto(int id, IProdutoRepository data)
        {
            try
            {
                ProdutoVO produtoVO = data.Find(id);
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
        private static IResult Inserirproduto(ProdutoVO produtoVO, IProdutoRepository data, IRabbitMQMessageSender message)
        {
            try
            {
                produtoVO.idProduto = data.Add(produtoVO);


                message.SendMessage(new ProdutoMessage(produtoVO), "produtoqueue");


                return Results.Ok("O produto foi inserido com sucesso!");
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }

        [Authorize(Roles = "Manager")]
        [HttpPut]
        private static IResult AtualizarProduto(ProdutoVO produtoVO, IProdutoRepository data)
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
        private static IResult DeletarProduto(int id, IProdutoRepository data)
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
