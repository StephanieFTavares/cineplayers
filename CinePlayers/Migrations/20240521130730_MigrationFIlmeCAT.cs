using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinePlayers.Migrations
{
    /// <inheritdoc />
    public partial class MigrationFIlmeCAT : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Categoria",
                table: "Filme",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Imagem",
                table: "Filme",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "Filme");

            migrationBuilder.DropColumn(
                name: "Imagem",
                table: "Filme");
        }
    }
}
