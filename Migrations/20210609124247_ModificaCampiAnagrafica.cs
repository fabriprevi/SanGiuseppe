using Microsoft.EntityFrameworkCore.Migrations;

namespace SanGiuseppe.Migrations
{
    public partial class ModificaCampiAnagrafica : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Provincia",
                table: "Anagrafica");

            migrationBuilder.DropColumn(
                name: "Telefono1",
                table: "Anagrafica");

            migrationBuilder.RenameColumn(
                name: "Telefono2",
                table: "Anagrafica",
                newName: "Telefono");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Telefono",
                table: "Anagrafica",
                newName: "Telefono2");

            migrationBuilder.AddColumn<string>(
                name: "Provincia",
                table: "Anagrafica",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefono1",
                table: "Anagrafica",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}
