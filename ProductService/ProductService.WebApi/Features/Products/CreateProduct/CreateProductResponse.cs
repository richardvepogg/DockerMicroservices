using ProductService.Domain.Entities;
using ProductService.Domain.ValueObjects;

namespace ProductService.WebApi.Features.Products.CreateProduct
{
    public class CreateProductResponse
    {

        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public Price? ProductPrice { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; } = string.Empty;

        public Category? Category { get; set; }
    }
}
