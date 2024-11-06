using CadastroProduto.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;


namespace CadastroProduto.AcessoDados.Contexto
{
    public class ProdutoDbContext : DbContext
    {

        public ProdutoDbContext(DbContextOptions<ProdutoDbContext> options) : base(options) { }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProdutoDbContext).Assembly);
        }
    }
}
