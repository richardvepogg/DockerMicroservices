using AutoMapper;
using ProductService.Application.Products.Queries.GetAllProducts;


namespace ProductService.WebApi.Features.Products.GetAllProducts
{
    public class GetAllProductsProfile : Profile
    {
        public GetAllProductsProfile()
        {
            CreateMap<GetAllProductsResult, GetAllProductsResponse>();

        }
    }
}
