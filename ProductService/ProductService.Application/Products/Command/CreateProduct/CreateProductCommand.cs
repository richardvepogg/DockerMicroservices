﻿using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Application.Products.Command.CreateProduct
{
    public class CreateProductCommand : IRequest<CreateProductResult>
    {
        public string name { get; set; } = string.Empty;

        public decimal price { get; set; } 

        public decimal? priceMercadoLivre { get; set; }

        public decimal? priceValorAmazon { get; set; }
    }
}
