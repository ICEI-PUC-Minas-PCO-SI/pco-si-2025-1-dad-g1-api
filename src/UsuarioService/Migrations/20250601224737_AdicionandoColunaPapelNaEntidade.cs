using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UsuarioService.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoColunaPapelNaEntidade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Papel",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Papel",
                table: "Usuarios");
        }
    }
}
