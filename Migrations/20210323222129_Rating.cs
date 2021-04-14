using Microsoft.EntityFrameworkCore.Migrations;

namespace shnYapi5._0.Migrations
{
    public partial class Rating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "homeCards",
                columns: table => new
                {
                    cardID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    baslik = table.Column<string>(type: "TEXT", nullable: true),
                    aciklama = table.Column<string>(type: "TEXT", nullable: true),
                    icerik = table.Column<string>(type: "TEXT", nullable: true),
                    imgYol = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_homeCards", x => x.cardID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "homeCards");
        }
    }
}
