using Microsoft.EntityFrameworkCore.Migrations;

namespace Berras_Bio_Lab1.Migrations
{
    public partial class UpdateIsShowingTicketRange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsShowing",
                table: "Viewings",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsShowing",
                table: "Viewings");
        }
    }
}
