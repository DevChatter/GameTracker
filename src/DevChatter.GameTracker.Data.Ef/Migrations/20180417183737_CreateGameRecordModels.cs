using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DevChatter.GameTracker.Data.Ef.Migrations
{
    public partial class CreateGameRecordModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameRecords",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    GameId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameRecords_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlayRecord",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    GameRecordId = table.Column<Guid>(nullable: true),
                    PlayerId = table.Column<Guid>(nullable: true),
                    Taught = table.Column<bool>(nullable: false),
                    Won = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayRecord_GameRecords_GameRecordId",
                        column: x => x.GameRecordId,
                        principalTable: "GameRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlayRecord_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameRecords_GameId",
                table: "GameRecords",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayRecord_GameRecordId",
                table: "PlayRecord",
                column: "GameRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayRecord_PlayerId",
                table: "PlayRecord",
                column: "PlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayRecord");

            migrationBuilder.DropTable(
                name: "GameRecords");
        }
    }
}
