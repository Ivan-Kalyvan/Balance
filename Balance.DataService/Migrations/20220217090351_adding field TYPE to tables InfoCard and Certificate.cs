using Microsoft.EntityFrameworkCore.Migrations;

namespace Balance.DataService.Migrations
{
    public partial class addingfieldTYPEtotablesInfoCardandCertificate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "InfoCards",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Certificates",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "InfoCards");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Certificates");
        }
    }
}
