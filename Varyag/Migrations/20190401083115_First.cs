using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Varyag.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShipProject",
                columns: table => new
                {
                    ShipProjectID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProjectName = table.Column<string>(nullable: false),
                    ProjectLength = table.Column<int>(nullable: false),
                    ProjectWindth = table.Column<int>(nullable: false),
                    ProjectDeep = table.Column<int>(nullable: false),
                    ProjectVolume = table.Column<int>(nullable: false),
                    ProjectEnginePower = table.Column<int>(nullable: true),
                    ProjectSpeed = table.Column<int>(nullable: true),
                    ProjectSailArea = table.Column<int>(nullable: true),
                    ProjectSleepingAreas = table.Column<int>(nullable: true),
                    ProjectPassengerCap = table.Column<int>(nullable: false),
                    ProjectFuelCap = table.Column<int>(nullable: true),
                    ProjectFreshWaterCap = table.Column<int>(nullable: true),
                    ProjectType = table.Column<int>(nullable: false),
                    ProjectDescription = table.Column<string>(nullable: false),
                    CruiseShip = table.Column<bool>(nullable: false),
                    StudyShip = table.Column<bool>(nullable: false),
                    FishingShip = table.Column<bool>(nullable: false),
                    HistoricalShip = table.Column<bool>(nullable: false),
                    ReserchShip = table.Column<bool>(nullable: false),
                    PassangerShip = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipProject", x => x.ShipProjectID);
                });

            migrationBuilder.CreateTable(
                name: "ProjectFoto",
                columns: table => new
                {
                    ProjectFotoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Foto = table.Column<byte[]>(nullable: true),
                    ShipProjectID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectFoto", x => x.ProjectFotoID);
                    table.ForeignKey(
                        name: "FK_ProjectFoto_ShipProject_ShipProjectID",
                        column: x => x.ShipProjectID,
                        principalTable: "ShipProject",
                        principalColumn: "ShipProjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectFoto_ShipProjectID",
                table: "ProjectFoto",
                column: "ShipProjectID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectFoto");

            migrationBuilder.DropTable(
                name: "ShipProject");
        }
    }
}
