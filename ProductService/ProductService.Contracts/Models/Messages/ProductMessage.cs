
using ProductService.Contracts.ValueObjects;

namespace ProductService.Contracts.Models.Messages
{
    public class ProductMessage : BaseMessage
    {
        public ProductMessage(ProductVO produtoVO) 
        {
            this.id = produtoVO.id;
            this.name = produtoVO.name;
            this.price = produtoVO.price;
        }
        public int id { get; set; }

        public string name { get; set; }

        public decimal price { get; set; }
    }
}
