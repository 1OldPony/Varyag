using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Varyag.Migrations
{
    public partial class massoars : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Windth",
                table: "Project",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Volume",
                table: "Project",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "SailArea",
                table: "Project",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Length",
                table: "Project",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Deep",
                table: "Project",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "Mass",
                table: "Project",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumberOfOars",
                table: "Project",
                maxLength: 5,
                nullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "ProjectFoto",
                table: "Foto",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mass",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "NumberOfOars",
                table: "Project");

            migrationBuilder.AlterColumn<string>(
                name: "Windth",
                table: "Project",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 5);

            migrationBuilder.AlterColumn<string>(
                name: "Volume",
                table: "Project",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SailArea",
                table: "Project",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Length",
                table: "Project",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 5);

            migrationBuilder.AlterColumn<string>(
                name: "Deep",
                table: "Project",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 5);

            migrationBuilder.AlterColumn<byte[]>(
                name: "ProjectFoto",
                table: "Foto",
                nullable: true,
                oldClrType: typeof(byte[]));
        }
    }
}
