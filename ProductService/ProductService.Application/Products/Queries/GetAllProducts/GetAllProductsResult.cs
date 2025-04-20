
using ProductService.Domain.Entities;
using ProductService.Domain.ValueObjects;

namespace ProductService.Application.Products.Queries.GetAllProducts
{
    public class GetAllProductsResult
    {
        public IEnumerable<GetAllProductResult>? getAllProductResults { get; set; }
        public class GetAllProductResult
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public Price ProductPrice { get; set; }

            public Price? PriceMercadoLivre { get; set; }

            public int CategoryId { get; set; }

            public string CategoryName { get; set; }

        }
    }

   
}
