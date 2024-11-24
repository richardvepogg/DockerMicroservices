using RPAMercadoLivre.Dominio.Enums;
using RPAMercadoLivre.MessageBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPAMercadoLivre.Dominio.ValueObjects
{
    public class ProdutoMessage : BaseMessage
    {
        public int idProduto { get; set; }

        public string nmProduto { get; set; }

        public decimal nuValor { get; set; }
    }
}
