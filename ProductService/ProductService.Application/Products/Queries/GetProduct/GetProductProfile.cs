using AutoMapper;
using ProductService.Domain.Entities;


namespace ProductService.Application.Products.Queries.GetProduct
{
    public class GetProductProfile : Profile
    {
        public GetProductProfile()
        {
            CreateMap<Product, GetProductResult>();
        }
    }
}
