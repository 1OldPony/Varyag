using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Varyag.Migrations
{
    public partial class shipShemeFull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShortDescription",
                table: "Project");

            migrationBuilder.AddColumn<byte[]>(
                name: "ShipShemeFull",
                table: "Project",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShipShemeFull",
                table: "Project");

            migrationBuilder.AddColumn<string>(
                name: "ShortDescription",
                table: "Project",
                nullable: true);
        }
    }
}
