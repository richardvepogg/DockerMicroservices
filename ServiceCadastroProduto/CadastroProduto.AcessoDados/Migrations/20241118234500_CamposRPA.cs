using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroProduto.AcessoDados.Migrations
{
    /// <inheritdoc />
    public partial class CamposRPA : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "nmprodutoAmazon",
                table: "Produtos",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "nmprodutoMercadoLivre",
                table: "Produtos",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "nuvalorAmazon",
                table: "Produtos",
                type: "decimal(16,2)",
                precision: 16,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "nuvalorMercadoLivre",
                table: "Produtos",
                type: "decimal(16,2)",
                precision: 16,
                scale: 2,
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "nmprodutoAmazon",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "nmprodutoMercadoLivre",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "nuvalorAmazon",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "nuvalorMercadoLivre",
                table: "Produtos");
        }
    }
}
