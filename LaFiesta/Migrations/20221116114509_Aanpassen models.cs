using Microsoft.EntityFrameworkCore.Migrations;

namespace LaFiesta.Migrations
{
    public partial class Aanpassenmodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FestivalArtiests_Artiest_ArtiestId",
                schema: "LaFiestaDB",
                table: "FestivalArtiests");

            migrationBuilder.DropForeignKey(
                name: "FK_FestivalArtiests_Festival_FestivalId",
                schema: "LaFiestaDB",
                table: "FestivalArtiests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FestivalArtiests",
                schema: "LaFiestaDB",
                table: "FestivalArtiests");

            migrationBuilder.RenameTable(
                name: "FestivalArtiests",
                schema: "LaFiestaDB",
                newName: "FestivalArtiesten",
                newSchema: "LaFiestaDB");

            migrationBuilder.RenameIndex(
                name: "IX_FestivalArtiests_FestivalId",
                schema: "LaFiestaDB",
                table: "FestivalArtiesten",
                newName: "IX_FestivalArtiesten_FestivalId");

            migrationBuilder.RenameIndex(
                name: "IX_FestivalArtiests_ArtiestId",
                schema: "LaFiestaDB",
                table: "FestivalArtiesten",
                newName: "IX_FestivalArtiesten_ArtiestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FestivalArtiesten",
                schema: "LaFiestaDB",
                table: "FestivalArtiesten",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FestivalArtiesten_Artiest_ArtiestId",
                schema: "LaFiestaDB",
                table: "FestivalArtiesten",
                column: "ArtiestId",
                principalSchema: "LaFiestaDB",
                principalTable: "Artiest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FestivalArtiesten_Festival_FestivalId",
                schema: "LaFiestaDB",
                table: "FestivalArtiesten",
                column: "FestivalId",
                principalSchema: "LaFiestaDB",
                principalTable: "Festival",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FestivalArtiesten_Artiest_ArtiestId",
                schema: "LaFiestaDB",
                table: "FestivalArtiesten");

            migrationBuilder.DropForeignKey(
                name: "FK_FestivalArtiesten_Festival_FestivalId",
                schema: "LaFiestaDB",
                table: "FestivalArtiesten");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FestivalArtiesten",
                schema: "LaFiestaDB",
                table: "FestivalArtiesten");

            migrationBuilder.RenameTable(
                name: "FestivalArtiesten",
                schema: "LaFiestaDB",
                newName: "FestivalArtiests",
                newSchema: "LaFiestaDB");

            migrationBuilder.RenameIndex(
                name: "IX_FestivalArtiesten_FestivalId",
                schema: "LaFiestaDB",
                table: "FestivalArtiests",
                newName: "IX_FestivalArtiests_FestivalId");

            migrationBuilder.RenameIndex(
                name: "IX_FestivalArtiesten_ArtiestId",
                schema: "LaFiestaDB",
                table: "FestivalArtiests",
                newName: "IX_FestivalArtiests_ArtiestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FestivalArtiests",
                schema: "LaFiestaDB",
                table: "FestivalArtiests",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FestivalArtiests_Artiest_ArtiestId",
                schema: "LaFiestaDB",
                table: "FestivalArtiests",
                column: "ArtiestId",
                principalSchema: "LaFiestaDB",
                principalTable: "Artiest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FestivalArtiests_Festival_FestivalId",
                schema: "LaFiestaDB",
                table: "FestivalArtiests",
                column: "FestivalId",
                principalSchema: "LaFiestaDB",
                principalTable: "Festival",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
