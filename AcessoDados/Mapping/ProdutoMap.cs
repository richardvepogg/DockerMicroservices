using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace AcessoDados.Mapping
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.Property(e => e.idproduto).HasColumnName("idproduto")
                 .IsRequired()
                 .HasPrecision(1,1);

            builder.HasKey(e => e.idproduto);

            builder.Property(e => e.nmproduto).HasColumnName("nmproduto")
                    .IsRequired()
                    .HasMaxLength(200);


            builder.Property(e => e.nuvalor).HasColumnName("nuvalor")
                    .IsRequired()
                    .HasPrecision(16,2);

         
            builder.ToTable("Produtos");
        }
    }
}
