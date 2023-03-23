using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GolfWebApi.Migrations
{
    /// <inheritdoc />
    public partial class AddedTeeslot_Caddy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Caddies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caddies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeeSlots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Teetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Player1Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Player1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Player1Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Player2Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Player2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Player2Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Player3Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Player3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Player3Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Player4Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Player4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Player4Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: true),
                    CaddyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeeSlots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeeSlots_Caddies_CaddyId",
                        column: x => x.CaddyId,
                        principalTable: "Caddies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeeSlots_CaddyId",
                table: "TeeSlots",
                column: "CaddyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeeSlots");

            migrationBuilder.DropTable(
                name: "Caddies");
        }
    }
}
