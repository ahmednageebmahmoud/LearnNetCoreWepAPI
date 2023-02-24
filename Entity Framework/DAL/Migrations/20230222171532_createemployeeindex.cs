using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearnNetCoreWepAPI.DAL.Migrations
{
    /// <inheritdoc />
    public partial class createemployeeindex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PostMedia",
                table: "PostMedia");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "PostMedia",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostMedia",
                table: "PostMedia",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "MediaPost",
                columns: table => new
                {
                    MediasId = table.Column<int>(type: "int", nullable: false),
                    PostsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaPost", x => new { x.MediasId, x.PostsId });
                    table.ForeignKey(
                        name: "FK_MediaPost_Media_MediasId",
                        column: x => x.MediasId,
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MediaPost_Post_PostsId",
                        column: x => x.PostsId,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostMedia_MediaId",
                table: "PostMedia",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Age",
                table: "Employees",
                column: "Age");

            migrationBuilder.CreateIndex(
                name: "IX_MediaPost_PostsId",
                table: "MediaPost",
                column: "PostsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MediaPost");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostMedia",
                table: "PostMedia");

            migrationBuilder.DropIndex(
                name: "IX_PostMedia_MediaId",
                table: "PostMedia");

            migrationBuilder.DropIndex(
                name: "IX_Employees_Age",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PostMedia");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostMedia",
                table: "PostMedia",
                columns: new[] { "MediaId", "PostId" });
        }
    }
}
