using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Usuarios.AcessoDados.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    idusuario = table.Column<int>(type: "int", precision: 1, scale: 1, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nmusuario = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    senha = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    cargo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.idusuario);
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "idusuario", "cargo", "nmusuario", "senha" },
                values: new object[] { 1, "Manager", "admin", "123" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
