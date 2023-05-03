
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GolfWebApi.Migrations
{
    /// <inheritdoc />
    public partial class Tees : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TeeSlots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    memberId = table.Column<int>(type: "int", nullable: true),
                    memberCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    playerType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    playerEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    teeTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    playerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    availabilityStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    caddyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeeSlots", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
