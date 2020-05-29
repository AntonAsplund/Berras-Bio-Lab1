using Microsoft.EntityFrameworkCore.Migrations;

namespace Berras_Bio_Lab1.Migrations
{
    public partial class addedNameAndNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PersonName",
                table: "Tickets",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PhoneNumber",
                table: "Tickets",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PersonName",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Tickets");
        }
    }
}
