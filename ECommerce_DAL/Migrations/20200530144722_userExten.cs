using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce_DAL.Migrations
{
    public partial class userExten : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "AppUsers");

            migrationBuilder.AddColumn<string>(
                name: "Profession",
                table: "AppUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Profession",
                table: "AppUsers");

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "AppUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
