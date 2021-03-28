using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class changeFromDecimalToInt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "TotalVaccinationsPerHunderd",
                table: "CountryData",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<decimal>(
                name: "PeopleVaccinatedPerHunderd",
                table: "CountryData",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "DailyVaccinationsRaw",
                table: "CountryData",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PeopleFullyVaccinated",
                table: "CountryData",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "PeopleFullyVaccinatedPerHundred",
                table: "CountryData",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DailyVaccinationsRaw",
                table: "CountryData");

            migrationBuilder.DropColumn(
                name: "PeopleFullyVaccinated",
                table: "CountryData");

            migrationBuilder.DropColumn(
                name: "PeopleFullyVaccinatedPerHundred",
                table: "CountryData");

            migrationBuilder.AlterColumn<int>(
                name: "TotalVaccinationsPerHunderd",
                table: "CountryData",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "PeopleVaccinatedPerHunderd",
                table: "CountryData",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");
        }
    }
}
