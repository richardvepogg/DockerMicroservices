using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPAMercadoLivre.Dominio.Entidades
{
    internal class ProdutoMercadoLivre
    {
        [Key]
        public int idproduto { get; set; }

        public string nmproduto { get; set; }

        public decimal nuvalor { get; set; }
    }
}
