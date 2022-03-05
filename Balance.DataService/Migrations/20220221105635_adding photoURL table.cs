using Microsoft.EntityFrameworkCore.Migrations;

namespace Balance.DataService.Migrations
{
    public partial class addingphotoURLtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InfoCards_PhotoURL_PhotoId",
                table: "InfoCards");

            migrationBuilder.DropForeignKey(
                name: "FK_PhotoURL_Certificates_CertificateId",
                table: "PhotoURL");

            migrationBuilder.DropForeignKey(
                name: "FK_PhotoURL_Sliders_SliderId",
                table: "PhotoURL");

            migrationBuilder.DropForeignKey(
                name: "FK_PhotoURL_Workouts_WorkoutId",
                table: "PhotoURL");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PhotoURL",
                table: "PhotoURL");

            migrationBuilder.RenameTable(
                name: "PhotoURL",
                newName: "PhotosURL");

            migrationBuilder.RenameIndex(
                name: "IX_PhotoURL_WorkoutId",
                table: "PhotosURL",
                newName: "IX_PhotosURL_WorkoutId");

            migrationBuilder.RenameIndex(
                name: "IX_PhotoURL_SliderId",
                table: "PhotosURL",
                newName: "IX_PhotosURL_SliderId");

            migrationBuilder.RenameIndex(
                name: "IX_PhotoURL_CertificateId",
                table: "PhotosURL",
                newName: "IX_PhotosURL_CertificateId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhotosURL",
                table: "PhotosURL",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InfoCards_PhotosURL_PhotoId",
                table: "InfoCards",
                column: "PhotoId",
                principalTable: "PhotosURL",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PhotosURL_Certificates_CertificateId",
                table: "PhotosURL",
                column: "CertificateId",
                principalTable: "Certificates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PhotosURL_Sliders_SliderId",
                table: "PhotosURL",
                column: "SliderId",
                principalTable: "Sliders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PhotosURL_Workouts_WorkoutId",
                table: "PhotosURL",
                column: "WorkoutId",
                principalTable: "Workouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InfoCards_PhotosURL_PhotoId",
                table: "InfoCards");

            migrationBuilder.DropForeignKey(
                name: "FK_PhotosURL_Certificates_CertificateId",
                table: "PhotosURL");

            migrationBuilder.DropForeignKey(
                name: "FK_PhotosURL_Sliders_SliderId",
                table: "PhotosURL");

            migrationBuilder.DropForeignKey(
                name: "FK_PhotosURL_Workouts_WorkoutId",
                table: "PhotosURL");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PhotosURL",
                table: "PhotosURL");

            migrationBuilder.RenameTable(
                name: "PhotosURL",
                newName: "PhotoURL");

            migrationBuilder.RenameIndex(
                name: "IX_PhotosURL_WorkoutId",
                table: "PhotoURL",
                newName: "IX_PhotoURL_WorkoutId");

            migrationBuilder.RenameIndex(
                name: "IX_PhotosURL_SliderId",
                table: "PhotoURL",
                newName: "IX_PhotoURL_SliderId");

            migrationBuilder.RenameIndex(
                name: "IX_PhotosURL_CertificateId",
                table: "PhotoURL",
                newName: "IX_PhotoURL_CertificateId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhotoURL",
                table: "PhotoURL",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InfoCards_PhotoURL_PhotoId",
                table: "InfoCards",
                column: "PhotoId",
                principalTable: "PhotoURL",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PhotoURL_Certificates_CertificateId",
                table: "PhotoURL",
                column: "CertificateId",
                principalTable: "Certificates",
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
    }
}
