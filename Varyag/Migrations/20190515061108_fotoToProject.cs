using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Varyag.Migrations
{
    public partial class fotoToProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "MainFoto",
                table: "Project",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "ShipSheme",
                table: "Project",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MainFoto",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "ShipSheme",
                table: "Project");
        }
    }
}
