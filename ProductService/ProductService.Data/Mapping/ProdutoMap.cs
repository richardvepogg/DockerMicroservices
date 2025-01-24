using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProductService.Domain.Entities;

namespace ProductService.Data.Mapping
{
    public class ProdutoMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(e => e.id).HasColumnName("id")
                 .IsRequired()
                 .HasPrecision(1, 1);

            builder.HasKey(e => e.id);

            builder.Property(e => e.name).HasColumnName("name")
                    .IsRequired()
                    .HasMaxLength(200);


            builder.Property(e => e.price).HasColumnName("price")
                    .IsRequired()
                    .HasPrecision(16, 2);


            builder.Property(e => e.priceMercadoLivre).HasColumnName("priceMercadoLivre")
                    .HasPrecision(16, 2);


            builder.ToTable("Products");
        }
    }
}
