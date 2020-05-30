using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce_DAL.Migrations
{
    public partial class sec : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_ApplicationUser_ApplicationUserId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_ApplicationUser_ApplicationUserId",
                table: "Customers");

            migrationBuilder.DropTable(
                name: "ApplicationUser");

            migrationBuilder.DropIndex(
                name: "IX_Customers_ApplicationUserId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_ApplicationUserId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Addresses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId",
                table: "Addresses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ApplicationUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    AllowEmail = table.Column<bool>(type: "bit", nullable: false),
                    AllowSms = table.Column<bool>(type: "bit", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TCKN = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUser", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ApplicationUserId",
                table: "Customers",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_ApplicationUserId",
                table: "Addresses",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_ApplicationUser_ApplicationUserId",
                table: "Addresses",
                column: "ApplicationUserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_ApplicationUser_ApplicationUserId",
                table: "Customers",
                column: "ApplicationUserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
