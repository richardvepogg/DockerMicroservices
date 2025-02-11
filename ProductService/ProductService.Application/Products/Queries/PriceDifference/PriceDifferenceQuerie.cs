using MediatR;
using ProductService.Application.Products.Queries.GetProduct;


namespace ProductService.Application.Products.Queries.PriceDifference
{
    public record PriceDifferenceQuerie : IRequest<PriceDifferenceResult>
    {
        public int Id { get; }

        public PriceDifferenceQuerie(int id)
        {
            Id = id;
        }
    }
}
