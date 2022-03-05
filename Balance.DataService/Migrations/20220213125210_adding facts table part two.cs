using Microsoft.EntityFrameworkCore.Migrations;

namespace Balance.DataService.Migrations
{
    public partial class addingfactstableparttwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropForeignKey(
                name: "FK_Facts_Cards_InfoCardId",
                table: "Facts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cards",
                table: "Cards");

            migrationBuilder.RenameTable(
                name: "Cards",
                newName: "InfoCards");

            migrationBuilder.RenameColumn(
                name: "Fact",
                table: "Facts",
                newName: "FactDesc");

            migrationBuilder.RenameIndex(
                name: "IX_Cards_WorkoutId",
                table: "InfoCards",
                newName: "IX_InfoCards_WorkoutId");

            migrationBuilder.RenameIndex(
                name: "IX_Cards_PhotoId",
                table: "InfoCards",
                newName: "IX_InfoCards_PhotoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InfoCards",
                table: "InfoCards",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CoachAchievements_InfoCards_InfoCardId",
                table: "CoachAchievements",
                column: "InfoCardId",
                principalTable: "InfoCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Facts_InfoCards_InfoCardId",
                table: "Facts",
                column: "InfoCardId",
                principalTable: "InfoCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InfoCards_PhotoURL_PhotoId",
                table: "InfoCards",
                column: "PhotoId",
                principalTable: "PhotoURL",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InfoCards_Workouts_WorkoutId",
                table: "InfoCards",
                column: "WorkoutId",
                principalTable: "Workouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoachAchievements_InfoCards_InfoCardId",
                table: "CoachAchievements");

            migrationBuilder.DropForeignKey(
                name: "FK_Facts_InfoCards_InfoCardId",
                table: "Facts");

            migrationBuilder.DropForeignKey(
                name: "FK_InfoCards_PhotoURL_PhotoId",
                table: "InfoCards");

            migrationBuilder.DropForeignKey(
                name: "FK_InfoCards_Workouts_WorkoutId",
                table: "InfoCards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InfoCards",
                table: "InfoCards");

            migrationBuilder.RenameTable(
                name: "InfoCards",
                newName: "Cards");

            migrationBuilder.RenameColumn(
                name: "FactDesc",
                table: "Facts",
                newName: "Fact");

            migrationBuilder.RenameIndex(
                name: "IX_InfoCards_WorkoutId",
                table: "Cards",
                newName: "IX_Cards_WorkoutId");

            migrationBuilder.RenameIndex(
                name: "IX_InfoCards_PhotoId",
                table: "Cards",
                newName: "IX_Cards_PhotoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cards",
                table: "Cards",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_PhotoURL_PhotoId",
                table: "Cards",
                column: "PhotoId",
                principalTable: "PhotoURL",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Facts_Cards_InfoCardId",
                table: "Facts",
                column: "InfoCardId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
