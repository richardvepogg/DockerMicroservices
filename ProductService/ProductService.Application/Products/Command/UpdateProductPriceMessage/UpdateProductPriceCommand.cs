using MediatR;
using ProductService.Application.Products.Command.UpdateProduct;
using ProductService.Contracts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Application.Products.Command.UpdateProductPriceMessage
{
    public class UpdateProductMessagePriceCommand : IRequest<UpdateProductMessagePriceResult>
    {
            public int Id { get; set; }
            public decimal Price { get; set; }
            public ERPAMarketPlace RPAMarketPlace { get; set; }
    }
}
