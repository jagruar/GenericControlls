using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PortalCore.DataAccess.Migrations
{
    public partial class models2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Properties",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Namespace",
                table: "Models",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Design",
                columns: table => new
                {
                    DesignId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PageId = table.Column<int>(nullable: false),
                    Order = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Design", x => x.DesignId);
                    table.ForeignKey(
                        name: "FK_Design_Pages_PageId",
                        column: x => x.PageId,
                        principalTable: "Pages",
                        principalColumn: "PageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Views_PageId",
                table: "Views",
                column: "PageId");

            migrationBuilder.CreateIndex(
                name: "IX_Design_PageId",
                table: "Design",
                column: "PageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Views_Pages_PageId",
                table: "Views",
                column: "PageId",
                principalTable: "Pages",
                principalColumn: "PageId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Views_Pages_PageId",
                table: "Views");

            migrationBuilder.DropTable(
                name: "Design");

            migrationBuilder.DropIndex(
                name: "IX_Views_PageId",
                table: "Views");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "Namespace",
                table: "Models");
        }
    }
}
