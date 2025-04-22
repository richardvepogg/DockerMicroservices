using AutoMapper;
using ProductService.Application.Products.Queries.PriceDifference;
using ProductService.WebApi.Features.Products.GetPriceDifference;

public class PriceDifferenceProfile : Profile
{
    public PriceDifferenceProfile()
    {
        // Mapeamento para construir a Querie
        CreateMap<PriceDifferenceRequest, PriceDifferenceQuerie>()
            .ConstructUsing(req => new PriceDifferenceQuerie(req.Id));

        // Mapeamento do resultado para a resposta
        CreateMap<PriceDifferenceResult, PriceDifferenceResponse>();
    }
}
