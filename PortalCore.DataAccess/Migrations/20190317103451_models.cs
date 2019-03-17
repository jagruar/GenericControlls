using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PortalCore.DataAccess.Migrations
{
    public partial class models : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    ModelId = table.Column<int>(nullable: false),
                    DisplayName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.ModelId);
                });

            migrationBuilder.CreateTable(
                name: "Conditionals",
                columns: table => new
                {
                    ConditionalId = table.Column<int>(nullable: false),
                    DisplayName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ModelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conditionals", x => x.ConditionalId);
                    table.ForeignKey(
                        name: "FK_Conditionals_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "ModelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Endpoints",
                columns: table => new
                {
                    EndpointId = table.Column<int>(nullable: false),
                    Method = table.Column<string>(nullable: true),
                    IsList = table.Column<bool>(nullable: false),
                    DisplayName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ModelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endpoints", x => x.EndpointId);
                    table.ForeignKey(
                        name: "FK_Endpoints_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "ModelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    PropertyId = table.Column<int>(nullable: false),
                    DisplayName = table.Column<string>(nullable: true),
                    IsList = table.Column<bool>(nullable: false),
                    ModelId = table.Column<int>(nullable: false),
                    ChildModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.PropertyId);
                    table.ForeignKey(
                        name: "FK_Properties_Models_ChildModelId",
                        column: x => x.ChildModelId,
                        principalTable: "Models",
                        principalColumn: "ModelId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Properties_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "ModelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Parameters",
                columns: table => new
                {
                    ParameterId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DisplayName = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    EndpointId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parameters", x => x.ParameterId);
                    table.ForeignKey(
                        name: "FK_Parameters_Endpoints_EndpointId",
                        column: x => x.EndpointId,
                        principalTable: "Endpoints",
                        principalColumn: "EndpointId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Conditionals_ModelId",
                table: "Conditionals",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Endpoints_ModelId",
                table: "Endpoints",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Parameters_EndpointId",
                table: "Parameters",
                column: "EndpointId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_ChildModelId",
                table: "Properties",
                column: "ChildModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_ModelId",
                table: "Properties",
                column: "ModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Conditionals");

            migrationBuilder.DropTable(
                name: "Parameters");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "Endpoints");

            migrationBuilder.DropTable(
                name: "Models");
        }
    }
}
