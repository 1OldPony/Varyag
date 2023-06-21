using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Varyag.Migrations
{
    public partial class articles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Article",
                columns: table => new
                {
                    ArticleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArticleName = table.Column<string>(nullable: true),
                    Text1 = table.Column<string>(nullable: true),
                    FotoPath1 = table.Column<string>(nullable: true),
                    Text2 = table.Column<string>(nullable: true),
                    FotoPath2 = table.Column<string>(nullable: true),
                    Text3 = table.Column<string>(nullable: true),
                    FotoPath3 = table.Column<string>(nullable: true),
                    Text4 = table.Column<string>(nullable: true),
                    FotoPath4 = table.Column<string>(nullable: true),
                    Text5 = table.Column<string>(nullable: true),
                    FotoPath5 = table.Column<string>(nullable: true),
                    Text6 = table.Column<string>(nullable: true),
                    FotoPath6 = table.Column<string>(nullable: true),
                    Text7 = table.Column<string>(nullable: true),
                    FotoPath7 = table.Column<string>(nullable: true),
                    Text8 = table.Column<string>(nullable: true),
                    FotoPath8 = table.Column<string>(nullable: true),
                    Text9 = table.Column<string>(nullable: true),
                    FotoPath9 = table.Column<string>(nullable: true),
                    Text10 = table.Column<string>(nullable: true),
                    FotoPath10 = table.Column<string>(nullable: true),
                    Text11 = table.Column<string>(nullable: true),
                    FotoPath11 = table.Column<string>(nullable: true),
                    Text12 = table.Column<string>(nullable: true),
                    FotoPath12 = table.Column<string>(nullable: true),
                    Text13 = table.Column<string>(nullable: true),
                    FotoPath13 = table.Column<string>(nullable: true),
                    Text14 = table.Column<string>(nullable: true),
                    FotoPath14 = table.Column<string>(nullable: true),
                    Text15 = table.Column<string>(nullable: true),
                    FotoPath15 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.ArticleId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Article");
        }
    }
}
