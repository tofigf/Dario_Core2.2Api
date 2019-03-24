using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Direo.Migrations
{
    public partial class AddProductReviews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Photos",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<string>(
                name: "PhotoName",
                table: "Photos",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Listings",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhotoFileName",
                table: "Listings",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoName",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "PhotoFileName",
                table: "Listings");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Photos",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
