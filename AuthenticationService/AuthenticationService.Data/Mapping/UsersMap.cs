﻿using AuthenticationService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthenticationService.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(e => e.Id).HasColumnName("id")
                .IsRequired()
                .HasPrecision(1, 1);

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name).HasColumnName("name")
                .IsRequired()
                .HasMaxLength(100);

            builder.OwnsOne(e => e.Contact, contact =>
            {
                contact.Property(c => c.Email)
                       .HasColumnName("email")
                       .IsRequired()
                       .HasMaxLength(100);

                contact.Property(c => c.Phone)
                       .HasColumnName("phone")
                       .IsRequired()
                       .HasMaxLength(15);
            });


            builder.Property(e => e.Password).HasColumnName("password")
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(e => e.Role)
                .HasColumnName("role")
                .IsRequired()
                .HasConversion<int>();


            builder.ToTable("Users");
        }
    }
}
