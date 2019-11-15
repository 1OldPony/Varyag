using Microsoft.EntityFrameworkCore.Migrations;

namespace Varyag.Migrations
{
    public partial class _3storys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MiddleStory",
                table: "News",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WideStory",
                table: "News",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MiddleStory",
                table: "News");

            migrationBuilder.DropColumn(
                name: "WideStory",
                table: "News");
        }
    }
}
