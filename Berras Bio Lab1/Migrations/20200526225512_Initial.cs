using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Berras_Bio_Lab1.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MovieModelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    RunTime = table.Column<int>(nullable: false),
                    Category = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieModelId);
                });

            migrationBuilder.CreateTable(
                name: "Theaters",
                columns: table => new
                {
                    TheaterModelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    TotalSeats = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Theaters", x => x.TheaterModelId);
                });

            migrationBuilder.CreateTable(
                name: "Viewings",
                columns: table => new
                {
                    ViewingModelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(nullable: false),
                    AvaibleSeats = table.Column<int>(nullable: false),
                    TotalSeats = table.Column<int>(nullable: false),
                    TheaterModelId = table.Column<int>(nullable: true),
                    MovieModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Viewings", x => x.ViewingModelId);
                    table.ForeignKey(
                        name: "FK_Viewings_Movies_MovieModelId",
                        column: x => x.MovieModelId,
                        principalTable: "Movies",
                        principalColumn: "MovieModelId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Viewings_Theaters_TheaterModelId",
                        column: x => x.TheaterModelId,
                        principalTable: "Theaters",
                        principalColumn: "TheaterModelId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketModelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDateTime = table.Column<DateTime>(nullable: false),
                    ViewingModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketModelId);
                    table.ForeignKey(
                        name: "FK_Tickets_Viewings_ViewingModelId",
                        column: x => x.ViewingModelId,
                        principalTable: "Viewings",
                        principalColumn: "ViewingModelId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ViewingModelId",
                table: "Tickets",
                column: "ViewingModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Viewings_MovieModelId",
                table: "Viewings",
                column: "MovieModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Viewings_TheaterModelId",
                table: "Viewings",
                column: "TheaterModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Viewings");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Theaters");
        }
    }
}
