using AutoMapper;
using ProductService.Application.Products.Command.UpdateProduct;
using ProductService.Contracts.Models.Messages;
using ProductService.Domain.Entities;
using ProductService.Domain.Enums;
using ProductService.Domain.ValueObjects;
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
            CreateMap<ProductMessageUpdate, UpdateProductMessagePriceCommand>()
             .ForMember(dest => dest.Price, opt => opt.MapFrom(src => new Price(src.value ?? 0, Currency.BRL)))
             .ForMember(dest => dest.RPAMarketPlace, opt => opt.MapFrom(src => src.RPAPlataform));

        }
    }
}
