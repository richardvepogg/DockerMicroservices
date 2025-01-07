using AutoMapper;
using ProductService.Application.Products.Command.CreateProduct;
using ProductService.Application.Products.Command.UpdateProduct;
using ProductService.WebApi.Features.Products.CreateProduct;

namespace ProductService.WebApi.Features.Products.UpdateProduct
{
    public class UpdateProductProfile : Profile
    {
        public UpdateProductProfile()
        {
            CreateMap<UpdateProductRequest, UpdateProductCommand>();
            CreateMap<UpdateProductResult, UpdateProductResponse>();
        }
    }
}
