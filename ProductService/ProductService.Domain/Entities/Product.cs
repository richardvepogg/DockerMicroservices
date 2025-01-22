﻿using System.ComponentModel.DataAnnotations;

namespace ProductService.Domain.Entities
{
    public class Product
    {
        [Key]
        public int id { get; set; }

        public string name { get; set; }

        public decimal price { get; set; }

        public decimal? priceMercadoLivre { get; set; }

        public decimal? priceValorAmazon { get; set; }
    }
}