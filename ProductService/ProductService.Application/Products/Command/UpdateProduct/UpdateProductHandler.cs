using AutoMapper;
using MediatR;
using ProductService.Application.Products.Command.CreateProduct;
using ProductService.Domain.Entities;
using ProductService.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Application.Products.Command.UpdateProduct
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, UpdateProductResult>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;


        public UpdateProductHandler(IProductRepository productRepository, IMapper mapper, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            Category category = await _categoryRepository.FindAsyncById(command.CategoryId, cancellationToken);

            if (category == null)
                throw new KeyNotFoundException($"Category with ID {command.CategoryId} not found");

            Product product = _mapper.Map<Product>(command);
            product.CategoryName = category.Name;
            product.Category = category;


            Product? updateProduct =  await _productRepository.UpdateAsync(product);
            UpdateProductResult? result = _mapper.Map<UpdateProductResult>(updateProduct);
            return result;
        }


    }
}
