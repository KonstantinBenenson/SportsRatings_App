using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportsRatings.Migrations
{
    public partial class RenamePropertyInSportsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sports_Categories_SportCategoriesModelId",
                table: "Sports");

            migrationBuilder.DropIndex(
                name: "IX_Sports_SportCategoriesModelId",
                table: "Sports");

            migrationBuilder.DropColumn(
                name: "SportCategoriesModelId",
                table: "Sports");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Sports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sports_CategoryId",
                table: "Sports",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sports_Categories_CategoryId",
                table: "Sports",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sports_Categories_CategoryId",
                table: "Sports");

            migrationBuilder.DropIndex(
                name: "IX_Sports_CategoryId",
                table: "Sports");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Sports");

            migrationBuilder.AddColumn<int>(
                name: "SportCategoriesModelId",
                table: "Sports",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sports_SportCategoriesModelId",
                table: "Sports",
                column: "SportCategoriesModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sports_Categories_SportCategoriesModelId",
                table: "Sports",
                column: "SportCategoriesModelId",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}
