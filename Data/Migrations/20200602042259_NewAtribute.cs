using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class NewAtribute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BeerName",
                table: "Users",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BeerName",
                table: "Users");
        }
    }
}
