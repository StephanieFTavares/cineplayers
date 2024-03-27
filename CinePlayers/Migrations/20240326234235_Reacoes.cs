using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinePlayers.Migrations
{
    /// <inheritdoc />
    public partial class Reacoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmesCurtidos");

            migrationBuilder.CreateTable(
                name: "Reacoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Reacoes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reacoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FilmeReacoesFilmes",
                columns: table => new
                {
                    FilmesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuariosQueReagiramId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmeReacoesFilmes", x => new { x.FilmesId, x.UsuariosQueReagiramId });
                    table.ForeignKey(
                        name: "FK_FilmeReacoesFilmes_Filme_FilmesId",
                        column: x => x.FilmesId,
                        principalTable: "Filme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmeReacoesFilmes_Reacoes_UsuariosQueReagiramId",
                        column: x => x.UsuariosQueReagiramId,
                        principalTable: "Reacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReacoesFilmesUsuario",
                columns: table => new
                {
                    FilmesReagidosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuariosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReacoesFilmesUsuario", x => new { x.FilmesReagidosId, x.UsuariosId });
                    table.ForeignKey(
                        name: "FK_ReacoesFilmesUsuario_Reacoes_FilmesReagidosId",
                        column: x => x.FilmesReagidosId,
                        principalTable: "Reacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReacoesFilmesUsuario_Usuario_UsuariosId",
                        column: x => x.UsuariosId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilmeReacoesFilmes_UsuariosQueReagiramId",
                table: "FilmeReacoesFilmes",
                column: "UsuariosQueReagiramId");

            migrationBuilder.CreateIndex(
                name: "IX_ReacoesFilmesUsuario_UsuariosId",
                table: "ReacoesFilmesUsuario",
                column: "UsuariosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmeReacoesFilmes");

            migrationBuilder.DropTable(
                name: "ReacoesFilmesUsuario");

            migrationBuilder.DropTable(
                name: "Reacoes");

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

            migrationBuilder.CreateIndex(
                name: "IX_FilmesCurtidos_UsuarioId",
                table: "FilmesCurtidos",
                column: "UsuarioId");
        }
    }
}
