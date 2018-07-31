using Microsoft.EntityFrameworkCore.Migrations;

namespace DevChatter.GameTracker.Data.Ef.Migrations
{
    public partial class AddingUserForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "GameReviews",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GameReviews_UserId",
                table: "GameReviews",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameReviews_AspNetUsers_UserId",
                table: "GameReviews",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameReviews_AspNetUsers_UserId",
                table: "GameReviews");

            migrationBuilder.DropIndex(
                name: "IX_GameReviews_UserId",
                table: "GameReviews");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "GameReviews");
        }
    }
}
