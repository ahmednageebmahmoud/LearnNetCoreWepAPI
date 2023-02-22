using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearnNetCoreWepAPI.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UniqueMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Employees_Age_Name",
                table: "Employees");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Age_Name",
                table: "Employees",
                columns: new[] { "Age", "Name" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Employees_Age_Name",
                table: "Employees");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Age_Name",
                table: "Employees",
                columns: new[] { "Age", "Name" });
        }
    }
}
