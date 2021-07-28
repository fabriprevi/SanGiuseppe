using Microsoft.EntityFrameworkCore.Migrations;

namespace SanGiuseppe.Migrations
{
    public partial class PrefissoInternazionale : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CellularePrefissoInternazionale",
                table: "Anagrafica",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TelefonoPrefissoInternazionale",
                table: "Anagrafica",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CellularePrefissoInternazionale",
                table: "Anagrafica");

            migrationBuilder.DropColumn(
                name: "TelefonoPrefissoInternazionale",
                table: "Anagrafica");
        }
    }
}
