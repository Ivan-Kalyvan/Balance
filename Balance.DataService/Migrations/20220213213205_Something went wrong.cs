using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Balance.DataService.Migrations
{
    public partial class Somethingwentwrong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facts_InfoCards_InfoCardId",
                table: "Facts");

            migrationBuilder.DropForeignKey(
                name: "FK_PhotoURL_CoachAchievements_CoachAchievementsId",
                table: "PhotoURL");

            migrationBuilder.DropTable(
                name: "CoachAchievements");

            migrationBuilder.DropIndex(
                name: "IX_PhotoURL_CoachAchievementsId",
                table: "PhotoURL");

            migrationBuilder.RenameColumn(
                name: "CoachAchievementsId",
                table: "PhotoURL",
                newName: "CertificateId");

            migrationBuilder.AlterColumn<int>(
                name: "InfoCardId",
                table: "Facts",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Certificatea",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: true),
                    InfoCardId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificatea", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Certificatea_InfoCards_InfoCardId",
                        column: x => x.InfoCardId,
                        principalTable: "InfoCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhotoURL_CertificateId",
                table: "PhotoURL",
                column: "CertificateId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Certificatea_InfoCardId",
                table: "Certificatea",
                column: "InfoCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Facts_InfoCards_InfoCardId",
                table: "Facts",
                column: "InfoCardId",
                principalTable: "InfoCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhotoURL_Certificatea_CertificateId",
                table: "PhotoURL",
                column: "CertificateId",
                principalTable: "Certificatea",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facts_InfoCards_InfoCardId",
                table: "Facts");

            migrationBuilder.DropForeignKey(
                name: "FK_PhotoURL_Certificatea_CertificateId",
                table: "PhotoURL");

            migrationBuilder.DropTable(
                name: "Certificatea");

            migrationBuilder.DropIndex(
                name: "IX_PhotoURL_CertificateId",
                table: "PhotoURL");

            migrationBuilder.RenameColumn(
                name: "CertificateId",
                table: "PhotoURL",
                newName: "CoachAchievementsId");

            migrationBuilder.AlterColumn<int>(
                name: "InfoCardId",
                table: "Facts",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateTable(
                name: "CoachAchievements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: true),
                    InfoCardId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoachAchievements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoachAchievements_InfoCards_InfoCardId",
                        column: x => x.InfoCardId,
                        principalTable: "InfoCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhotoURL_CoachAchievementsId",
                table: "PhotoURL",
                column: "CoachAchievementsId");

            migrationBuilder.CreateIndex(
                name: "IX_CoachAchievements_InfoCardId",
                table: "CoachAchievements",
                column: "InfoCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Facts_InfoCards_InfoCardId",
                table: "Facts",
                column: "InfoCardId",
                principalTable: "InfoCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PhotoURL_CoachAchievements_CoachAchievementsId",
                table: "PhotoURL",
                column: "CoachAchievementsId",
                principalTable: "CoachAchievements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
