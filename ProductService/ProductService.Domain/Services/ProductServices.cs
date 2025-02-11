using ProductService.Domain.Entities;
using ProductService.Domain.Interfaces;

namespace ProductService.Domain.Services
{
    public class ProductServices : IProductService
    {
        public ProductServices()
        {
        }

        public decimal GetPriceDifference(Product product)
        {
            if (product.ProductPrice == null)
            {
                throw new InvalidOperationException("Product price is not available.");
            }

            if (product.PriceMercadoLivre == null)
            {
                throw new InvalidOperationException("Mercado Livre price is not available.");
            }

            return product.PriceMercadoLivre.Value - product.ProductPrice.Value;
        }


    }

}
