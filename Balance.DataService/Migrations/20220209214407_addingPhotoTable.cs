using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Balance.DataService.Migrations
{
    public partial class addingPhotoTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoachAchievements_Cards_CardId",
                table: "CoachAchievements");

            migrationBuilder.DropColumn(
                name: "PhotoURL",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "PhotoURL",
                table: "Sliders");

            migrationBuilder.RenameColumn(
                name: "CardId",
                table: "CoachAchievements",
                newName: "InfoCardId");

            migrationBuilder.RenameIndex(
                name: "IX_CoachAchievements_CardId",
                table: "CoachAchievements",
                newName: "IX_CoachAchievements_InfoCardId");

            migrationBuilder.AddColumn<int>(
                name: "PhotoId",
                table: "Workouts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PhotoId",
                table: "Cards",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WorkoutId",
                table: "Cards",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PhotoURL",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    URLPhoto = table.Column<string>(type: "text", nullable: true),
                    SliderId = table.Column<int>(type: "integer", nullable: false),
                    WorkoutId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotoURL", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhotoURL_Sliders_SliderId",
                        column: x => x.SliderId,
                        principalTable: "Sliders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhotoURL_Workouts_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "Workouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cards_PhotoId",
                table: "Cards",
                column: "PhotoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cards_WorkoutId",
                table: "Cards",
                column: "WorkoutId");

            migrationBuilder.CreateIndex(
                name: "IX_PhotoURL_SliderId",
                table: "PhotoURL",
                column: "SliderId");

            migrationBuilder.CreateIndex(
                name: "IX_PhotoURL_WorkoutId",
                table: "PhotoURL",
                column: "WorkoutId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_PhotoURL_PhotoId",
                table: "Cards",
                column: "PhotoId",
                principalTable: "PhotoURL",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Workouts_WorkoutId",
                table: "Cards",
                column: "WorkoutId",
                principalTable: "Workouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CoachAchievements_Cards_InfoCardId",
                table: "CoachAchievements",
                column: "InfoCardId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_PhotoURL_PhotoId",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Workouts_WorkoutId",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_CoachAchievements_Cards_InfoCardId",
                table: "CoachAchievements");

            migrationBuilder.DropTable(
                name: "PhotoURL");

            migrationBuilder.DropIndex(
                name: "IX_Cards_PhotoId",
                table: "Cards");

            migrationBuilder.DropIndex(
                name: "IX_Cards_WorkoutId",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "PhotoId",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "PhotoId",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "WorkoutId",
                table: "Cards");

            migrationBuilder.RenameColumn(
                name: "InfoCardId",
                table: "CoachAchievements",
                newName: "CardId");

            migrationBuilder.RenameIndex(
                name: "IX_CoachAchievements_InfoCardId",
                table: "CoachAchievements",
                newName: "IX_CoachAchievements_CardId");

            migrationBuilder.AddColumn<List<string>>(
                name: "PhotoURL",
                table: "Workouts",
                type: "text[]",
                nullable: true);

            migrationBuilder.AddColumn<List<string>>(
                name: "PhotoURL",
                table: "Sliders",
                type: "text[]",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CoachAchievements_Cards_CardId",
                table: "CoachAchievements",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
