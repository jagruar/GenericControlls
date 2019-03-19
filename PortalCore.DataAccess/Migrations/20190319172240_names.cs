using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PortalCore.DataAccess.Migrations
{
    public partial class names : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Properties",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Models",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Conditionals",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Conditionals");

            migrationBuilder.AlterColumn<int>(
                name: "ParameterId",
                table: "Parameters",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
        }
    }
}
