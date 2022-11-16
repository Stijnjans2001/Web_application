using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LaFiesta.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "LaFiestaDB");

            migrationBuilder.CreateTable(
                name: "Artiest",
                schema: "LaFiestaDB",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Voornaam = table.Column<string>(nullable: false),
                    Achternaam = table.Column<string>(nullable: false),
                    Geslacht = table.Column<string>(nullable: false),
                    Geboortedatum = table.Column<DateTime>(nullable: false),
                    Afbeelding = table.Column<string>(nullable: false),
                    Genre = table.Column<string>(nullable: false),
                    ArtiestId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artiest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Artiest_Artiest_ArtiestId",
                        column: x => x.ArtiestId,
                        principalSchema: "LaFiestaDB",
                        principalTable: "Artiest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Locaties",
                schema: "LaFiestaDB",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Huisnummer = table.Column<string>(nullable: false),
                    Straat = table.Column<string>(nullable: false),
                    Plaats = table.Column<string>(nullable: false),
                    Postcode = table.Column<string>(nullable: false),
                    LocatieId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locaties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locaties_Locaties_LocatieId",
                        column: x => x.LocatieId,
                        principalSchema: "LaFiestaDB",
                        principalTable: "Locaties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                schema: "LaFiestaDB",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datum = table.Column<DateTime>(nullable: false),
                    Soort = table.Column<string>(nullable: false),
                    Prijs = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Aantal = table.Column<int>(nullable: false),
                    TicketId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ticket_Ticket_TicketId",
                        column: x => x.TicketId,
                        principalSchema: "LaFiestaDB",
                        principalTable: "Ticket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Festival",
                schema: "LaFiestaDB",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(nullable: false),
                    Omschrijving = table.Column<string>(nullable: false),
                    BeginDatum = table.Column<DateTime>(nullable: false),
                    EindDatum = table.Column<DateTime>(nullable: false),
                    MinimumLeeftijd = table.Column<int>(nullable: false),
                    Afbeelding = table.Column<string>(nullable: false),
                    LocatieId = table.Column<int>(nullable: false),
                    FestivalId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Festival", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Festival_Festival_FestivalId",
                        column: x => x.FestivalId,
                        principalSchema: "LaFiestaDB",
                        principalTable: "Festival",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Festival_Locaties_LocatieId",
                        column: x => x.LocatieId,
                        principalSchema: "LaFiestaDB",
                        principalTable: "Locaties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FestivalArtiests",
                schema: "LaFiestaDB",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FestivalId = table.Column<int>(nullable: false),
                    ArtiestId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FestivalArtiests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FestivalArtiests_Artiest_ArtiestId",
                        column: x => x.ArtiestId,
                        principalSchema: "LaFiestaDB",
                        principalTable: "Artiest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FestivalArtiests_Festival_FestivalId",
                        column: x => x.FestivalId,
                        principalSchema: "LaFiestaDB",
                        principalTable: "Festival",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TicketFestivals",
                schema: "LaFiestaDB",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FestivalId = table.Column<int>(nullable: false),
                    TicketId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketFestivals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketFestivals_Festival_FestivalId",
                        column: x => x.FestivalId,
                        principalSchema: "LaFiestaDB",
                        principalTable: "Festival",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketFestivals_Ticket_TicketId",
                        column: x => x.TicketId,
                        principalSchema: "LaFiestaDB",
                        principalTable: "Ticket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artiest_ArtiestId",
                schema: "LaFiestaDB",
                table: "Artiest",
                column: "ArtiestId");

            migrationBuilder.CreateIndex(
                name: "IX_Festival_FestivalId",
                schema: "LaFiestaDB",
                table: "Festival",
                column: "FestivalId");

            migrationBuilder.CreateIndex(
                name: "IX_Festival_LocatieId",
                schema: "LaFiestaDB",
                table: "Festival",
                column: "LocatieId");

            migrationBuilder.CreateIndex(
                name: "IX_FestivalArtiests_ArtiestId",
                schema: "LaFiestaDB",
                table: "FestivalArtiests",
                column: "ArtiestId");

            migrationBuilder.CreateIndex(
                name: "IX_FestivalArtiests_FestivalId",
                schema: "LaFiestaDB",
                table: "FestivalArtiests",
                column: "FestivalId");

            migrationBuilder.CreateIndex(
                name: "IX_Locaties_LocatieId",
                schema: "LaFiestaDB",
                table: "Locaties",
                column: "LocatieId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_TicketId",
                schema: "LaFiestaDB",
                table: "Ticket",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketFestivals_FestivalId",
                schema: "LaFiestaDB",
                table: "TicketFestivals",
                column: "FestivalId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketFestivals_TicketId",
                schema: "LaFiestaDB",
                table: "TicketFestivals",
                column: "TicketId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FestivalArtiests",
                schema: "LaFiestaDB");

            migrationBuilder.DropTable(
                name: "TicketFestivals",
                schema: "LaFiestaDB");

            migrationBuilder.DropTable(
                name: "Artiest",
                schema: "LaFiestaDB");

            migrationBuilder.DropTable(
                name: "Festival",
                schema: "LaFiestaDB");

            migrationBuilder.DropTable(
                name: "Ticket",
                schema: "LaFiestaDB");

            migrationBuilder.DropTable(
                name: "Locaties",
                schema: "LaFiestaDB");
        }
    }
}
