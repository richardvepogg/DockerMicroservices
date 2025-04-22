using AutoMapper;
using ProductService.Application.Products.Queries.GetProduct;

namespace ProductService.WebApi.Features.Products.GetProduct
{
    public class GetProductProfile : Profile
    {
        public GetProductProfile()
        {
            CreateMap<int, ProductService.Application.Products.Queries.GetProduct.GetProductQuerie>()
     .ConstructUsing(id => new ProductService.Application.Products.Queries.GetProduct.GetProductQuerie(id));

            CreateMap<GetProductResult, GetProductResponse>();
        }
    }
}
