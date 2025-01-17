
using ProductService.Contracts.ValueObjects;

namespace ProductService.Contracts.Models.Messages
{
    public class ProductMessage : BaseMessage
    {
        public int id { get; set; }

        public string name { get; set; }

        public decimal price { get; set; }
    }
}
