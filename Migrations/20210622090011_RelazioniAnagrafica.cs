using Microsoft.EntityFrameworkCore.Migrations;

namespace SanGiuseppe.Migrations
{
    public partial class RelazioniAnagrafica : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CapiGruppetto_Anagrafica",
                table: "CapiGruppetto");

            migrationBuilder.DropForeignKey(
                name: "FK_FondoComune_FondoComune",
                table: "FondoComune");

            migrationBuilder.AddForeignKey(
                name: "FK_CapiGruppetto_Anagrafica",
                table: "CapiGruppetto",
                column: "IDAnagrafica",
                principalTable: "Anagrafica",
                principalColumn: "IDAnagrafica",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FondoComune_FondoComune",
                table: "FondoComune",
                column: "IDAnagrafica",
                principalTable: "Anagrafica",
                principalColumn: "IDAnagrafica",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CapiGruppetto_Anagrafica",
                table: "CapiGruppetto");

            migrationBuilder.DropForeignKey(
                name: "FK_FondoComune_FondoComune",
                table: "FondoComune");

            migrationBuilder.AddForeignKey(
                name: "FK_CapiGruppetto_Anagrafica",
                table: "CapiGruppetto",
                column: "IDAnagrafica",
                principalTable: "Anagrafica",
                principalColumn: "IDAnagrafica",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FondoComune_FondoComune",
                table: "FondoComune",
                column: "IDAnagrafica",
                principalTable: "Anagrafica",
                principalColumn: "IDAnagrafica",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
