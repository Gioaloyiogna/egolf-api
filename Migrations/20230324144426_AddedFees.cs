using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GolfWebApi.Migrations
{
    /// <inheritdoc />
    public partial class AddedFees : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hole_Courses_CourseId",
                table: "Hole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hole",
                table: "Hole");

            migrationBuilder.RenameTable(
                name: "Hole",
                newName: "Holes");

            migrationBuilder.RenameIndex(
                name: "IX_Hole_CourseId",
                table: "Holes",
                newName: "IX_Holes_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Holes",
                table: "Holes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Fees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Frequency = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fees", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Holes_Courses_CourseId",
                table: "Holes",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Holes_Courses_CourseId",
                table: "Holes");

            migrationBuilder.DropTable(
                name: "Fees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Holes",
                table: "Holes");

            migrationBuilder.RenameTable(
                name: "Holes",
                newName: "Hole");

            migrationBuilder.RenameIndex(
                name: "IX_Holes_CourseId",
                table: "Hole",
                newName: "IX_Hole_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hole",
                table: "Hole",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Hole_Courses_CourseId",
                table: "Hole",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
