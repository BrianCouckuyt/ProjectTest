using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WhittyServer.Web.Migrations
{
    public partial class seeder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Email", "FirstName", "Highscore", "Image", "IngameName", "LastName", "Password" },
                values: new object[] { new Guid("ed596935-fb00-486b-ba11-727270cdfa62"), "jens@whittygitters.be", "Jens", 0.0, null, "TheFirstOfTheWhittens", "De Weirdt", "thaha" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("ed596935-fb00-486b-ba11-727270cdfa62"));
        }
    }
}
