using ProductService.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace ProductService.WebApi.Features.Products.GetAllProducts
{
    public class GetAllProductsResponse
    {
        public IEnumerable<GetAllProductResponse>? getAllProductResponse { get; set; }
        public class GetAllProductResponse
        {
            public int Id { get; set; }

            public string Name { get; set; } = string.Empty;

            public Price? ProductPrice { get; set; }

            public Price? PriceMercadoLivre { get; set; }

            public int CategoryId { get; set; }

            public string CategoryName { get; set; } = string.Empty;
        }
    }
}
