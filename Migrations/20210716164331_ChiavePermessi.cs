using Microsoft.EntityFrameworkCore.Migrations;

namespace SanGiuseppe.Migrations
{
    public partial class ChiavePermessi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TabellaPermessi",
                columns: table => new
                {
                    Permesso = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabellaPermessi", x => x.Permesso);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TabellaPermessi");
        }
    }
}
