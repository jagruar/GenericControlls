using Microsoft.EntityFrameworkCore.Migrations;

namespace GenericControls.Migrations
{
    public partial class Masters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MasterPageId",
                table: "Pages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PageType",
                table: "Pages",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MasterPageId",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "PageType",
                table: "Pages");
        }
    }
}
