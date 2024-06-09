using Microsoft.EntityFrameworkCore;
using Usuarios.Dominio.Entidades;


namespace Usuarios.AcessoDados.Contexto
{
    public class UsuarioDbContext : DbContext
    {
        public UsuarioDbContext(DbContextOptions<UsuarioDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    idusuario = 1,
                    nmusuario = "admin",
                    nmcargo = "Manager",
                    senha = "123"
                }
                );
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UsuarioDbContext).Assembly);
        }
    }
}
