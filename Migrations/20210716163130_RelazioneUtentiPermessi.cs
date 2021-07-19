using Microsoft.EntityFrameworkCore.Migrations;

namespace SanGiuseppe.Migrations
{
    public partial class RelazioneUtentiPermessi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UtentiPermessi_Utenti_UtentiIdutente",
                table: "UtentiPermessi");

            migrationBuilder.DropIndex(
                name: "IX_UtentiPermessi_UtentiIdutente",
                table: "UtentiPermessi");

            migrationBuilder.DropColumn(
                name: "UtentiIdutente",
                table: "UtentiPermessi");

            migrationBuilder.CreateIndex(
                name: "IX_UtentiPermessi_Idutente",
                table: "UtentiPermessi",
                column: "Idutente");

            migrationBuilder.AddForeignKey(
                name: "FK_UtentiPermessi_Utenti_Idutente",
                table: "UtentiPermessi",
                column: "Idutente",
                principalTable: "Utenti",
                principalColumn: "IDUtente",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UtentiPermessi_Utenti_Idutente",
                table: "UtentiPermessi");

            migrationBuilder.DropIndex(
                name: "IX_UtentiPermessi_Idutente",
                table: "UtentiPermessi");

            migrationBuilder.AddColumn<int>(
                name: "UtentiIdutente",
                table: "UtentiPermessi",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UtentiPermessi_UtentiIdutente",
                table: "UtentiPermessi",
                column: "UtentiIdutente");

            migrationBuilder.AddForeignKey(
                name: "FK_UtentiPermessi_Utenti_UtentiIdutente",
                table: "UtentiPermessi",
                column: "UtentiIdutente",
                principalTable: "Utenti",
                principalColumn: "IDUtente",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
