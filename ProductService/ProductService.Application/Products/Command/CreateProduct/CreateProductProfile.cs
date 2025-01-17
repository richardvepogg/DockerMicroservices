using AutoMapper;
using ProductService.Contracts.Models.Messages;
using ProductService.Domain.Entities;

namespace ProductService.Application.Products.Command.CreateProduct
{
    public class CreateProductProfile : Profile
    {
        public CreateProductProfile()
        {
            CreateMap<CreateProductCommand, Product>();
            CreateMap<Product, CreateProductResult>();
            CreateMap<CreateProductResult, ProductMessage>();
        }
    }
}
