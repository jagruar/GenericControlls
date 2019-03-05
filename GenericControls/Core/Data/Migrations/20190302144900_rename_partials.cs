using Microsoft.EntityFrameworkCore.Migrations;

namespace GenericControls.Migrations
{
    public partial class rename_partials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Partial",
                table: "Partial");

            migrationBuilder.RenameTable(
                name: "Partial",
                newName: "Partials");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Partials",
                table: "Partials",
                column: "PartialId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Partials",
                table: "Partials");

            migrationBuilder.RenameTable(
                name: "Partials",
                newName: "Partial");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Partial",
                table: "Partial",
                column: "PartialId");
        }
    }
}
