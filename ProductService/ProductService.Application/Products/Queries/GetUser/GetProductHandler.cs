using AutoMapper;
using MediatR;
using ProductService.Domain.Entities;
using ProductService.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Application.Products.Queries.GetUser
{
    public class GetProductHandler : IRequestHandler<GetProductQuerie, GetProductResponse>
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

        public async Task<GetProductResponse> Handle(GetProductQuerie request, CancellationToken cancellationToken)
        {
            Product? product = await _productRepository.FindAsyncById(request.Id, cancellationToken);
            if (product == null)
                throw new KeyNotFoundException($"Product with ID {request.Id} not found");

            return _mapper.Map<GetProductResponse>(product);
        }

    }
}
