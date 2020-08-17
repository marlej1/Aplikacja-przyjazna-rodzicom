using Microsoft.EntityFrameworkCore.Migrations;

namespace BoboTu.Data.Migrations
{
    public partial class AddUSerNameOpinionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Opinions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Opinions");
        }
    }
}
