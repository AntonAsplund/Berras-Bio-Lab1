using Microsoft.EntityFrameworkCore.Migrations;

namespace Berras_Bio_Lab1.Migrations
{
    public partial class AddedNumberOfTickets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfViewingTickets",
                table: "Tickets",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfViewingTickets",
                table: "Tickets");
        }
    }
}
