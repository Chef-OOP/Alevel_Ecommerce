using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce_DAL.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "OperationClaims",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "OperationClaims",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "OperationClaims",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated",
                table: "OperationClaims",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "AppUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "AppUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AppUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "AppUsers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenEndDate",
                table: "AppUsers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated",
                table: "AppUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "OperationClaims");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "OperationClaims");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "OperationClaims");

            migrationBuilder.DropColumn(
                name: "Updated",
                table: "OperationClaims");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "RefreshTokenEndDate",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "Updated",
                table: "AppUsers");
        }
    }
}
