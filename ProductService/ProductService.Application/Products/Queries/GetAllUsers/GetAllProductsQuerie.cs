using MediatR;
using ProductService.Application.Products.Queries.GetUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Application.Products.Queries.GetAllUsers
{
    public record GetAllProductsQuerie : IRequest<GetAllProductsResponse>
    {
    }

}
