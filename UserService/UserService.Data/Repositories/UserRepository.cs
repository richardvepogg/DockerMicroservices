using Microsoft.EntityFrameworkCore;
using UserService.Data.Context;
using UserService.Domain.Entities;
using UserService.Domain.Interfaces;

namespace UserService.Data.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly UserDbContext _contexto;


        public UserRepository(UserDbContext ctx)
        {
            _contexto = ctx;
        }

        public async Task<User> AddAsync(User user, CancellationToken cancellationToken = default)
        {
            await _contexto.Users.AddAsync(user, cancellationToken);
            await _contexto.SaveChangesAsync(cancellationToken);

            return user;
        }

        public async Task<User?> FindAsyncById(long id, CancellationToken cancellationToken = default)
        {
            return await _contexto.Users.FirstOrDefaultAsync(u => u.id == id, cancellationToken);
        }

        public async Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _contexto.Users.ToListAsync(cancellationToken);
        }

        public async Task<bool> RemoveAsync(long id, CancellationToken cancellationToken = default)
        {
            User  ? user = await FindAsyncById(id, cancellationToken);
            if (user == null)
                return false;

            _contexto.Users.Remove(user);
            await _contexto.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<User> UpdateAsync(User user, CancellationToken cancellationToken = default)
        {
            _contexto.Update(user);
            await _contexto.SaveChangesAsync(cancellationToken);

            return user;
        }

    }
}
