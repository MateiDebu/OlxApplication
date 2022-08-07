using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OlxApplicationDB.Migrations
{
    public partial class AddColumnNameAd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NameAd",
                table: "Ads",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameAd",
                table: "Ads");
        }
    }
}
