using Microsoft.EntityFrameworkCore.Migrations;

namespace Berras_Bio_Lab1.Migrations
{
    public partial class phonenumbertostring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Tickets",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PhoneNumber",
                table: "Tickets",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
