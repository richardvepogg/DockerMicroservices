using AutoMapper;
using ProductService.Application.Products.Queries.GetAllProducts;


namespace ProductService.WebApi.Features.Products.GetAllProducts
{
    public class GetAllProductsProfile : Profile
    {
        public GetAllProductsProfile()
        {
            CreateMap<GetAllProductsResult.GetAllProductResult, GetAllProductsResponse.GetAllProductResponse>()
             .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.name));

        }
    }
}
