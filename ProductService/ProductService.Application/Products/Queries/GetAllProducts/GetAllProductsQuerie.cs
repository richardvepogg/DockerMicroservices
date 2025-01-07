using MediatR;

namespace ProductService.Application.Products.Queries.GetAllProducts
{
    public record GetAllProductsQuerie : IRequest<GetAllProductsResult>
    {
    }

}
