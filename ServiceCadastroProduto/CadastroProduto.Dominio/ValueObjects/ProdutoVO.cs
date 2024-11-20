using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroProduto.Dominio.ValueObjects
{
    public class ProdutoVO
    {
        public int idProduto { get; set; }

        public string nmProduto { get; set; }

        public decimal nuValor { get; set; }
        public string? nmProdutoMercadoLivre { get; set; }

        public decimal? nuValorMercadoLivre { get; set; }
        public string? nmProdutoAmazon { get; set; }

        public decimal? nuValorAmazon { get; set; }
    }
}
