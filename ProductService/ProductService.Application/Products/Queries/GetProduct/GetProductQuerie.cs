using MediatR;

namespace ProductService.Application.Products.Queries.GetProduct
{
    public record GetProductQuerie : IRequest<GetProductResponse>
    {
        public int Id { get; }

        public GetProductQuerie(int id)
        {
            Id = id;
        }
    }
}
