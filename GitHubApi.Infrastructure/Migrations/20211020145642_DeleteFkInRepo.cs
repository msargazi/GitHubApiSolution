using Microsoft.EntityFrameworkCore.Migrations;

namespace GitHubApi.Infrastructure.Migrations
{
    public partial class DeleteFkInRepo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Repos_Users_UserId",
                table: "Repos");

            migrationBuilder.DropIndex(
                name: "IX_Repos_UserId",
                table: "Repos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Repos_UserId",
                table: "Repos",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Repos_Users_UserId",
                table: "Repos",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
