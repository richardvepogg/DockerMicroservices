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
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly IEventHandler<ProductInsertedEvent> _productInsertedEventHandler; 

        public CreateProductHandler(IProductRepository productRepository,ICategoryRepository categoryRepository ,IMapper mapper, IEventHandler<ProductInsertedEvent> productInsertedEventHandler)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _productInsertedEventHandler = productInsertedEventHandler; 
            _categoryRepository = categoryRepository;
        }

        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            Category category  = await _categoryRepository.FindAsyncById(command.IdCategory, cancellationToken);

            if (category == null)
                throw new KeyNotFoundException($"Category with ID {command.IdCategory} not found");

            Product product = _mapper.Map<Product>(command);

            product.CategoryName = category.Name;
            product.Category = category;

            Product? createdProduct = await _productRepository.AddAsync(product);

            CreateProductResult? result = _mapper.Map<CreateProductResult>(createdProduct);

            ProductInsertedEvent productInsertedEvent = new ProductInsertedEvent(product);
            _productInsertedEventHandler.Handle(productInsertedEvent);

            return result;
        }
    }
}
