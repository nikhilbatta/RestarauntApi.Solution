using Microsoft.EntityFrameworkCore.Migrations;

namespace RestarauntApi.Migrations
{
    public partial class Locationproperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Restraunts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Restraunts");
        }
    }
}
