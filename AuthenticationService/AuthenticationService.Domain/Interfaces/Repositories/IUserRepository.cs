using AuthenticationService.Domain.Entities;

namespace AuthenticationService.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User?> FindAsync(User user, CancellationToken cancellationToken = default);
    }
}
