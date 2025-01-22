using Microsoft.EntityFrameworkCore;
using UserService.Domain.Entities;


namespace UserService.Data.Context
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    id = 1,
                    name = "admin",
                    role = "Manager",
                    password = "123"
                }
                );
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserDbContext).Assembly);
        }
    }
}
