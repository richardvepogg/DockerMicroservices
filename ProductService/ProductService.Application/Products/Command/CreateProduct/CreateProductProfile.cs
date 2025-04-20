using AutoMapper;
using ProductService.Contracts.Models.Messages;
using ProductService.Domain.Entities;
using ProductService.Domain.ValueObjects;

namespace ProductService.Application.Products.Command.CreateProduct
{
    public class CreateProductProfile : Profile
    {
        public CreateProductProfile()
        {
            CreateMap<CreateProductCommand, Product>()
           .ForMember(dest => dest.ProductPrice, opt => opt.MapFrom(src => new Price(src.price, src.Currency)))
           .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.IdCategory));

            CreateMap<Product, CreateProductResult>();
            CreateMap<Product, ProductMessage>();
            CreateMap<Product, CreateProductResult>();
        }
    }
}
