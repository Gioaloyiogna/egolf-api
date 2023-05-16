using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GolfWebApi.Migrations
{
    /// <inheritdoc />
    public partial class caddyTee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "CaddyTees",
               columns: table => new
               {
                   Id = table.Column<int>(type: "int", nullable: false)
                       .Annotation("SqlServer:Identity", "1, 1"),
                   caddyId = table.Column<int>(type: "int", nullable: false),
                   Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   teeTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                   caddyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                   caddyEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                   caddyPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                   caddyGender = table.Column<string>(type: "nvarchar(max)", nullable: true)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_CaddyTees", x => x.Id);
               });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
