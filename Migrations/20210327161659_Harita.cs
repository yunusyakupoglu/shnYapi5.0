using Microsoft.EntityFrameworkCore.Migrations;

namespace shnYapi5._0.Migrations
{
    public partial class Harita : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Haritalar",
                columns: table => new
                {
                    haritaID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Adres = table.Column<string>(type: "TEXT", nullable: true),
                    x = table.Column<string>(type: "TEXT", nullable: true),
                    y = table.Column<string>(type: "TEXT", nullable: true),
                    aciklama = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Haritalar", x => x.haritaID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Haritalar");
        }
    }
}
