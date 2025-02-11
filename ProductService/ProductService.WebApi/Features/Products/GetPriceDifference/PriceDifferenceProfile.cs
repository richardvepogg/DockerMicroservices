using AutoMapper;

namespace ProductService.WebApi.Features.Products.GetPriceDifference
{
    public class PriceDifferenceProfile : Profile
    {
        public PriceDifferenceProfile()
        {
            CreateMap<int, ProductService.Application.Products.Queries.PriceDifference.PriceDifferenceQuerie>()
     .ConstructUsing(id => new ProductService.Application.Products.Queries.PriceDifference.PriceDifferenceQuerie(id));
        }
    }
}
