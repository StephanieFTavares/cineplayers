using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinePlayers.Migrations
{
    /// <inheritdoc />
    public partial class Reacoes2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmeReacoesFilmes");

            migrationBuilder.DropTable(
                name: "ReacoesFilmesUsuario");

            migrationBuilder.AddColumn<Guid>(
                name: "FilmeId",
                table: "Reacoes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioId",
                table: "Reacoes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Reacoes_FilmeId",
                table: "Reacoes",
                column: "FilmeId");

            migrationBuilder.CreateIndex(
                name: "IX_Reacoes_UsuarioId",
                table: "Reacoes",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reacoes_Filme_FilmeId",
                table: "Reacoes",
                column: "FilmeId",
                principalTable: "Filme",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reacoes_Usuario_UsuarioId",
                table: "Reacoes",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reacoes_Filme_FilmeId",
                table: "Reacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Reacoes_Usuario_UsuarioId",
                table: "Reacoes");

            migrationBuilder.DropIndex(
                name: "IX_Reacoes_FilmeId",
                table: "Reacoes");

            migrationBuilder.DropIndex(
                name: "IX_Reacoes_UsuarioId",
                table: "Reacoes");

            migrationBuilder.DropColumn(
                name: "FilmeId",
                table: "Reacoes");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Reacoes");

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
    }
}
