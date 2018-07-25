using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DevChatter.GameTracker.Data.Ef.Migrations
{
    public partial class CreateGameReviewsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameReviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    GameId = table.Column<Guid>(nullable: true),
                    Rating = table.Column<int>(nullable: false),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameReviews_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameReviews_GameId",
                table: "GameReviews",
                column: "GameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameReviews");
        }
    }
}
