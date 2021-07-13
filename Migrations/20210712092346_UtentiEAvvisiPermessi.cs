using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SanGiuseppe.Migrations
{
    public partial class UtentiEAvvisiPermessi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UID",
                table: "Avvisi",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "AvvisiPermessi",
                columns: table => new
                {
                    IdAvvisPermesso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Idavviso = table.Column<int>(type: "int", nullable: false),
                    Permesso = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvvisiIdavviso = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvvisiPermessi", x => x.IdAvvisPermesso);
                    table.ForeignKey(
                        name: "FK_AvvisiPermessi_Avvisi_AvvisiIdavviso",
                        column: x => x.AvvisiIdavviso,
                        principalTable: "Avvisi",
                        principalColumn: "IDAvviso",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UtentiPermessi",
                columns: table => new
                {
                    IdUtentePermesso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Idutente = table.Column<int>(type: "int", nullable: false),
                    Permesso = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UtentiIdutente = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UtentiPermessi", x => x.IdUtentePermesso);
                    table.ForeignKey(
                        name: "FK_UtentiPermessi_Utenti_UtentiIdutente",
                        column: x => x.UtentiIdutente,
                        principalTable: "Utenti",
                        principalColumn: "IDUtente",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AvvisiPermessi_AvvisiIdavviso",
                table: "AvvisiPermessi",
                column: "AvvisiIdavviso");

            migrationBuilder.CreateIndex(
                name: "IX_UtentiPermessi_UtentiIdutente",
                table: "UtentiPermessi",
                column: "UtentiIdutente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AvvisiPermessi");

            migrationBuilder.DropTable(
                name: "UtentiPermessi");

            migrationBuilder.DropColumn(
                name: "UID",
                table: "Avvisi");
        }
    }
}
