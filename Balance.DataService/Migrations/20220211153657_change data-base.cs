using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Balance.DataService.Migrations
{
    public partial class changedatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiplomasURL",
                table: "CoachAchievements");

            migrationBuilder.AddColumn<int>(
                name: "CoachAchievementsId",
                table: "PhotoURL",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PhotoURL_CoachAchievementsId",
                table: "PhotoURL",
                column: "CoachAchievementsId");

            migrationBuilder.AddForeignKey(
                name: "FK_PhotoURL_CoachAchievements_CoachAchievementsId",
                table: "PhotoURL",
                column: "CoachAchievementsId",
                principalTable: "CoachAchievements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhotoURL_CoachAchievements_CoachAchievementsId",
                table: "PhotoURL");

            migrationBuilder.DropIndex(
                name: "IX_PhotoURL_CoachAchievementsId",
                table: "PhotoURL");

            migrationBuilder.DropColumn(
                name: "CoachAchievementsId",
                table: "PhotoURL");

            migrationBuilder.AddColumn<List<string>>(
                name: "DiplomasURL",
                table: "CoachAchievements",
                type: "text[]",
                nullable: true);
        }
    }
}
