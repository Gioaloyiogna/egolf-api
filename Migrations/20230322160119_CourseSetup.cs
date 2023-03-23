using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GolfWebApi.Migrations
{
    /// <inheritdoc />
    public partial class CourseSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hole = table.Column<int>(type: "int", nullable: false),
                    Par = table.Column<int>(type: "int", nullable: false),
                    Yardage = table.Column<int>(type: "int", nullable: false),
                    Handicap = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
