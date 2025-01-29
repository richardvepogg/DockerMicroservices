using AuthenticationService.Data.Context;
using AuthenticationService.Domain.Entities;
using AuthenticationService.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationService.Data.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly UserDbContext _context;

        public UserRepository(UserDbContext context)
        {
            _context = context;
        }


        public async Task<User?> FindAsync(User user, CancellationToken cancellationToken = default)
        {
            return await  _context.Users.FirstOrDefaultAsync(u => u.Name == user.Name && u.Password == user.Password);
        }
    }
}
