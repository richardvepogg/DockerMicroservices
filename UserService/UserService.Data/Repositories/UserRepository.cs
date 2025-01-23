using Microsoft.EntityFrameworkCore;
using UserService.Data.Context;
using UserService.Domain.Entities;
using UserService.Domain.Interfaces;

namespace UserService.Data.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly UserDbContext _context;


        public UserRepository(UserDbContext ctx)
        {
            _context = ctx;
        }

        public async Task<User> AddAsync(User user, CancellationToken cancellationToken = default)
        {
            await _context.Users.AddAsync(user, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return user;
        }

        public async Task<User?> FindAsyncById(long id, CancellationToken cancellationToken = default)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.id == id, cancellationToken);
        }

        public async Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Users.ToListAsync(cancellationToken);
        }

        public async Task<bool> RemoveAsync(long id, CancellationToken cancellationToken = default)
        {
            User  ? user = await FindAsyncById(id, cancellationToken);
            if (user == null)
                return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<User> UpdateAsync(User user, CancellationToken cancellationToken = default)
        {
            _context.Update(user);
            await _context.SaveChangesAsync(cancellationToken);

            return user;
        }

    }
}
