using AutoMapper;
using MediatR;
using ProductService.Domain.Entities;
using ProductService.Domain.Interfaces;


namespace ProductService.Application.Products.Queries.GetAllProducts
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuerie, GetAllProductsResult>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetAllProductsHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<GetAllProductsResult> Handle(GetAllProductsQuerie request, CancellationToken cancellationToken)
        {
            IEnumerable<Product> products = await _productRepository.GetAllAsync(cancellationToken);

            if (products == null || !products.Any())
            {
                throw new KeyNotFoundException("No product found.");
            }
  
            return new GetAllProductsResult
            {
                getAllProductResults = _mapper.Map<List<GetAllProductsResult.GetAllProductResult>>(products)
            };
        }
    }

}
