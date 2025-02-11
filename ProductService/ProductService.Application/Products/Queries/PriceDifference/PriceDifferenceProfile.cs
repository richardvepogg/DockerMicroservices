using AutoMapper;
using ProductService.Domain.Entities;

namespace ProductService.Application.Products.Queries.PriceDifference
{
    public class PriceDifferenceProfile : Profile
    {
        public PriceDifferenceProfile()
        {
            CreateMap<Product, PriceDifferenceResult>();
        }
    }
}
