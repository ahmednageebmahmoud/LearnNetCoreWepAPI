using LearnNetCoreWepAPI.DAL.Helpers;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearnNetCoreWepAPI.DAL.Migrations
{
    /// <inheritdoc />
    public partial class SeedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
                values: new[] {Guid.NewGuid().ToString(),"User", RoleConsts.UserRole,Guid.NewGuid().ToString() }
                );

            migrationBuilder.InsertData(
    table: "AspNetRoles",
    columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
    values: new[] { Guid.NewGuid().ToString(), "Admin", RoleConsts.AdminRole, Guid.NewGuid().ToString() }
    );

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE AspNetRoles");
        }
    }
}
