using MediatR;
using ProductService.Domain.Enums;


namespace ProductService.Application.Products.Command.CreateProduct
{
    public class CreateProductCommand : IRequest<CreateProductResult>
    {
        public string name { get; set; } = string.Empty;

        public decimal price { get; set; }

        public Currency Currency { get; set; }

        public int IdCategory { get; set; }
    }
}
