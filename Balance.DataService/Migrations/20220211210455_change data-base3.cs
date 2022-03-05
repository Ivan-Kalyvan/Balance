using Microsoft.EntityFrameworkCore.Migrations;

namespace Balance.DataService.Migrations
{
    public partial class changedatabase3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoURL",
                table: "Cards");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoURL",
                table: "Cards",
                type: "text",
                nullable: true);
        }
    }
}
