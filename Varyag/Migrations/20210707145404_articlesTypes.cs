using Microsoft.EntityFrameworkCore.Migrations;

namespace Varyag.Migrations
{
    public partial class articlesTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Movies",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "Museums",
                table: "Article");
        }
    }
}
