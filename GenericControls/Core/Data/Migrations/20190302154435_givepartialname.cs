using Microsoft.EntityFrameworkCore.Migrations;

namespace GenericControls.Migrations
{
    public partial class givepartialname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Partials",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Partials");
        }
    }
}
