using Microsoft.EntityFrameworkCore.Migrations;

namespace Balance.DataService.Migrations
{
    public partial class changetablenamecertificateetocertificates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certificatea_InfoCards_InfoCardId",
                table: "Certificatea");

            migrationBuilder.DropForeignKey(
                name: "FK_PhotoURL_Certificatea_CertificateId",
                table: "PhotoURL");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Certificatea",
                table: "Certificatea");

            migrationBuilder.RenameTable(
                name: "Certificatea",
                newName: "Certificates");

            migrationBuilder.RenameIndex(
                name: "IX_Certificatea_InfoCardId",
                table: "Certificates",
                newName: "IX_Certificates_InfoCardId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Certificates",
                table: "Certificates",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Certificates_InfoCards_InfoCardId",
                table: "Certificates",
                column: "InfoCardId",
                principalTable: "InfoCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PhotoURL_Certificates_CertificateId",
                table: "PhotoURL",
                column: "CertificateId",
                principalTable: "Certificates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certificates_InfoCards_InfoCardId",
                table: "Certificates");

            migrationBuilder.DropForeignKey(
                name: "FK_PhotoURL_Certificates_CertificateId",
                table: "PhotoURL");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Certificates",
                table: "Certificates");

            migrationBuilder.RenameTable(
                name: "Certificates",
                newName: "Certificatea");

            migrationBuilder.RenameIndex(
                name: "IX_Certificates_InfoCardId",
                table: "Certificatea",
                newName: "IX_Certificatea_InfoCardId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Certificatea",
                table: "Certificatea",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Certificatea_InfoCards_InfoCardId",
                table: "Certificatea",
                column: "InfoCardId",
                principalTable: "InfoCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PhotoURL_Certificatea_CertificateId",
                table: "PhotoURL",
                column: "CertificateId",
                principalTable: "Certificatea",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
