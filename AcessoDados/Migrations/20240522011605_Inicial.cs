using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcessoDados.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    idproduto = table.Column<int>(type: "int", precision: 1, scale: 1, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nmproduto = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    nuvalor = table.Column<decimal>(type: "decimal(16,2)", precision: 16, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.idproduto);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produtos");
        }
    }
}
