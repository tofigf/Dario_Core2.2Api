using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Direo.Migrations
{
    public partial class Faqs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Listings",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PriceRangeId",
                table: "Listings",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FagListing",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ListingId = table.Column<int>(nullable: false),
                    Question = table.Column<string>(nullable: true),
                    Answer = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FagListing", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FagListing_Listings_ListingId",
                        column: x => x.ListingId,
                        principalTable: "Listings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OpeningHour",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ListingId = table.Column<int>(nullable: false),
                    DayOfWeek = table.Column<int>(nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    CloseTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    IsClosed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpeningHour", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpeningHour_Listings_ListingId",
                        column: x => x.ListingId,
                        principalTable: "Listings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FagListing_ListingId",
                table: "FagListing",
                column: "ListingId");

            migrationBuilder.CreateIndex(
                name: "IX_OpeningHour_ListingId",
                table: "OpeningHour",
                column: "ListingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FagListing");

            migrationBuilder.DropTable(
                name: "OpeningHour");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "PriceRangeId",
                table: "Listings");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Users",
                maxLength: 20,
                nullable: true);
        }
    }
}
