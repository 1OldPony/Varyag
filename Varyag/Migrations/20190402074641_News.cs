using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Varyag.Migrations
{
    public partial class News : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foto_Project_ShipProjectID",
                table: "Foto");

            migrationBuilder.AlterColumn<int>(
                name: "ShipProjectID",
                table: "Foto",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "Alt",
                table: "Foto",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Foto",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NewsID",
                table: "Foto",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    NewsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Header = table.Column<string>(nullable: true),
                    ShortStory = table.Column<string>(nullable: true),
                    MainStory = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.NewsId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Foto_NewsID",
                table: "Foto",
                column: "NewsID");

            migrationBuilder.AddForeignKey(
                name: "FK_Foto_News_NewsID",
                table: "Foto",
                column: "NewsID",
                principalTable: "News",
                principalColumn: "NewsId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Foto_Project_ShipProjectID",
                table: "Foto",
                column: "ShipProjectID",
                principalTable: "Project",
                principalColumn: "ProjectID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foto_News_NewsID",
                table: "Foto");

            migrationBuilder.DropForeignKey(
                name: "FK_Foto_Project_ShipProjectID",
                table: "Foto");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropIndex(
                name: "IX_Foto_NewsID",
                table: "Foto");

            migrationBuilder.DropColumn(
                name: "Alt",
                table: "Foto");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Foto");

            migrationBuilder.DropColumn(
                name: "NewsID",
                table: "Foto");

            migrationBuilder.AlterColumn<int>(
                name: "ShipProjectID",
                table: "Foto",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Foto_Project_ShipProjectID",
                table: "Foto",
                column: "ShipProjectID",
                principalTable: "Project",
                principalColumn: "ProjectID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
