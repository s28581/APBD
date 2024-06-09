using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APBDProbnyKol2.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Muzyka",
                columns: table => new
                {
                    IdMuzyk = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Pseudonim = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Muzyka", x => x.IdMuzyk);
                });

            migrationBuilder.CreateTable(
                name: "Wytwornie",
                columns: table => new
                {
                    IdWytwornia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wytwornie", x => x.IdWytwornia);
                });

            migrationBuilder.CreateTable(
                name: "Albumy",
                columns: table => new
                {
                    IdAlbum = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaAlbumu = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DataWydania = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdWytwornia = table.Column<int>(type: "int", nullable: false),
                    WytworniaIdWytwornia = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albumy", x => x.IdAlbum);
                    table.ForeignKey(
                        name: "FK_Albumy_Wytwornie_WytworniaIdWytwornia",
                        column: x => x.WytworniaIdWytwornia,
                        principalTable: "Wytwornie",
                        principalColumn: "IdWytwornia");
                });

            migrationBuilder.CreateTable(
                name: "Utwory",
                columns: table => new
                {
                    IdUtwor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaUtworu = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CzasTrwania = table.Column<float>(type: "real", nullable: false),
                    IdAlbum = table.Column<int>(type: "int", nullable: false),
                    AlbumIdAlbum = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utwory", x => x.IdUtwor);
                    table.ForeignKey(
                        name: "FK_Utwory_Albumy_AlbumIdAlbum",
                        column: x => x.AlbumIdAlbum,
                        principalTable: "Albumy",
                        principalColumn: "IdAlbum");
                });

            migrationBuilder.CreateTable(
                name: "MuzykUtwor",
                columns: table => new
                {
                    MuzycyIdMuzyk = table.Column<int>(type: "int", nullable: false),
                    UtworyIdUtwor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MuzykUtwor", x => new { x.MuzycyIdMuzyk, x.UtworyIdUtwor });
                    table.ForeignKey(
                        name: "FK_MuzykUtwor_Muzyka_MuzycyIdMuzyk",
                        column: x => x.MuzycyIdMuzyk,
                        principalTable: "Muzyka",
                        principalColumn: "IdMuzyk",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MuzykUtwor_Utwory_UtworyIdUtwor",
                        column: x => x.UtworyIdUtwor,
                        principalTable: "Utwory",
                        principalColumn: "IdUtwor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Albumy_WytworniaIdWytwornia",
                table: "Albumy",
                column: "WytworniaIdWytwornia");

            migrationBuilder.CreateIndex(
                name: "IX_MuzykUtwor_UtworyIdUtwor",
                table: "MuzykUtwor",
                column: "UtworyIdUtwor");

            migrationBuilder.CreateIndex(
                name: "IX_Utwory_AlbumIdAlbum",
                table: "Utwory",
                column: "AlbumIdAlbum");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MuzykUtwor");

            migrationBuilder.DropTable(
                name: "Muzyka");

            migrationBuilder.DropTable(
                name: "Utwory");

            migrationBuilder.DropTable(
                name: "Albumy");

            migrationBuilder.DropTable(
                name: "Wytwornie");
        }
    }
}
