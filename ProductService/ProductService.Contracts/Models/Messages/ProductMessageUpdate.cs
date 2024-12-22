
using ProductService.Contracts.Enums;

namespace ProductService.Contracts.Models.Messages
{
    public class ProductMessageUpdate : BaseMessage
    {
        public ProductMessageUpdate()
        {

        }
        public int id { get; set; }

        public decimal? price { get; set; }

        public ERPAMarketPlace RPAMarketPlace { get; set; }
    }

}
