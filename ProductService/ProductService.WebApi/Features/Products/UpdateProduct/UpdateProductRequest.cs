using ProductService.Domain.ValueObjects;

namespace ProductService.WebApi.Features.Products.UpdateProduct
{
    public class UpdateProductRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Price ProductPrice { get; set; }

        public Price? PriceMercadoLivre { get; set; }

        public int CategoryId { get; set; }
    }
}
