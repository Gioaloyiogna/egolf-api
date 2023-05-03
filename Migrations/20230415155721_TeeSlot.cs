using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GolfWebApi.Migrations
{
    /// <inheritdoc />
    public partial class TeeSlot : Migration
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
        memberId= table.Column<int>(type: "int", nullable: true),
        memberCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
        playerType = table.Column<string>(type: "nvarchar(max)", nullable: false),
        playerEmail= table.Column<string>(type: "nvarchar(max)", nullable: false),
        teeTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
        playerName= table.Column<string>(type: "nvarchar(max)", nullable: false),
        availabilityStatus= table.Column<string>(type: "nvarchar(max)", nullable: false),
        caddyId = table.Column<int>(type: "int", nullable: false)

    },
    constraints: table =>
    {
        table.PrimaryKey("PK_teeSlots", x => x.Id);
    });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
