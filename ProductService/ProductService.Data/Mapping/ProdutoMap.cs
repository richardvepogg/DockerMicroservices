using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProductService.Domain.Entities;

namespace ProductService.Data.Mapping
{
    public class ProdutoMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(e => e.Id).HasColumnName("id")
                .IsRequired();

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name).HasColumnName("name")
                .IsRequired()
                .HasMaxLength(200);

            // Mapeamento do Price como um tipo complexo (Value Object)
            builder.OwnsOne(p => p.ProductPrice, price =>
            {
                price.Property(p => p.Value).HasColumnName("price").HasPrecision(16, 2).IsRequired();
                price.Property(p => p.Currency).HasColumnName("currency").IsRequired().HasMaxLength(3);
            });

            // Mapeamento do PriceMercadoLivre como um tipo complexo (Value Object)
            builder.OwnsOne(p => p.PriceMercadoLivre, price =>
            {
                price.Property(p => p.Value).HasColumnName("priceMercadoLivre").HasPrecision(16, 2);
                price.Property(p => p.Currency).HasColumnName("currencyMercadoLivre").HasMaxLength(3);
            });

            builder.Property(e => e.CategoryId).HasColumnName("categoryId")
                .IsRequired();

            builder.Property(e => e.CategoryName).HasColumnName("categoryName")
                .IsRequired()
                .HasMaxLength(100);

            // Definindo relação com a entidade Category
            builder.HasOne(e => e.Category)
                .WithMany()
                .HasForeignKey(e => e.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("Products");
        }
    }

}
