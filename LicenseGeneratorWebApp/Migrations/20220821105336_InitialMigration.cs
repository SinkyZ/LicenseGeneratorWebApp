using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LicenseGeneratorWebApp.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    IdClient = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.IdClient);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    IdProdus = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumeProdus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.IdProdus);
                });

            migrationBuilder.CreateTable(
                name: "Licenses",
                columns: table => new
                {
                    IdLicense = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LicenseContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LicenseType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpirationDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdProdus = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdClient = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Licenses", x => x.IdLicense);
                    table.ForeignKey(
                        name: "FK_Licenses_Clients_IdClient",
                        column: x => x.IdClient,
                        principalTable: "Clients",
                        principalColumn: "IdClient",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Licenses_Products_IdProdus",
                        column: x => x.IdProdus,
                        principalTable: "Products",
                        principalColumn: "IdProdus",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Licenses_IdClient",
                table: "Licenses",
                column: "IdClient");

            migrationBuilder.CreateIndex(
                name: "IX_Licenses_IdProdus",
                table: "Licenses",
                column: "IdProdus");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Licenses");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
