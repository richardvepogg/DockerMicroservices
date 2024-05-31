using AcessoDados.Interfaces;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace APIRefit.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public static class ProdutosController
    {
        public static void ConfigureApi(this WebApplication app)
        {
            app.MapGet("/Produtos", ObterProdutos);
            app.MapGet("/Produto/{id}", ObterProduto);
            app.MapPost("/Produto", InserirProduto);
            app.MapPut("/Produto", AtualizarProduto);
            app.MapDelete("/Produto/{id}", DeletarProduto);

        }

        [HttpGet]
        public static async Task<IResult> ObterProdutos(IProdutoRefit _produtoRefit)
        {
            try
            {
                var produto = await _produtoRefit.ObterProdutos().ConfigureAwait(false);
                if (produto == null) return Results.NotFound();

                return Results.Ok(produto);
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }


        [HttpGet]
        [Route("Id")]
        private static async Task<IResult> ObterProduto(int Id, IProdutoRefit _produtoRefit)
        {
            try
            {
                var produto = await _produtoRefit.ObterProduto(Id).ConfigureAwait(false);
                if (produto == null)
                    return Results.NotFound();

                return Results.Ok(produto);
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }



        [HttpPost]
        private static async Task<IResult> InserirProduto(Produto produto, IProdutoRefit _produtoRefit)
        {
            try
            {
                var result = await _produtoRefit.InserirProduto(produto).ConfigureAwait(false);
                return Results.Ok(result);
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }


        [HttpPut]
        private static async Task<IResult> AtualizarProduto(Produto produto, IProdutoRefit _produtoRefit)
        {
            try
            {
                var result = await _produtoRefit.AtualizarProduto(produto).ConfigureAwait(false);
                return Results.Ok(result);
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }


        [HttpDelete]
        [Route("Id")]
        private static async Task<IResult> DeletarProduto(int Id, IProdutoRefit _produtoRefit)
        {
            try
            {
                var result = await _produtoRefit.DeletarProduto(Id).ConfigureAwait(false);
                return Results.Ok(result);
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }

    }
}
