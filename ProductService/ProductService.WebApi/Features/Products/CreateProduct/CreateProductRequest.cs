namespace ProductService.WebApi.Features.Products.CreateProduct
{
    public class CreateProductRequest
    {
        public int id { get; set; }

        public string name { get; set; }

        public decimal price { get; set; }

        public decimal? priceMercadoLivre { get; set; }
    }
}
