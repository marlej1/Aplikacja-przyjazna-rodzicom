using Microsoft.EntityFrameworkCore.Migrations;

namespace BoboTu.Data.Migrations
{
    public partial class updateColunmNamVenueId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Opinions_Venues_VanueId",
                table: "Opinions");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Venues_VanueId",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_VanueId",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Opinions_VanueId",
                table: "Opinions");

            migrationBuilder.DropColumn(
                name: "VanueId",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "VanueId",
                table: "Opinions");

            migrationBuilder.AddColumn<int>(
                name: "VenueId",
                table: "Ratings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VenueId",
                table: "Opinions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_VenueId",
                table: "Ratings",
                column: "VenueId");

            migrationBuilder.CreateIndex(
                name: "IX_Opinions_VenueId",
                table: "Opinions",
                column: "VenueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Opinions_Venues_VenueId",
                table: "Opinions",
                column: "VenueId",
                principalTable: "Venues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Venues_VenueId",
                table: "Ratings",
                column: "VenueId",
                principalTable: "Venues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Opinions_Venues_VenueId",
                table: "Opinions");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Venues_VenueId",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_VenueId",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Opinions_VenueId",
                table: "Opinions");

            migrationBuilder.DropColumn(
                name: "VenueId",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "VenueId",
                table: "Opinions");

            migrationBuilder.AddColumn<int>(
                name: "VanueId",
                table: "Ratings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VanueId",
                table: "Opinions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_VanueId",
                table: "Ratings",
                column: "VanueId");

            migrationBuilder.CreateIndex(
                name: "IX_Opinions_VanueId",
                table: "Opinions",
                column: "VanueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Opinions_Venues_VanueId",
                table: "Opinions",
                column: "VanueId",
                principalTable: "Venues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Venues_VanueId",
                table: "Ratings",
                column: "VanueId",
                principalTable: "Venues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
