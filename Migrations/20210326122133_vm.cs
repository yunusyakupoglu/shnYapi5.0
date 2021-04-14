using Microsoft.EntityFrameworkCore.Migrations;

namespace shnYapi5._0.Migrations
{
    public partial class vm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "misyonumuz",
                columns: table => new
                {
                    misyonID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    title = table.Column<string>(type: "TEXT", nullable: true),
                    content = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_misyonumuz", x => x.misyonID);
                });

            migrationBuilder.CreateTable(
                name: "vizyon",
                columns: table => new
                {
                    vizyonID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    title = table.Column<string>(type: "TEXT", nullable: true),
                    arz = table.Column<string>(type: "TEXT", nullable: true),
                    talep = table.Column<string>(type: "TEXT", nullable: true),
                    content = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vizyon", x => x.vizyonID);
                });

            migrationBuilder.CreateTable(
                name: "vizyonList",
                columns: table => new
                {
                    vizyonListID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    content = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vizyonList", x => x.vizyonListID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "misyonumuz");

            migrationBuilder.DropTable(
                name: "vizyon");

            migrationBuilder.DropTable(
                name: "vizyonList");
        }
    }
}
