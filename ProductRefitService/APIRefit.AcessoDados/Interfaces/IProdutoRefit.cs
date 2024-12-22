using CadastroProduto.Dominio.Entidades;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace APIRefit.AcessoDados.Interfaces
{
        public interface IProdutoRefit
        {
            [Get("/Produto/{id}")]
            Task<Produto> ObterProduto(int Id);

            [Get("/Produtos")]
            Task<IEnumerable<Produto>> ObterProdutos();

            [Post("/Produto")]
            Task<string> InserirProduto([Body] Produto produto);

            [Put("/Produto")]
            Task<string> AtualizarProduto([Body] Produto produto);

            [Delete("/Produto/{id}")]
            Task<string> DeletarProduto(int Id);
        }
}
