using RPAMercadoLivre.Dominio.Enums;
using RPAMercadoLivre.MessageBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPAMercadoLivre.Dominio.Messages
{
    public class ProdutoMessageUpdate : BaseMessage
    {
        public ProdutoMessageUpdate()
        {
            RPAPlataforma = ERPAPlataforma.MercadoLivre;
        }
        public int idProduto { get; set; }

        public decimal? nuValorRPAProduto { get; set; }

        public ERPAPlataforma RPAPlataforma { get; } 
    }
}
