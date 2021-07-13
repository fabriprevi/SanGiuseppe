using Microsoft.EntityFrameworkCore.Migrations;

namespace SanGiuseppe.Migrations
{
    public partial class tmp2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AvvisiPermessi_Avvisi_AvvisiIdavviso",
                table: "AvvisiPermessi");

            migrationBuilder.DropIndex(
                name: "IX_AvvisiPermessi_AvvisiIdavviso",
                table: "AvvisiPermessi");

            migrationBuilder.DropColumn(
                name: "AvvisiIdavviso",
                table: "AvvisiPermessi");

            migrationBuilder.CreateIndex(
                name: "IX_AvvisiPermessi_Idavviso",
                table: "AvvisiPermessi",
                column: "Idavviso");

            migrationBuilder.AddForeignKey(
                name: "FK_AvvisiPermessi_Avvisi_Idavviso",
                table: "AvvisiPermessi",
                column: "Idavviso",
                principalTable: "Avvisi",
                principalColumn: "IDAvviso",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AvvisiPermessi_Avvisi_Idavviso",
                table: "AvvisiPermessi");

            migrationBuilder.DropIndex(
                name: "IX_AvvisiPermessi_Idavviso",
                table: "AvvisiPermessi");

            migrationBuilder.AddColumn<int>(
                name: "AvvisiIdavviso",
                table: "AvvisiPermessi",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AvvisiPermessi_AvvisiIdavviso",
                table: "AvvisiPermessi",
                column: "AvvisiIdavviso");

            migrationBuilder.AddForeignKey(
                name: "FK_AvvisiPermessi_Avvisi_AvvisiIdavviso",
                table: "AvvisiPermessi",
                column: "AvvisiIdavviso",
                principalTable: "Avvisi",
                principalColumn: "IDAvviso",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
