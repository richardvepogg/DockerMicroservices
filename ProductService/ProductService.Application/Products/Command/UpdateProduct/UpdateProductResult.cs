using ProductService.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Application.Products.Command.UpdateProduct
{
    public class UpdateProductResult
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public Price? ProductPrice { get; set; }

        public Price? PriceMercadoLivre { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; } = string.Empty;
    }
}
