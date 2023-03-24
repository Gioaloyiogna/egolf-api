using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GolfWebApi.Migrations
{
    /// <inheritdoc />
    public partial class Added_courses_and_holes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Handicap",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Hole",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Par",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "Yardage",
                table: "Courses",
                newName: "NumberOfHoles");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Hole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Par = table.Column<int>(type: "int", nullable: false),
                    Yardage = table.Column<int>(type: "int", nullable: false),
                    Handicap = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hole_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hole_CourseId",
                table: "Hole",
                column: "CourseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hole");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "NumberOfHoles",
                table: "Courses",
                newName: "Yardage");

            migrationBuilder.AddColumn<int>(
                name: "Handicap",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Hole",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Par",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
