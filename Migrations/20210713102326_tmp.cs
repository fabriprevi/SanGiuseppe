using Microsoft.EntityFrameworkCore.Migrations;

namespace SanGiuseppe.Migrations
{
    public partial class tmp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AvvisiPermessiUtentiPermessi");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AvvisiPermessiUtentiPermessi",
                columns: table => new
                {
                    AvvisiPermessiIdAvvisPermesso = table.Column<int>(type: "int", nullable: false),
                    UtentiPermessiIdUtentePermesso = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvvisiPermessiUtentiPermessi", x => new { x.AvvisiPermessiIdAvvisPermesso, x.UtentiPermessiIdUtentePermesso });
                    table.ForeignKey(
                        name: "FK_AvvisiPermessiUtentiPermessi_AvvisiPermessi_AvvisiPermessiIdAvvisPermesso",
                        column: x => x.AvvisiPermessiIdAvvisPermesso,
                        principalTable: "AvvisiPermessi",
                        principalColumn: "IdAvvisPermesso",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AvvisiPermessiUtentiPermessi_UtentiPermessi_UtentiPermessiIdUtentePermesso",
                        column: x => x.UtentiPermessiIdUtentePermesso,
                        principalTable: "UtentiPermessi",
                        principalColumn: "IdUtentePermesso",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AvvisiPermessiUtentiPermessi_UtentiPermessiIdUtentePermesso",
                table: "AvvisiPermessiUtentiPermessi",
                column: "UtentiPermessiIdUtentePermesso");
        }
    }
}
