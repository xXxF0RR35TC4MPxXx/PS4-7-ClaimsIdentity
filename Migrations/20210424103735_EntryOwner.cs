using Microsoft.EntityFrameworkCore.Migrations;

namespace PS4_7_ClaimsIdentity.Migrations
{
    public partial class EntryOwner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdOwn",
                table: "FizzBuzz",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdOwn",
                table: "FizzBuzz");

        }
    }
}
