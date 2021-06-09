using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SanGiuseppe.Migrations
{
    public partial class AggiuntoUID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UID",
                table: "FondoComuneStorico",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "(NewID())");

            migrationBuilder.AddColumn<Guid>(
                name: "UID",
                table: "FondoComuneSospesi",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "(NewID())");

            migrationBuilder.AddColumn<Guid>(
                name: "UID",
                table: "FondoComune",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "(NewID())");

            migrationBuilder.AddColumn<Guid>(
                name: "UID",
                table: "AnagraficaStorico",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "(NewID())");

            migrationBuilder.AddColumn<Guid>(
                name: "UID",
                table: "AnagraficaSospesi",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "(NewID())");

            migrationBuilder.AddColumn<Guid>(
                name: "UID",
                table: "Anagrafica",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "(NewID())");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UID",
                table: "FondoComuneStorico");

            migrationBuilder.DropColumn(
                name: "UID",
                table: "FondoComuneSospesi");

            migrationBuilder.DropColumn(
                name: "UID",
                table: "FondoComune");

            migrationBuilder.DropColumn(
                name: "UID",
                table: "AnagraficaStorico");

            migrationBuilder.DropColumn(
                name: "UID",
                table: "AnagraficaSospesi");

            migrationBuilder.DropColumn(
                name: "UID",
                table: "Anagrafica");
        }
    }
}
