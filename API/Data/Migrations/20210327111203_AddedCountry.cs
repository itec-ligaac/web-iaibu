using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class AddedCountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    IsoCode = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CountryData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TotalVaccinations = table.Column<int>(type: "INTEGER", nullable: false),
                    PeopleVaccinated = table.Column<int>(type: "INTEGER", nullable: false),
                    TotalVaccinationsPerHunderd = table.Column<int>(type: "INTEGER", nullable: false),
                    PeopleVaccinatedPerHunderd = table.Column<int>(type: "INTEGER", nullable: false),
                    DailyVaccinations = table.Column<int>(type: "INTEGER", nullable: false),
                    DailyVaccinationsPerMilion = table.Column<int>(type: "INTEGER", nullable: false),
                    DailyVaccinationsPerHundred = table.Column<int>(type: "INTEGER", nullable: false),
                    CountryId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CountryData_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CountryData_CountryId",
                table: "CountryData",
                column: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CountryData");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
