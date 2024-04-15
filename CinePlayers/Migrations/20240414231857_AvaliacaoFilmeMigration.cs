using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinePlayers.Migrations
{
    /// <inheritdoc />
    public partial class AvaliacaoFilmeMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FilmesAvaliacoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FilmeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Avaliacao = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmesAvaliacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FilmesAvaliacoes_Filme_FilmeId",
                        column: x => x.FilmeId,
                        principalTable: "Filme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmesAvaliacoes_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilmesAvaliacoes_FilmeId",
                table: "FilmesAvaliacoes",
                column: "FilmeId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmesAvaliacoes_UsuarioId",
                table: "FilmesAvaliacoes",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmesAvaliacoes");
        }
    }
}
