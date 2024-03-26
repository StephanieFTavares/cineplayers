using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinePlayers.Migrations
{
    /// <inheritdoc />
    public partial class FilmeUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ListaFavoritos",
                columns: table => new
                {
                    FilmeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListaFavoritos", x => new { x.FilmeId, x.UsuarioId });
                    table.ForeignKey(
                        name: "FK_ListaFavoritos_FilmeId",
                        column: x => x.FilmeId,
                        principalTable: "Filme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListaFavoritos_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ListaFavoritos_UsuarioId",
                table: "ListaFavoritos",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListaFavoritos");
        }
    }
}
