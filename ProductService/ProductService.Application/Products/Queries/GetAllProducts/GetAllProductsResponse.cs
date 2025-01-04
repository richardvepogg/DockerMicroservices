
namespace ProductService.Application.Products.Queries.GetAllProducts
{
    public class GetAllProductsResponse
    {
        List<GetAllProductResponse>? getAllProductResults { get; set; }
        private class GetAllProductResponse
        {
            public string name { get; set; }

            public decimal price { get; set; }

            public decimal? priceMercadoLivre { get; set; }

            public decimal? priceValorAmazon { get; set; }
        }
    }

   
}
