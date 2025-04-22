using AutoMapper;
using ProductService.Application.Products.Queries.GetAllProducts;
using ProductService.WebApi.Features.Products.GetAllProducts;

public class GetAllProductsProfileWeb : Profile
{
    public GetAllProductsProfileWeb()
    {
        CreateMap<GetAllProductsResult.GetAllProductResult, GetAllProductsResponse.GetAllProductResponse>();

        CreateMap<GetAllProductsResult, GetAllProductsResponse>()
            .ForMember(dest => dest.getAllProductResponse,
                       opt => opt.MapFrom(src => src.getAllProductResults));
    }
}
