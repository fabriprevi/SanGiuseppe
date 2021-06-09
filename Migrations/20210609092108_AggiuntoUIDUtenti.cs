using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SanGiuseppe.Migrations
{
    public partial class AggiuntoUIDUtenti : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UID",
                table: "Utenti",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "(NewID())");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UID",
                table: "Utenti");
        }
    }
}
