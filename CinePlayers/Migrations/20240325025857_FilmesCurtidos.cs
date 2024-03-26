using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinePlayers.Migrations
{
    /// <inheritdoc />
    public partial class FilmesCurtidos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListaFavoritos");

            migrationBuilder.CreateTable(
                name: "FilmesCurtidos",
                columns: table => new
                {
                    FilmeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmesCurtidos", x => new { x.FilmeId, x.UsuarioId });
                    table.ForeignKey(
                        name: "FK_FilmesCurtidos_FilmeId",
                        column: x => x.FilmeId,
                        principalTable: "Filme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmesCurtidos_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FilmesFavoritos",
                columns: table => new
                {
                    FilmeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmesFavoritos", x => new { x.FilmeId, x.UsuarioId });
                    table.ForeignKey(
                        name: "FK_FilmesFavoritos_FilmeId",
                        column: x => x.FilmeId,
                        principalTable: "Filme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmesFavoritos_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilmesCurtidos_UsuarioId",
                table: "FilmesCurtidos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmesFavoritos_UsuarioId",
                table: "FilmesFavoritos",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmesCurtidos");

            migrationBuilder.DropTable(
                name: "FilmesFavoritos");

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
    }
}
