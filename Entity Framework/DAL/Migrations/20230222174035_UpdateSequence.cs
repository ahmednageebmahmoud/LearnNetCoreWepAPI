using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearnNetCoreWepAPI.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSequence : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterSequence(
                name: "RegisterNo",
                incrementBy: 9);

            migrationBuilder.RestartSequence(
                name: "RegisterNo",
                startValue: 5L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterSequence(
                name: "RegisterNo",
                oldIncrementBy: 9);

            migrationBuilder.RestartSequence(
                name: "RegisterNo",
                startValue: 1L);
        }
    }
}
