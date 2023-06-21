using Microsoft.EntityFrameworkCore.Migrations;

namespace Varyag.Migrations
{
    public partial class VideoNews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PathToVideo1",
                table: "News",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PathToVideo2",
                table: "News",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PathToVideo3",
                table: "News",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PathToVideo1",
                table: "News");

            migrationBuilder.DropColumn(
                name: "PathToVideo2",
                table: "News");

            migrationBuilder.DropColumn(
                name: "PathToVideo3",
                table: "News");
        }
    }
}
