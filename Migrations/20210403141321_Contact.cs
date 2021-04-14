using Microsoft.EntityFrameworkCore.Migrations;

namespace shnYapi5._0.Migrations
{
    public partial class Contact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "adress",
                columns: table => new
                {
                    adresID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    mahalle = table.Column<string>(type: "TEXT", nullable: true),
                    sokak = table.Column<string>(type: "TEXT", nullable: true),
                    isYeri = table.Column<string>(type: "TEXT", nullable: true),
                    No = table.Column<string>(type: "TEXT", nullable: true),
                    ilce = table.Column<string>(type: "TEXT", nullable: true),
                    sehir = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adress", x => x.adresID);
                });

            migrationBuilder.CreateTable(
                name: "eMail",
                columns: table => new
                {
                    emailID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    email = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eMail", x => x.emailID);
                });

            migrationBuilder.CreateTable(
                name: "maps",
                columns: table => new
                {
                    mapID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    stringURL = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_maps", x => x.mapID);
                });

            migrationBuilder.CreateTable(
                name: "phone",
                columns: table => new
                {
                    phoneID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    phoneNumber = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phone", x => x.phoneID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "adress");

            migrationBuilder.DropTable(
                name: "eMail");

            migrationBuilder.DropTable(
                name: "maps");

            migrationBuilder.DropTable(
                name: "phone");
        }
    }
}
