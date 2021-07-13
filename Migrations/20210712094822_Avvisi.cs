using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SanGiuseppe.Migrations
{
    public partial class Avvisi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AvvisiPermessi_Avvisi_AvvisiIdavviso",
                table: "AvvisiPermessi");

            migrationBuilder.DropForeignKey(
                name: "FK_UtentiPermessi_Utenti_UtentiIdutente",
                table: "UtentiPermessi");

            migrationBuilder.AlterColumn<Guid>(
                name: "UID",
                table: "Avvisi",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "(NewID())",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

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

            migrationBuilder.AddForeignKey(
                name: "FK_AvvisiPermessi_Avvisi_AvvisiIdavviso",
                table: "AvvisiPermessi",
                column: "AvvisiIdavviso",
                principalTable: "Avvisi",
                principalColumn: "IDAvviso",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UtentiPermessi_Utenti_UtentiIdutente",
                table: "UtentiPermessi",
                column: "UtentiIdutente",
                principalTable: "Utenti",
                principalColumn: "IDUtente",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AvvisiPermessi_Avvisi_AvvisiIdavviso",
                table: "AvvisiPermessi");

            migrationBuilder.DropForeignKey(
                name: "FK_UtentiPermessi_Utenti_UtentiIdutente",
                table: "UtentiPermessi");

            migrationBuilder.DropTable(
                name: "AvvisiPermessiUtentiPermessi");

            migrationBuilder.AlterColumn<Guid>(
                name: "UID",
                table: "Avvisi",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "(NewID())");

            migrationBuilder.AddForeignKey(
                name: "FK_AvvisiPermessi_Avvisi_AvvisiIdavviso",
                table: "AvvisiPermessi",
                column: "AvvisiIdavviso",
                principalTable: "Avvisi",
                principalColumn: "IDAvviso",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UtentiPermessi_Utenti_UtentiIdutente",
                table: "UtentiPermessi",
                column: "UtentiIdutente",
                principalTable: "Utenti",
                principalColumn: "IDUtente",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
