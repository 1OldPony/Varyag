using Microsoft.EntityFrameworkCore.Migrations;

namespace Varyag.Migrations
{
    public partial class paths : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MiddleFotoPreview",
                table: "News",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShortFotoPreview",
                table: "News",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WideFotoPreview",
                table: "News",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MiddleFotoPreview",
                table: "News");

            migrationBuilder.DropColumn(
                name: "ShortFotoPreview",
                table: "News");

            migrationBuilder.DropColumn(
                name: "WideFotoPreview",
                table: "News");
        }
    }
}
