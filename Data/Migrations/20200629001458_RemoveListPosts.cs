using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class RemoveListPosts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_ProfileEntityId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_ProfileEntityId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "ProfileEntityId",
                table: "Posts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfileEntityId",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ProfileEntityId",
                table: "Posts",
                column: "ProfileEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_ProfileEntityId",
                table: "Posts",
                column: "ProfileEntityId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
