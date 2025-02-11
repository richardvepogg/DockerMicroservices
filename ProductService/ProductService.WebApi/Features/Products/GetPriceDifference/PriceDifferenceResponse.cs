namespace ProductService.WebApi.Features.Products.GetPriceDifference
{
    public class PriceDifferenceResponse
    {

        public decimal priceDifference { get; set; }

        public decimal price { get; set; }

        public decimal? priceMercadoLivre { get; set; }

    }
}
