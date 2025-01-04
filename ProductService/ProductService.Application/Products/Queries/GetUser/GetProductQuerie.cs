using MediatR;


namespace ProductService.Application.Products.Command.GetUser
{
    public record GetProductCommand : IRequest<GetProductResult>
    {
        public int Id { get; }

        public GetProductCommand(int id)
        {
            Id = id;
        }
    }
}
