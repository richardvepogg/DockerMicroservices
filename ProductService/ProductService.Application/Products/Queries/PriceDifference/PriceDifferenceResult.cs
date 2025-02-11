using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Application.Products.Queries.PriceDifference
{
    public class PriceDifferenceResult
    {

        public decimal? priceDifference { get; set; }

        public decimal price { get; set; }

        public decimal priceMercadoLivre { get; set; }
    }
}
