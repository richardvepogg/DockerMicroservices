﻿using ProductService.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace ProductService.Domain.Entities
{
    
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public Price ProductPrice { get; set; }

        public Price? PriceMercadoLivre { get; set; }

        // Identidade externa com desnormalização
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        // Navegação para a entidade Category
        public Category Category { get; set; }

        // Construtor para inicialização
        public Product(string name, Price productPrice, Category category)
        {
            Name = name;
            ProductPrice = productPrice;
            CategoryId = category.Id;
            CategoryName = category.Name;
            Category = category;
        }
    }

}
