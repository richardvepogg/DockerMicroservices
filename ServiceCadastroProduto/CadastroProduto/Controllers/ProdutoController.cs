using AcessoDados.AcessoBanco;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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

        [HttpGet("{id}")]
        private static IResult ObterProduto(int id, IProdutoRepository data)
        {
            try
            {
                var produto = data.Find(id);
                if (produto == null) return Results.NotFound();

                return Results.Ok(produto);
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }

        [HttpPost]
        private static IResult Inserirproduto(Produto produto, IProdutoRepository data)
        {
            try
            {
                data.Add(produto);
                return Results.Ok("O produto foi inserido com sucesso!");
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }

        [HttpPut]
        private static IResult AtualizarProduto(Produto produto, IProdutoRepository data)
        {
            try
            {
                data.Update(produto);

                return Results.Ok("O produto foi atualizado com sucesso!");
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }

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
