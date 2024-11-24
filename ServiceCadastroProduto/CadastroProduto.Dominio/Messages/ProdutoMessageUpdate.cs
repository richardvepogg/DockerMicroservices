using CadastroProduto.Dominio.Enums;
using CadastroProduto.MessageBus;

namespace CadastroProduto.Dominio.Messages
{
    public class ProdutoMessageUpdate : BaseMessage
    {
        public ProdutoMessageUpdate()
        {

        }
        public int idProduto { get; set; }

        public decimal? nuValorRPAProduto { get; set; }

        public ERPAPlataforma RPAPlataforma { get; set; }
    }

}
