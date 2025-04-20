using ProductService.Domain.Entities;


namespace ProductService.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category?> FindAsyncById(long id, CancellationToken cancellationToken = default);
    }
}
