using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LaFiesta.Migrations
{
    public partial class AddIdentitySchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Festival_Locaties_LocatieId",
                schema: "LaFiestaDB",
                table: "Festival");

            migrationBuilder.DropForeignKey(
                name: "FK_FestivalArtiesten_Artiest_ArtiestId",
                schema: "LaFiestaDB",
                table: "FestivalArtiesten");

            migrationBuilder.DropForeignKey(
                name: "FK_FestivalArtiesten_Festival_FestivalId",
                schema: "LaFiestaDB",
                table: "FestivalArtiesten");

            migrationBuilder.DropForeignKey(
                name: "FK_Locaties_Locaties_LocatieId",
                schema: "LaFiestaDB",
                table: "Locaties");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketFestivals_Festival_FestivalId",
                schema: "LaFiestaDB",
                table: "TicketFestivals");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketFestivals_Ticket_TicketId",
                schema: "LaFiestaDB",
                table: "TicketFestivals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketFestivals",
                schema: "LaFiestaDB",
                table: "TicketFestivals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Locaties",
                schema: "LaFiestaDB",
                table: "Locaties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FestivalArtiesten",
                schema: "LaFiestaDB",
                table: "FestivalArtiesten");

            migrationBuilder.RenameTable(
                name: "TicketFestivals",
                schema: "LaFiestaDB",
                newName: "TicketFestival",
                newSchema: "LaFiestaDB");

            migrationBuilder.RenameTable(
                name: "Locaties",
                schema: "LaFiestaDB",
                newName: "Locatie",
                newSchema: "LaFiestaDB");

            migrationBuilder.RenameTable(
                name: "FestivalArtiesten",
                schema: "LaFiestaDB",
                newName: "FestivalArtiest",
                newSchema: "LaFiestaDB");

            migrationBuilder.RenameIndex(
                name: "IX_TicketFestivals_TicketId",
                schema: "LaFiestaDB",
                table: "TicketFestival",
                newName: "IX_TicketFestival_TicketId");

            migrationBuilder.RenameIndex(
                name: "IX_TicketFestivals_FestivalId",
                schema: "LaFiestaDB",
                table: "TicketFestival",
                newName: "IX_TicketFestival_FestivalId");

            migrationBuilder.RenameIndex(
                name: "IX_Locaties_LocatieId",
                schema: "LaFiestaDB",
                table: "Locatie",
                newName: "IX_Locatie_LocatieId");

            migrationBuilder.RenameIndex(
                name: "IX_FestivalArtiesten_FestivalId",
                schema: "LaFiestaDB",
                table: "FestivalArtiest",
                newName: "IX_FestivalArtiest_FestivalId");

            migrationBuilder.RenameIndex(
                name: "IX_FestivalArtiesten_ArtiestId",
                schema: "LaFiestaDB",
                table: "FestivalArtiest",
                newName: "IX_FestivalArtiest_ArtiestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketFestival",
                schema: "LaFiestaDB",
                table: "TicketFestival",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Locatie",
                schema: "LaFiestaDB",
                table: "Locatie",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FestivalArtiest",
                schema: "LaFiestaDB",
                table: "FestivalArtiest",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                schema: "LaFiestaDB",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                schema: "LaFiestaDB",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                schema: "LaFiestaDB",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "LaFiestaDB",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                schema: "LaFiestaDB",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "LaFiestaDB",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                schema: "LaFiestaDB",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "LaFiestaDB",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                schema: "LaFiestaDB",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "LaFiestaDB",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "LaFiestaDB",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                schema: "LaFiestaDB",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "LaFiestaDB",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                schema: "LaFiestaDB",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "LaFiestaDB",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                schema: "LaFiestaDB",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                schema: "LaFiestaDB",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                schema: "LaFiestaDB",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "LaFiestaDB",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "LaFiestaDB",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Festival_Locatie_LocatieId",
                schema: "LaFiestaDB",
                table: "Festival",
                column: "LocatieId",
                principalSchema: "LaFiestaDB",
                principalTable: "Locatie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FestivalArtiest_Artiest_ArtiestId",
                schema: "LaFiestaDB",
                table: "FestivalArtiest",
                column: "ArtiestId",
                principalSchema: "LaFiestaDB",
                principalTable: "Artiest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FestivalArtiest_Festival_FestivalId",
                schema: "LaFiestaDB",
                table: "FestivalArtiest",
                column: "FestivalId",
                principalSchema: "LaFiestaDB",
                principalTable: "Festival",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Locatie_Locatie_LocatieId",
                schema: "LaFiestaDB",
                table: "Locatie",
                column: "LocatieId",
                principalSchema: "LaFiestaDB",
                principalTable: "Locatie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketFestival_Festival_FestivalId",
                schema: "LaFiestaDB",
                table: "TicketFestival",
                column: "FestivalId",
                principalSchema: "LaFiestaDB",
                principalTable: "Festival",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketFestival_Ticket_TicketId",
                schema: "LaFiestaDB",
                table: "TicketFestival",
                column: "TicketId",
                principalSchema: "LaFiestaDB",
                principalTable: "Ticket",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Festival_Locatie_LocatieId",
                schema: "LaFiestaDB",
                table: "Festival");

            migrationBuilder.DropForeignKey(
                name: "FK_FestivalArtiest_Artiest_ArtiestId",
                schema: "LaFiestaDB",
                table: "FestivalArtiest");

            migrationBuilder.DropForeignKey(
                name: "FK_FestivalArtiest_Festival_FestivalId",
                schema: "LaFiestaDB",
                table: "FestivalArtiest");

            migrationBuilder.DropForeignKey(
                name: "FK_Locatie_Locatie_LocatieId",
                schema: "LaFiestaDB",
                table: "Locatie");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketFestival_Festival_FestivalId",
                schema: "LaFiestaDB",
                table: "TicketFestival");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketFestival_Ticket_TicketId",
                schema: "LaFiestaDB",
                table: "TicketFestival");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims",
                schema: "LaFiestaDB");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims",
                schema: "LaFiestaDB");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins",
                schema: "LaFiestaDB");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles",
                schema: "LaFiestaDB");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens",
                schema: "LaFiestaDB");

            migrationBuilder.DropTable(
                name: "AspNetRoles",
                schema: "LaFiestaDB");

            migrationBuilder.DropTable(
                name: "AspNetUsers",
                schema: "LaFiestaDB");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketFestival",
                schema: "LaFiestaDB",
                table: "TicketFestival");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Locatie",
                schema: "LaFiestaDB",
                table: "Locatie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FestivalArtiest",
                schema: "LaFiestaDB",
                table: "FestivalArtiest");

            migrationBuilder.RenameTable(
                name: "TicketFestival",
                schema: "LaFiestaDB",
                newName: "TicketFestivals",
                newSchema: "LaFiestaDB");

            migrationBuilder.RenameTable(
                name: "Locatie",
                schema: "LaFiestaDB",
                newName: "Locaties",
                newSchema: "LaFiestaDB");

            migrationBuilder.RenameTable(
                name: "FestivalArtiest",
                schema: "LaFiestaDB",
                newName: "FestivalArtiesten",
                newSchema: "LaFiestaDB");

            migrationBuilder.RenameIndex(
                name: "IX_TicketFestival_TicketId",
                schema: "LaFiestaDB",
                table: "TicketFestivals",
                newName: "IX_TicketFestivals_TicketId");

            migrationBuilder.RenameIndex(
                name: "IX_TicketFestival_FestivalId",
                schema: "LaFiestaDB",
                table: "TicketFestivals",
                newName: "IX_TicketFestivals_FestivalId");

            migrationBuilder.RenameIndex(
                name: "IX_Locatie_LocatieId",
                schema: "LaFiestaDB",
                table: "Locaties",
                newName: "IX_Locaties_LocatieId");

            migrationBuilder.RenameIndex(
                name: "IX_FestivalArtiest_FestivalId",
                schema: "LaFiestaDB",
                table: "FestivalArtiesten",
                newName: "IX_FestivalArtiesten_FestivalId");

            migrationBuilder.RenameIndex(
                name: "IX_FestivalArtiest_ArtiestId",
                schema: "LaFiestaDB",
                table: "FestivalArtiesten",
                newName: "IX_FestivalArtiesten_ArtiestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketFestivals",
                schema: "LaFiestaDB",
                table: "TicketFestivals",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Locaties",
                schema: "LaFiestaDB",
                table: "Locaties",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FestivalArtiesten",
                schema: "LaFiestaDB",
                table: "FestivalArtiesten",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Festival_Locaties_LocatieId",
                schema: "LaFiestaDB",
                table: "Festival",
                column: "LocatieId",
                principalSchema: "LaFiestaDB",
                principalTable: "Locaties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Locaties_Locaties_LocatieId",
                schema: "LaFiestaDB",
                table: "Locaties",
                column: "LocatieId",
                principalSchema: "LaFiestaDB",
                principalTable: "Locaties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketFestivals_Festival_FestivalId",
                schema: "LaFiestaDB",
                table: "TicketFestivals",
                column: "FestivalId",
                principalSchema: "LaFiestaDB",
                principalTable: "Festival",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketFestivals_Ticket_TicketId",
                schema: "LaFiestaDB",
                table: "TicketFestivals",
                column: "TicketId",
                principalSchema: "LaFiestaDB",
                principalTable: "Ticket",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
