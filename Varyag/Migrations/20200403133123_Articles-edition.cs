using Microsoft.EntityFrameworkCore.Migrations;

namespace Varyag.Migrations
{
    public partial class Articlesedition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FotoPath9",
                table: "Article",
                newName: "PathToGallery9");

            migrationBuilder.RenameColumn(
                name: "FotoPath8",
                table: "Article",
                newName: "PathToGallery8");

            migrationBuilder.RenameColumn(
                name: "FotoPath7",
                table: "Article",
                newName: "PathToGallery7");

            migrationBuilder.RenameColumn(
                name: "FotoPath6",
                table: "Article",
                newName: "PathToGallery6");

            migrationBuilder.RenameColumn(
                name: "FotoPath5",
                table: "Article",
                newName: "PathToGallery5");

            migrationBuilder.RenameColumn(
                name: "FotoPath4",
                table: "Article",
                newName: "PathToGallery4");

            migrationBuilder.RenameColumn(
                name: "FotoPath3",
                table: "Article",
                newName: "PathToGallery3");

            migrationBuilder.RenameColumn(
                name: "FotoPath2",
                table: "Article",
                newName: "PathToGallery2");

            migrationBuilder.RenameColumn(
                name: "FotoPath15",
                table: "Article",
                newName: "PathToGallery15");

            migrationBuilder.RenameColumn(
                name: "FotoPath14",
                table: "Article",
                newName: "PathToGallery14");

            migrationBuilder.RenameColumn(
                name: "FotoPath13",
                table: "Article",
                newName: "PathToGallery13");

            migrationBuilder.RenameColumn(
                name: "FotoPath12",
                table: "Article",
                newName: "PathToGallery12");

            migrationBuilder.RenameColumn(
                name: "FotoPath11",
                table: "Article",
                newName: "PathToGallery11");

            migrationBuilder.RenameColumn(
                name: "FotoPath10",
                table: "Article",
                newName: "PathToGallery10");

            migrationBuilder.RenameColumn(
                name: "FotoPath1",
                table: "Article",
                newName: "PathToGallery1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PathToGallery9",
                table: "Article",
                newName: "FotoPath9");

            migrationBuilder.RenameColumn(
                name: "PathToGallery8",
                table: "Article",
                newName: "FotoPath8");

            migrationBuilder.RenameColumn(
                name: "PathToGallery7",
                table: "Article",
                newName: "FotoPath7");

            migrationBuilder.RenameColumn(
                name: "PathToGallery6",
                table: "Article",
                newName: "FotoPath6");

            migrationBuilder.RenameColumn(
                name: "PathToGallery5",
                table: "Article",
                newName: "FotoPath5");

            migrationBuilder.RenameColumn(
                name: "PathToGallery4",
                table: "Article",
                newName: "FotoPath4");

            migrationBuilder.RenameColumn(
                name: "PathToGallery3",
                table: "Article",
                newName: "FotoPath3");

            migrationBuilder.RenameColumn(
                name: "PathToGallery2",
                table: "Article",
                newName: "FotoPath2");

            migrationBuilder.RenameColumn(
                name: "PathToGallery15",
                table: "Article",
                newName: "FotoPath15");

            migrationBuilder.RenameColumn(
                name: "PathToGallery14",
                table: "Article",
                newName: "FotoPath14");

            migrationBuilder.RenameColumn(
                name: "PathToGallery13",
                table: "Article",
                newName: "FotoPath13");

            migrationBuilder.RenameColumn(
                name: "PathToGallery12",
                table: "Article",
                newName: "FotoPath12");

            migrationBuilder.RenameColumn(
                name: "PathToGallery11",
                table: "Article",
                newName: "FotoPath11");

            migrationBuilder.RenameColumn(
                name: "PathToGallery10",
                table: "Article",
                newName: "FotoPath10");

            migrationBuilder.RenameColumn(
                name: "PathToGallery1",
                table: "Article",
                newName: "FotoPath1");
        }
    }
}
