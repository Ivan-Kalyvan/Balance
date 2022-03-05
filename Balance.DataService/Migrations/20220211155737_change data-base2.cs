using Microsoft.EntityFrameworkCore.Migrations;

namespace Balance.DataService.Migrations
{
    public partial class changedatabase2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_PhotoURL_PhotoId",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_PhotoURL_CoachAchievements_CoachAchievementsId",
                table: "PhotoURL");

            migrationBuilder.DropForeignKey(
                name: "FK_PhotoURL_Sliders_SliderId",
                table: "PhotoURL");

            migrationBuilder.DropForeignKey(
                name: "FK_PhotoURL_Workouts_WorkoutId",
                table: "PhotoURL");

            migrationBuilder.AlterColumn<int>(
                name: "PhotoId",
                table: "Workouts",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "WorkoutId",
                table: "PhotoURL",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "SliderId",
                table: "PhotoURL",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "CoachAchievementsId",
                table: "PhotoURL",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "PhotoId",
                table: "Cards",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_PhotoURL_PhotoId",
                table: "Cards",
                column: "PhotoId",
                principalTable: "PhotoURL",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PhotoURL_CoachAchievements_CoachAchievementsId",
                table: "PhotoURL",
                column: "CoachAchievementsId",
                principalTable: "CoachAchievements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PhotoURL_Sliders_SliderId",
                table: "PhotoURL",
                column: "SliderId",
                principalTable: "Sliders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PhotoURL_Workouts_WorkoutId",
                table: "PhotoURL",
                column: "WorkoutId",
                principalTable: "Workouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_PhotoURL_PhotoId",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_PhotoURL_CoachAchievements_CoachAchievementsId",
                table: "PhotoURL");

            migrationBuilder.DropForeignKey(
                name: "FK_PhotoURL_Sliders_SliderId",
                table: "PhotoURL");

            migrationBuilder.DropForeignKey(
                name: "FK_PhotoURL_Workouts_WorkoutId",
                table: "PhotoURL");

            migrationBuilder.AlterColumn<int>(
                name: "PhotoId",
                table: "Workouts",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "WorkoutId",
                table: "PhotoURL",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SliderId",
                table: "PhotoURL",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CoachAchievementsId",
                table: "PhotoURL",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PhotoId",
                table: "Cards",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_PhotoURL_PhotoId",
                table: "Cards",
                column: "PhotoId",
                principalTable: "PhotoURL",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhotoURL_CoachAchievements_CoachAchievementsId",
                table: "PhotoURL",
                column: "CoachAchievementsId",
                principalTable: "CoachAchievements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhotoURL_Sliders_SliderId",
                table: "PhotoURL",
                column: "SliderId",
                principalTable: "Sliders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhotoURL_Workouts_WorkoutId",
                table: "PhotoURL",
                column: "WorkoutId",
                principalTable: "Workouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
