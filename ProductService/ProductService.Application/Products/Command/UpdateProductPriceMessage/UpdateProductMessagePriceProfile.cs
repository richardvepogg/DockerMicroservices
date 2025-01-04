using AutoMapper;
using ProductService.Application.Products.Command.UpdateProduct;
using ProductService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Application.Products.Command.UpdateProductPriceMessage
{
    public class UpdateProductMessagePriceProfile : Profile
    {
            public UpdateProductMessagePriceProfile()
            {
                CreateMap<UpdateProductMessagePriceCommand, Product>();
            }
    }
}
