
namespace ProductService.Application.Products.Queries.GetAllProducts
{
    public class GetAllProductsResult
    {
        IEnumerable<GetAllProductResult>? getAllProductResults { get; set; }
        private class GetAllProductResult
        {
            public string name { get; set; }

            public decimal price { get; set; }

            public decimal? priceMercadoLivre { get; set; }

            public decimal? priceValorAmazon { get; set; }
        }
    }

   
}
