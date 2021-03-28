using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class dataCountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CountryData_Countries_CountryId",
                table: "CountryData");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CountryData",
                table: "CountryData");

            migrationBuilder.RenameTable(
                name: "CountryData",
                newName: "CountryDatas");

            migrationBuilder.RenameIndex(
                name: "IX_CountryData_CountryId",
                table: "CountryDatas",
                newName: "IX_CountryDatas_CountryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CountryDatas",
                table: "CountryDatas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CountryDatas_Countries_CountryId",
                table: "CountryDatas",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CountryDatas_Countries_CountryId",
                table: "CountryDatas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CountryDatas",
                table: "CountryDatas");

            migrationBuilder.RenameTable(
                name: "CountryDatas",
                newName: "CountryData");

            migrationBuilder.RenameIndex(
                name: "IX_CountryDatas_CountryId",
                table: "CountryData",
                newName: "IX_CountryData_CountryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CountryData",
                table: "CountryData",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CountryData_Countries_CountryId",
                table: "CountryData",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
