using ProductService.Domain.Entities;
using ProductService.Domain.ValueObjects;

namespace ProductService.WebApi.Features.Products.GetProduct
{
    public class GetProductResponse
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public Price? ProductPrice { get; set; }

        public Price? PriceMercadoLivre { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; } = string.Empty;
    }
}
