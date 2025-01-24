using MediatR;


namespace ProductService.Application.Products.Command.CreateProduct
{
    public class CreateProductCommand : IRequest<CreateProductResult>
    {
        public string name { get; set; } = string.Empty;

        public decimal price { get; set; } 

        public decimal? priceMercadoLivre { get; set; }
    }
}
