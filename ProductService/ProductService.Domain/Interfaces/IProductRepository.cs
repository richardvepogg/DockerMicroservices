
using ProductService.Domain.Entities;

namespace ProductService.Domain.Interfaces
{
    public interface IProductRepository

    {
        Task<Product> AddAsync(Product product, CancellationToken cancellationToken = default);
        Task <IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Product?> FindAsyncById(long id, CancellationToken cancellationToken = default);
        Task<bool> RemoveAsync(long id, CancellationToken cancellationToken = default);
        Task<Product> UpdateAsync(Product product, CancellationToken cancellationToken = default);

    }
}
