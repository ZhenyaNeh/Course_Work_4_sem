using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace artTech.Migrations
{
    /// <inheritdoc />
    public partial class State2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CPU_RecommendedPowerSupply",
                table: "GPUs",
                newName: "GPU_RecommendedPowerSupply");

            migrationBuilder.RenameColumn(
                name: "CPU_MemorySupport",
                table: "GPUs",
                newName: "GPU_MemorySupport");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GPU_RecommendedPowerSupply",
                table: "GPUs",
                newName: "CPU_RecommendedPowerSupply");

            migrationBuilder.RenameColumn(
                name: "GPU_MemorySupport",
                table: "GPUs",
                newName: "CPU_MemorySupport");
        }
    }
}
