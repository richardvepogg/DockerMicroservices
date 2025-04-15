using AutoMapper;
using ProductService.Domain.Entities;

namespace ProductService.Application.Products.Queries.GetAllProducts
{
    public class GetAllProductsProfile : Profile
    {
        public GetAllProductsProfile()
        {
            CreateMap<Product, GetAllProducts.GetAllProductsResult>();
        }
    }
}
