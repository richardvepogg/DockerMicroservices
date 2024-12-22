
using ProductService.Domain.Entities;

namespace ProductService.Domain.Interfaces
{
    public interface IProductRepository

    {
        int Add(Product product);
        IEnumerable<Product> GetAll();
        Product Find(long id);
        void Remove(long id);
        void Update(Product product);

    }
}
