using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Application.Products.Command.UpdateProduct
{
    public class UpdateProductResult
    {
        public string name { get; set; }

        public decimal price { get; set; }

        public decimal? priceMercadoLivre { get; set; }
    }
}
