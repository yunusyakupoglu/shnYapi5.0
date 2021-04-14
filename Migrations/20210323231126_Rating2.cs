using Microsoft.EntityFrameworkCore.Migrations;

namespace shnYapi5._0.Migrations
{
    public partial class Rating2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "imgName",
                table: "homeCards",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imgName",
                table: "homeCards");
        }
    }
}
