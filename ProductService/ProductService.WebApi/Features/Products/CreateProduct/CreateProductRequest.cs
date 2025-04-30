using ProductService.Domain.Entities;
using ProductService.Domain.Enums;

namespace ProductService.WebApi.Features.Products.CreateProduct
{
    public class CreateProductRequest
    {
        public int id { get; set; }

        public string name { get; set; } = string.Empty;

        public decimal price { get; set; }

        public Currency Currency { get; set; }

        public int IdCategory { get; set; }
    }
}
