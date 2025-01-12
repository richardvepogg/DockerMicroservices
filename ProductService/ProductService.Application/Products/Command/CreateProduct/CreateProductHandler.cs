using AutoMapper;
using MediatR;
using ProductService.Domain.Entities;
using ProductService.Domain.Interfaces;

namespace ProductService.Application.Products.Command.CreateProduct
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, CreateProductResult>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;


        public CreateProductHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            Product product = _mapper.Map<Product>(command);

            Product? createdProduct = await _productRepository.AddAsync(product);
            CreateProductResult? result = _mapper.Map<CreateProductResult>(createdProduct);
            return result;
        }


    }
}
