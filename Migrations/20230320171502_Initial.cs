using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GolfWebApi.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlayerHandicap = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ggaid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameSchedules",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    GameTypeId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameSchedules_GameTypes_GameTypeId",
                        column: x => x.GameTypeId,
                        principalTable: "GameTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameSchedules_GameTypeId",
                table: "GameSchedules",
                column: "GameTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameSchedules");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "GameTypes");
        }
    }
}
