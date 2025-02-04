using ProductService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Domain.Events
{
    public class ProductInsertedEvent
    {
        public Product Product { get; }

        public ProductInsertedEvent(Product product)
        {
            Product = product;
        }
    }

}
