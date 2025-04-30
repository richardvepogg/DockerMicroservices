using ProductService.Domain.Entities;
using ProductService.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Application.Products.Command.CreateProduct
{
    public class CreateProductResult
    {
        public int Id { get; set; }

        public string Name { get; set; }  = string.Empty;

        public Price? ProductPrice { get; set; }

        public int CategoryId { get; set; } 

        public string CategoryName { get; set; } = string.Empty;

        public Category? Category { get; set; }
    }
}
