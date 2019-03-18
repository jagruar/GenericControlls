using Microsoft.EntityFrameworkCore.Migrations;

namespace PortalCore.DataAccess.Migrations
{
    public partial class models4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Models_Models_ModelId1",
                table: "Models");

            migrationBuilder.DropIndex(
                name: "IX_Models_ModelId1",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "ModelId1",
                table: "Models");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ModelId1",
                table: "Models",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Models_ModelId1",
                table: "Models",
                column: "ModelId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Models_Models_ModelId1",
                table: "Models",
                column: "ModelId1",
                principalTable: "Models",
                principalColumn: "ModelId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
