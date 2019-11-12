using Microsoft.EntityFrameworkCore.Migrations;

namespace Varyag.Migrations
{
    public partial class newsFotos_alt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MiddleImgAlt",
                table: "News",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MiddleImgTitle",
                table: "News",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShortImgAlt",
                table: "News",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShortImgTitle",
                table: "News",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WideImgAlt",
                table: "News",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WideImgTitle",
                table: "News",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MiddleImgAlt",
                table: "News");

            migrationBuilder.DropColumn(
                name: "MiddleImgTitle",
                table: "News");

            migrationBuilder.DropColumn(
                name: "ShortImgAlt",
                table: "News");

            migrationBuilder.DropColumn(
                name: "ShortImgTitle",
                table: "News");

            migrationBuilder.DropColumn(
                name: "WideImgAlt",
                table: "News");

            migrationBuilder.DropColumn(
                name: "WideImgTitle",
                table: "News");
        }
    }
}
