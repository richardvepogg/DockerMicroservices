using Microsoft.EntityFrameworkCore;
using System.Data;
using UserService.Domain.Entities;
using UserService.Domain.Enums;


namespace UserService.Data.Context
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User(1,"admin",new Domain.ValueObjects.ContactInfo("usuario@gmail.com", "(48) 99142-2442"),"123",UserRole.Manager));
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserDbContext).Assembly);
        }
    }
}
