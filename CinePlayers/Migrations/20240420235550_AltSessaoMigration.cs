using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinePlayers.Migrations
{
    /// <inheritdoc />
    public partial class AltSessaoMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataHora",
                table: "Sessao",
                newName: "DataSaida");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataEntrada",
                table: "Sessao",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataHoraExibicao",
                table: "Sessao",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataEntrada",
                table: "Sessao");

            migrationBuilder.DropColumn(
                name: "DataHoraExibicao",
                table: "Sessao");

            migrationBuilder.RenameColumn(
                name: "DataSaida",
                table: "Sessao",
                newName: "DataHora");
        }
    }
}
