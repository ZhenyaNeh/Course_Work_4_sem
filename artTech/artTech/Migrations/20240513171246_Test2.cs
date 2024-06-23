using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace artTech.Migrations
{
    /// <inheritdoc />
    public partial class Test2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GPU_Model",
                table: "GPUs",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "CPU_Model",
                table: "CPUs",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "GPUs",
                newName: "GPU_Model");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "CPUs",
                newName: "CPU_Model");
        }
    }
}
