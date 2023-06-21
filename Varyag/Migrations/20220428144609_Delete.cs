using Microsoft.EntityFrameworkCore.Migrations;

namespace Varyag.Migrations
{
    public partial class Delete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Delete",
                table: "Project",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Delete",
                table: "Project");
        }
    }
}
