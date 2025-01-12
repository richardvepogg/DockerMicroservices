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


        public UpdateProductHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            Product product = _mapper.Map<Product>(command);

            Product? updateProduct =  await _productRepository.UpdateAsync(product);
            UpdateProductResult? result = _mapper.Map<UpdateProductResult>(updateProduct);
            return result;
        }


    }
}
