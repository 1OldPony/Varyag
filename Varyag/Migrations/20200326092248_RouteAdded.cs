using Microsoft.EntityFrameworkCore.Migrations;

namespace Varyag.Migrations
{
    public partial class RouteAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Route",
                table: "Project",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ArticleRoute",
                table: "Article",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Route",
                table: "AnythingElse",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Route",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "ArticleRoute",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "Route",
                table: "AnythingElse");
        }
    }
}
