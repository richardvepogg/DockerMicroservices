using AutoMapper;
using ProductService.Application.Products.Queries.GetAllProducts;


namespace ProductService.WebApi.Features.Products.GetAllProducts
{
    public class GetAllProductsProfileWeb : Profile
    {
        public GetAllProductsProfileWeb()
        {
            CreateMap<GetAllProductsResult.GetAllProductResult, GetAllProductsResponse.GetAllProductResponse>();
        }
    }
}
