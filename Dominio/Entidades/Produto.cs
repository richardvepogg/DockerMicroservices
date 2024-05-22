
using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades
{
    public class Produto
    {
        [Key]
        public int idproduto { get; set; }

        public  string nmproduto { get; set; }

        public decimal nuvalor { get; set; }
    }
}
