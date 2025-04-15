using System.ComponentModel.DataAnnotations;

namespace ProductService.WebApi.Features.Products.GetAllProducts
{
    public class GetAllProductsResponse
    {
        public IEnumerable<GetAllProductResponse>? getAllProductResponse { get; set; }
        public class GetAllProductResponse
        {
            public string name { get; set; }

            public decimal price { get; set; }

            public decimal? priceMercadoLivre { get; set; }
        }
    }
}
