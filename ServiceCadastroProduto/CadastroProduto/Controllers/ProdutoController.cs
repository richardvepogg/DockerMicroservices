using CadastroProduto.AcessoDados.AcessoBanco;
using CadastroProduto.Dominio.Entidades;
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

        [Authorize(Roles = "Employee")]
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

        [Authorize(Roles = "Employee")]
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

        [Authorize(Roles = "Manager")]
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

        [Authorize(Roles = "Manager")]
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
