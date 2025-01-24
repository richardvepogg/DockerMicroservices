using MediatR;

namespace ProductService.Application.Products.Command.UpdateProduct
{
    public class UpdateProductCommand : IRequest<UpdateProductResult>
    {
        public int id { get; set; }

        public string name { get; set; }

        public decimal price { get; set; }

        public decimal? priceMercadoLivre { get; set; }
    }
}
