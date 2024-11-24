using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroProduto.AcessoDados.Migrations
{
    /// <inheritdoc />
    public partial class RemoverCamposDesnecessarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "nmprodutoAmazon",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "nmprodutoMercadoLivre",
                table: "Produtos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "nmprodutoAmazon",
                table: "Produtos",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "nmprodutoMercadoLivre",
                table: "Produtos",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);
        }
    }
}
