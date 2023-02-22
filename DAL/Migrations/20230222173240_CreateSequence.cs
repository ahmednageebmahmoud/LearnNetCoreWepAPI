using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearnNetCoreWepAPI.DAL.Migrations
{
    /// <inheritdoc />
    public partial class CreateSequence : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "RegisterNo");

            migrationBuilder.AddColumn<int>(
                name: "UserRegisterNO",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR RegisterNo");

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserRegisterNO = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR RegisterNo")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropColumn(
                name: "UserRegisterNO",
                table: "Employees");

            migrationBuilder.DropSequence(
                name: "RegisterNo");
        }
    }
}
