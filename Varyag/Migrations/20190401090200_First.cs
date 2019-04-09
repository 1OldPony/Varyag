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
                name: "Project",
                columns: table => new
                {
                    ProjectID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Length = table.Column<int>(nullable: false),
                    Windth = table.Column<int>(nullable: false),
                    Deep = table.Column<int>(nullable: false),
                    Volume = table.Column<int>(nullable: false),
                    EnginePower = table.Column<int>(nullable: true),
                    Speed = table.Column<int>(nullable: true),
                    SailArea = table.Column<int>(nullable: true),
                    SleepingAreas = table.Column<int>(nullable: true),
                    PassengerCap = table.Column<int>(nullable: false),
                    FuelCap = table.Column<int>(nullable: true),
                    FreshWaterCap = table.Column<int>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    CruiseShip = table.Column<bool>(nullable: false),
                    StudyShip = table.Column<bool>(nullable: false),
                    FishingShip = table.Column<bool>(nullable: false),
                    HistoricalShip = table.Column<bool>(nullable: false),
                    ReserchShip = table.Column<bool>(nullable: false),
                    PassangerShip = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.ProjectID);
                });

            migrationBuilder.CreateTable(
                name: "Foto",
                columns: table => new
                {
                    FotoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProjectFoto = table.Column<byte[]>(nullable: true),
                    ShipProjectID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foto", x => x.FotoID);
                    table.ForeignKey(
                        name: "FK_Foto_Project_ShipProjectID",
                        column: x => x.ShipProjectID,
                        principalTable: "Project",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Foto_ShipProjectID",
                table: "Foto",
                column: "ShipProjectID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Foto");

            migrationBuilder.DropTable(
                name: "Project");
        }
    }
}
