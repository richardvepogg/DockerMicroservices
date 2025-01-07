namespace ProductService.WebApi.Features.Products.UpdateProduct
{
    public class UpdateProductRequest
    {
        public int id { get; set; }

        public string name { get; set; }

        public decimal price { get; set; }

        public decimal? priceMercadoLivre { get; set; }

        public decimal? priceValorAmazon { get; set; }
    }
}
