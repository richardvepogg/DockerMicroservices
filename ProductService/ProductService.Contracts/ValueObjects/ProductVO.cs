using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Contracts.ValueObjects
{
    public class ProductVO
    {
        public int id { get; set; }

        public string name { get; set; }

        public decimal price { get; set; }

        public decimal? priceValorMercadoLivre { get; set; }

        public decimal? priceValorAmazon { get; set; }
    }
}
