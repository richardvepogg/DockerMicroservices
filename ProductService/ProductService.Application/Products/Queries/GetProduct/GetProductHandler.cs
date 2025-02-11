using AutoMapper;
using MediatR;
using ProductService.Domain.Entities;
using ProductService.Domain.Interfaces;


namespace ProductService.Application.Products.Queries.GetProduct
{
    public class GetProductHandler : IRequestHandler<GetProductQuerie, GetProductResult>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductHandler(
        IProductRepository productRepository,
        IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<GetProductResult> Handle(GetProductQuerie request, CancellationToken cancellationToken)
        {
            Product? product = await _productRepository.FindAsyncById(request.Id, cancellationToken);
            if (product == null)
                throw new KeyNotFoundException($"Product with ID {request.Id} not found");

            return _mapper.Map<GetProductResult>(product);
        }

    }
}
