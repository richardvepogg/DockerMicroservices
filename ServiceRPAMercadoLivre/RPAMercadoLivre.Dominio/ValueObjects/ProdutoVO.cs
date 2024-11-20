using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPAMercadoLivre.Dominio.ValueObjects
{
    internal class ProdutoVO
    {
        public int idProduto { get; set; }

        public string nmProduto { get; set; }

        public decimal nuValor { get; set; }
    }
}
