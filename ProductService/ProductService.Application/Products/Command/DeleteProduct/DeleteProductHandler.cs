using MediatR;
using ProductService.Domain.Interfaces;

namespace ProductService.Application.Products.Command.DeleteProduct
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, DeleteProductResult>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductHandler(
    IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<DeleteProductResult> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var success = await _productRepository.RemoveAsync(request.Id, cancellationToken);
            if (!success)
                throw new KeyNotFoundException($"Product with ID {request.Id} not found");

            return new DeleteProductResult { Success = true };
        }
    }
}
