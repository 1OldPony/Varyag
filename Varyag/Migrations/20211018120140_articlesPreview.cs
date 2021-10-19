using Microsoft.EntityFrameworkCore.Migrations;

namespace Varyag.Migrations
{
    public partial class articlesPreview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MiddleFotoPreview",
                table: "Article",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MiddleImgScale",
                table: "Article",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MiddleImgX",
                table: "Article",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MiddleImgY",
                table: "Article",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShortFotoPreview",
                table: "Article",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShortImgScale",
                table: "Article",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShortImgX",
                table: "Article",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShortImgY",
                table: "Article",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WideFotoPreview",
                table: "Article",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WideImgScale",
                table: "Article",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WideImgX",
                table: "Article",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WideImgY",
                table: "Article",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MiddleFotoPreview",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "MiddleImgScale",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "MiddleImgX",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "MiddleImgY",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "ShortFotoPreview",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "ShortImgScale",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "ShortImgX",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "ShortImgY",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "WideFotoPreview",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "WideImgScale",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "WideImgX",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "WideImgY",
                table: "Article");
        }
    }
}
