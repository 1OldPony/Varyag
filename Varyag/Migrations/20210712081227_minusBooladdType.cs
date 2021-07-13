using Microsoft.EntityFrameworkCore.Migrations;

namespace Varyag.Migrations
{
    public partial class minusBooladdType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Movies",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "Museums",
                table: "Article");

            migrationBuilder.AddColumn<string>(
                name: "ArticleType",
                table: "Article",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArticleType",
                table: "Article");

            migrationBuilder.AddColumn<bool>(
                name: "Movies",
                table: "Article",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Museums",
                table: "Article",
                nullable: false,
                defaultValue: false);
        }
    }
}
