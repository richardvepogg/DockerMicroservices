using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Application.Products.Command.DeleteUser
{
    public record DeleteProductCommand : IRequest<DeleteProductResponse>
    {

        public long Id { get; }


        public DeleteProductCommand(long id)
        {
            Id = id;
        }
    }
}
