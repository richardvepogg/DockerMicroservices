﻿// <auto-generated />
using AcessoDados.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AcessoDados.Migrations
{
    [DbContext(typeof(ProdutoDbContext))]
    partial class ProdutoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Dominio.Entidades.Produto", b =>
                {
                    b.Property<int>("idproduto")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(1, 1)
                        .HasColumnType("int")
                        .HasColumnName("idproduto");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idproduto"));

                    b.Property<string>("nmproduto")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("nmproduto");

                    b.Property<decimal>("nuvalor")
                        .HasPrecision(16, 2)
                        .HasColumnType("decimal(16,2)")
                        .HasColumnName("nuvalor");

                    b.HasKey("idproduto");

                    b.ToTable("Produtos", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
