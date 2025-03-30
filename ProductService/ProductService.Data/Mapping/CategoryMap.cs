using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProductService.Domain.Entities;


namespace ProductService.Data.Mapping
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(e => e.Id).HasColumnName("id")
                .IsRequired();

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name).HasColumnName("name")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Name).HasColumnName("description")
            .HasMaxLength(200);

            builder.HasData(new Category(1,"cellphone", "A portable communication device for calls, texts, and internet. Modern smartphones offer advanced features."));
        }
    }
}
