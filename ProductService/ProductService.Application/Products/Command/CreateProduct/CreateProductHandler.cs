using AutoMapper;
using MediatR;
using ProductService.Domain.Entities;
using ProductService.Domain.Interfaces;
using ProductService.Domain.Events; 

namespace ProductService.Application.Products.Command.CreateProduct
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, CreateProductResult>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IEventHandler<ProductInsertedEvent> _productInsertedEventHandler; 

        public CreateProductHandler(IProductRepository productRepository, IMapper mapper, IEventHandler<ProductInsertedEvent> productInsertedEventHandler)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _productInsertedEventHandler = productInsertedEventHandler; 
        }

        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            Product product = _mapper.Map<Product>(command);

            Product? createdProduct = await _productRepository.AddAsync(product);
            CreateProductResult? result = _mapper.Map<CreateProductResult>(createdProduct);

            // Trigger the ProductInsertedEvent
            ProductInsertedEvent productInsertedEvent = new ProductInsertedEvent(product);
            _productInsertedEventHandler.Handle(productInsertedEvent);

            return result;
        }
    }
}
