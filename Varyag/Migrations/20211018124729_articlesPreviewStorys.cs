using Microsoft.EntityFrameworkCore.Migrations;

namespace Varyag.Migrations
{
    public partial class articlesPreviewStorys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MiddleStory",
                table: "Article",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShortStory",
                table: "Article",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WideStory",
                table: "Article",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MiddleStory",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "ShortStory",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "WideStory",
                table: "Article");
        }
    }
}
