using MediatR;
using ProductService.Domain.ValueObjects;

namespace ProductService.Application.Products.Command.UpdateProduct
{
    public class UpdateProductCommand : IRequest<UpdateProductResult>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Price ProductPrice { get; set; }

        public Price? PriceMercadoLivre { get; set; }

        public int CategoryId { get; set; }
    }
}
