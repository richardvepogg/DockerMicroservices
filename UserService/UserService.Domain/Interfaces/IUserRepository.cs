using UserService.Domain.Entities;


namespace UserService.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> AddAsync(User user, CancellationToken cancellationToken = default);
        Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<User?> FindAsyncById(long id, CancellationToken cancellationToken = default);
        Task<bool> RemoveAsync(long id, CancellationToken cancellationToken = default);
        Task<User> UpdateAsync(User user, CancellationToken cancellationToken = default);

    }
}
