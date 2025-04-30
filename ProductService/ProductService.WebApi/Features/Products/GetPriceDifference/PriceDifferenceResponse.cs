using ProductService.Domain.ValueObjects;

namespace ProductService.WebApi.Features.Products.GetPriceDifference
{
    public class PriceDifferenceResponse
    {

        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public Price? ProductPrice { get; set; }

        public Price? PriceMercadoLivre { get; set; }

        public decimal priceDifference { get; set; }

    }
}
