using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Application.Products.Queries.GetAllUsers
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
