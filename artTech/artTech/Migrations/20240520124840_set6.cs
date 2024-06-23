using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace artTech.Migrations
{
    /// <inheritdoc />
    public partial class set6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamePerson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommentString = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPUId = table.Column<int>(type: "int", nullable: true),
                    ComputerCaseId = table.Column<int>(type: "int", nullable: true),
                    CoolingSystemId = table.Column<int>(type: "int", nullable: true),
                    GPUId = table.Column<int>(type: "int", nullable: true),
                    MotherboardId = table.Column<int>(type: "int", nullable: true),
                    PowerUnitId = table.Column<int>(type: "int", nullable: true),
                    RAMId = table.Column<int>(type: "int", nullable: true),
                    SSDId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_CPUs_CPUId",
                        column: x => x.CPUId,
                        principalTable: "CPUs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_ComputerCases_ComputerCaseId",
                        column: x => x.ComputerCaseId,
                        principalTable: "ComputerCases",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_CoolingSystems_CoolingSystemId",
                        column: x => x.CoolingSystemId,
                        principalTable: "CoolingSystems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_GPUs_GPUId",
                        column: x => x.GPUId,
                        principalTable: "GPUs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_Motherboards_MotherboardId",
                        column: x => x.MotherboardId,
                        principalTable: "Motherboards",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_PowerUnits_PowerUnitId",
                        column: x => x.PowerUnitId,
                        principalTable: "PowerUnits",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_RAMs_RAMId",
                        column: x => x.RAMId,
                        principalTable: "RAMs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_SSDs_SSDId",
                        column: x => x.SSDId,
                        principalTable: "SSDs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ComputerCaseId",
                table: "Comments",
                column: "ComputerCaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CoolingSystemId",
                table: "Comments",
                column: "CoolingSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CPUId",
                table: "Comments",
                column: "CPUId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_GPUId",
                table: "Comments",
                column: "GPUId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_MotherboardId",
                table: "Comments",
                column: "MotherboardId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PowerUnitId",
                table: "Comments",
                column: "PowerUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_RAMId",
                table: "Comments",
                column: "RAMId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_SSDId",
                table: "Comments",
                column: "SSDId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");
        }
    }
}
