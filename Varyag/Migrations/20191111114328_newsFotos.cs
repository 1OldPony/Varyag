using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Varyag.Migrations
{
    public partial class newsFotos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NewsMainFoto",
                table: "News");

            migrationBuilder.AddColumn<string>(
                name: "MiddleImgPath",
                table: "News",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MiddleImgScale",
                table: "News",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MiddleImgX",
                table: "News",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MiddleImgY",
                table: "News",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShortImgPath",
                table: "News",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShortImgScale",
                table: "News",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShortImgX",
                table: "News",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShortImgY",
                table: "News",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WideImgPath",
                table: "News",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WideImgScale",
                table: "News",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WideImgX",
                table: "News",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WideImgY",
                table: "News",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MiddleImgPath",
                table: "News");

            migrationBuilder.DropColumn(
                name: "MiddleImgScale",
                table: "News");

            migrationBuilder.DropColumn(
                name: "MiddleImgX",
                table: "News");

            migrationBuilder.DropColumn(
                name: "MiddleImgY",
                table: "News");

            migrationBuilder.DropColumn(
                name: "ShortImgPath",
                table: "News");

            migrationBuilder.DropColumn(
                name: "ShortImgScale",
                table: "News");

            migrationBuilder.DropColumn(
                name: "ShortImgX",
                table: "News");

            migrationBuilder.DropColumn(
                name: "ShortImgY",
                table: "News");

            migrationBuilder.DropColumn(
                name: "WideImgPath",
                table: "News");

            migrationBuilder.DropColumn(
                name: "WideImgScale",
                table: "News");

            migrationBuilder.DropColumn(
                name: "WideImgX",
                table: "News");

            migrationBuilder.DropColumn(
                name: "WideImgY",
                table: "News");

            migrationBuilder.AddColumn<byte[]>(
                name: "NewsMainFoto",
                table: "News",
                nullable: true);
        }
    }
}
