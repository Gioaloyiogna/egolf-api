using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GolfWebApi.Migrations
{
    /// <inheritdoc />
    public partial class HolesMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "Holetbls",
               columns: table => new
               {
                   Id = table.Column<int>(type: "int", nullable: false)
                       .Annotation("SqlServer:Identity", "1, 1"),
                   HoleNumber = table.Column<int>(type: "int", nullable: true),
                   Par = table.Column<int>(type: "int", nullable: true),
                   Yardage = table.Column<int>(type: "int", nullable: true),
                   Handicap = table.Column<int>(type: "int", nullable: true),
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Holesid", x => x.Id);
               });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
