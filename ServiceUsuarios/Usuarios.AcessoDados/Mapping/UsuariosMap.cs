using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usuarios.Dominio.Entidades;

namespace Usuarios.AcessoDados.Mapping
{
    public class UsuariosMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.Property(e => e.idusuario).HasColumnName("idusuario")
                 .IsRequired()
                 .HasPrecision(1, 1);

            builder.HasKey(e => e.idusuario);

            builder.Property(e => e.nmusuario).HasColumnName("nmusuario")
                    .IsRequired()
                    .HasMaxLength(100);


            builder.Property(e => e.senha).HasColumnName("senha")
                    .IsRequired()
                    .HasMaxLength(20);


            builder.Property(e => e.nmcargo).HasColumnName("cargo")
                    .IsRequired()
                    .HasMaxLength(50);


            builder.ToTable("Usuarios");
        }
    }
}
