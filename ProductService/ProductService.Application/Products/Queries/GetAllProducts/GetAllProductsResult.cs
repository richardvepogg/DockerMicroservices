
namespace ProductService.Application.Products.Queries.GetAllProducts
{
    public class GetAllProductsResult
    {
        public IEnumerable<GetAllProductResult>? getAllProductResults { get; set; }
        public class GetAllProductResult
        {
            public string name { get; set; }

            public decimal price { get; set; }

            public decimal? priceMercadoLivre { get; set; }
        }
    }

   
}
