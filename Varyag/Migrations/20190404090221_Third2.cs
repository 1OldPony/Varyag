using Microsoft.EntityFrameworkCore.Migrations;

namespace Varyag.Migrations
{
    public partial class Third2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Windth",
                table: "Project",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10, 1)");

            migrationBuilder.AlterColumn<string>(
                name: "Volume",
                table: "Project",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10, 1)");

            migrationBuilder.AlterColumn<string>(
                name: "SailArea",
                table: "Project",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10, 1)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Length",
                table: "Project",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10, 1)");

            migrationBuilder.AlterColumn<string>(
                name: "Deep",
                table: "Project",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10, 1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Windth",
                table: "Project",
                type: "decimal(10, 1)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<decimal>(
                name: "Volume",
                table: "Project",
                type: "decimal(10, 1)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<decimal>(
                name: "SailArea",
                table: "Project",
                type: "decimal(10, 1)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Length",
                table: "Project",
                type: "decimal(10, 1)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<decimal>(
                name: "Deep",
                table: "Project",
                type: "decimal(10, 1)",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
