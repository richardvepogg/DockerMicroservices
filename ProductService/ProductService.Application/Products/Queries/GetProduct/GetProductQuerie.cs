﻿using MediatR;

namespace ProductService.Application.Products.Queries.GetProduct
{
    public record GetProductQuerie : IRequest<GetProductResult>
    {
        public int Id { get; }

        public GetProductQuerie(int id)
        {
            Id = id;
        }
    }
}
