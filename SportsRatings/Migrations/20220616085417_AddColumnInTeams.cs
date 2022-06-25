using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportsRatings.Migrations
{
    public partial class AddColumnInTeams : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SportId",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_SportId",
                table: "Teams",
                column: "SportId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Sports_SportId",
                table: "Teams",
                column: "SportId",
                principalTable: "Sports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Sports_SportId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_SportId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "SportId",
                table: "Teams");
        }
    }
}
