using Microsoft.EntityFrameworkCore;
using Usuarios.Dominio.Entidades;


namespace Usuarios.AcessoDados.Contexto
{
    public class UsuariosDbContext : DbContext
    {
        public UsuariosDbContext(DbContextOptions<UsuariosDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UsuariosDbContext).Assembly);
        }
    }
}
