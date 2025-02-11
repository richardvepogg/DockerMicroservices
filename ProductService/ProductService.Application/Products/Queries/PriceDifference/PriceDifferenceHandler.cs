using AutoMapper;
using MediatR;
using ProductService.Domain.Entities;
using ProductService.Domain.Interfaces;

namespace ProductService.Application.Products.Queries.PriceDifference
{
    public class PriceDifferenceHandler : IRequestHandler<PriceDifferenceQuerie, PriceDifferenceResult>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        public PriceDifferenceHandler(
        IProductRepository productRepository,
        IMapper mapper,
        IProductService productService)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _productService = productService;
        }

        public async Task<PriceDifferenceResult> Handle(PriceDifferenceQuerie request, CancellationToken cancellationToken)
        {
            Product? product = await _productRepository.FindAsyncById(request.Id, cancellationToken);
            if (product == null)
                throw new KeyNotFoundException($"Product with ID {request.Id} not found");

            PriceDifferenceResult priceDifference = _mapper.Map<PriceDifferenceResult>(product);

            priceDifference.priceDifference = _productService.GetPriceDifference(product);

            return _mapper.Map<PriceDifferenceResult>(product);
        }
    }
}
