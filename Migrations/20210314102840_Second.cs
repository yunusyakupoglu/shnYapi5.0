using Microsoft.EntityFrameworkCore.Migrations;

namespace shnYapi5._0.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "proje",
                columns: table => new
                {
                    projeID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    projeAdi = table.Column<string>(type: "TEXT", nullable: true),
                    projeBasligi = table.Column<string>(type: "TEXT", nullable: true),
                    imgURL = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proje", x => x.projeID);
                });

            migrationBuilder.CreateTable(
                name: "Kayit",
                columns: table => new
                {
                    kayitID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    projeID = table.Column<int>(type: "INTEGER", nullable: false),
                    adminID = table.Column<int>(type: "INTEGER", nullable: false),
                    Grade = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kayit", x => x.kayitID);
                    table.ForeignKey(
                        name: "FK_Kayit_admin_adminID",
                        column: x => x.adminID,
                        principalTable: "admin",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kayit_proje_projeID",
                        column: x => x.projeID,
                        principalTable: "proje",
                        principalColumn: "projeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kayit_adminID",
                table: "Kayit",
                column: "adminID");

            migrationBuilder.CreateIndex(
                name: "IX_Kayit_projeID",
                table: "Kayit",
                column: "projeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kayit");

            migrationBuilder.DropTable(
                name: "proje");
        }
    }
}
