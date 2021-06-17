using Microsoft.EntityFrameworkCore.Migrations;

namespace Varyag.Migrations
{
    public partial class projectNewsLink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LinkedProjectName",
                table: "News",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LinkedProjectName",
                table: "News");
        }
    }
}
