using Microsoft.EntityFrameworkCore.Migrations;

namespace GenericControls.Migrations
{
    public partial class reservedpages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Url",
                table: "Pages",
                newName: "Name");

            migrationBuilder.AddColumn<int>(
                name: "ReservedPage",
                table: "Pages",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReservedPage",
                table: "Pages");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Pages",
                newName: "Url");
        }
    }
}
