using AuthenticationService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthenticationService.Data.Mapping
{
    public class UsersMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(e => e.id).HasColumnName("id")
                 .IsRequired()
                 .HasPrecision(1, 1);

            builder.HasKey(e => e.id);

            builder.Property(e => e.name).HasColumnName("name")
                    .IsRequired()
                    .HasMaxLength(100);


            builder.Property(e => e.password).HasColumnName("password")
                    .IsRequired()
                    .HasMaxLength(20);


            builder.Property(e => e.role).HasColumnName("role")
                    .IsRequired()
                    .HasMaxLength(50);


            builder.ToTable("Users");
        }
    }
}
