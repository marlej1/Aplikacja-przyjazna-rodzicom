using Microsoft.EntityFrameworkCore.Migrations;

namespace BoboTu.Data.Migrations
{
    public partial class AddHouseNumberToVenueTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HouseNumber",
                table: "Venues",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HouseNumber",
                table: "Venues");
        }
    }
}
