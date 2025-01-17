using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Application.Products.Command.CreateProduct
{
    public class CreateProductResult
    {
        public int id { get; set; }

        public string name { get; set; }

        public decimal price { get; set; }

        public decimal? priceMercadoLivre { get; set; }

        public decimal? priceValorAmazon { get; set; }
    }
}
