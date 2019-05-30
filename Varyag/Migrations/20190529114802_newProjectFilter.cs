using Microsoft.EntityFrameworkCore.Migrations;

namespace Varyag.Migrations
{
    public partial class newProjectFilter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Project");

            migrationBuilder.RenameColumn(
                name: "StudyShip",
                table: "Project",
                newName: "Yacht");

            migrationBuilder.RenameColumn(
                name: "ReserchShip",
                table: "Project",
                newName: "Shvertbot");

            migrationBuilder.RenameColumn(
                name: "PassangerShip",
                table: "Project",
                newName: "SailboatStudy");

            migrationBuilder.RenameColumn(
                name: "HistoricalShip",
                table: "Project",
                newName: "SailboatProject");

            migrationBuilder.RenameColumn(
                name: "FishingShip",
                table: "Project",
                newName: "SailboatHistorical");

            migrationBuilder.RenameColumn(
                name: "CruiseShip",
                table: "Project",
                newName: "Motosailer");

            migrationBuilder.AddColumn<bool>(
                name: "BoatRow",
                table: "Project",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "BoatSail",
                table: "Project",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "BoatTraditional",
                table: "Project",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "BoatYal",
                table: "Project",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Botik",
                table: "Project",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "KaterCabin",
                table: "Project",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "KaterFish",
                table: "Project",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "KaterPass",
                table: "Project",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "KaterProject",
                table: "Project",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "KaterRow",
                table: "Project",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LadyaProject",
                table: "Project",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LadyaRow",
                table: "Project",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LadyaSail",
                table: "Project",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MaketCinema",
                table: "Project",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MaketDesign",
                table: "Project",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MaketMuseum",
                table: "Project",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MaketStudy",
                table: "Project",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BoatRow",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "BoatSail",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "BoatTraditional",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "BoatYal",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "Botik",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "KaterCabin",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "KaterFish",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "KaterPass",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "KaterProject",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "KaterRow",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "LadyaProject",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "LadyaRow",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "LadyaSail",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "MaketCinema",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "MaketDesign",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "MaketMuseum",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "MaketStudy",
                table: "Project");

            migrationBuilder.RenameColumn(
                name: "Yacht",
                table: "Project",
                newName: "StudyShip");

            migrationBuilder.RenameColumn(
                name: "Shvertbot",
                table: "Project",
                newName: "ReserchShip");

            migrationBuilder.RenameColumn(
                name: "SailboatStudy",
                table: "Project",
                newName: "PassangerShip");

            migrationBuilder.RenameColumn(
                name: "SailboatProject",
                table: "Project",
                newName: "HistoricalShip");

            migrationBuilder.RenameColumn(
                name: "SailboatHistorical",
                table: "Project",
                newName: "FishingShip");

            migrationBuilder.RenameColumn(
                name: "Motosailer",
                table: "Project",
                newName: "CruiseShip");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Project",
                nullable: false,
                defaultValue: 0);
        }
    }
}
