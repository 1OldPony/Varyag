using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Varyag.Migrations
{
    public partial class NewsGallery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "NewsDate",
                table: "News",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PathToGallery",
                table: "News",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PathToGallery",
                table: "News");

            migrationBuilder.AlterColumn<string>(
                name: "NewsDate",
                table: "News",
                nullable: true,
                oldClrType: typeof(DateTime));
        }
    }
}
