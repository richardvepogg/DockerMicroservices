using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductService.Data.Migrations
{
    /// <inheritdoc />
    public partial class ProductInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    price = table.Column<decimal>(type: "decimal(16,2)", precision: 16, scale: 2, nullable: false),
                    currency = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    priceMercadoLivre = table.Column<decimal>(type: "decimal(16,2)", precision: 16, scale: 2, nullable: true),
                    currencyMercadoLivre = table.Column<int>(type: "int", maxLength: 3, nullable: true),
                    categoryId = table.Column<int>(type: "int", nullable: false),
                    categoryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_categoryId",
                        column: x => x.categoryId,
                        principalTable: "Categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "id", "description", "name" },
                values: new object[] { 1, "A portable communication device for calls, texts, and internet. Modern smartphones offer advanced features.", "cellphone" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_categoryId",
                table: "Products",
                column: "categoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
