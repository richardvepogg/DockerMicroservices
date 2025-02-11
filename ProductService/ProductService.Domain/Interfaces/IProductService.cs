using ProductService.Domain.Entities;

namespace ProductService.Domain.Interfaces
{
    public interface IProductService
    {
        decimal GetPriceDifference(Product product);
    }


}
