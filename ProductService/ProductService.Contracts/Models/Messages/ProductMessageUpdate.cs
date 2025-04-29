
using ProductService.Contracts.Enums;

namespace ProductService.Contracts.Models.Messages
{
    public class ProductMessageUpdate : BaseMessage
    {
        public ProductMessageUpdate()
        {
            RPAPlataform = ERPAMarketPlace.MercadoLivre;
        }
        public int id { get; set; }

        public decimal? value { get; set; }

        public ERPAMarketPlace RPAPlataform { get; }
    }

}
