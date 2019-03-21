using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Direo.Migrations
{
    public partial class Listing_Category_Photo_Location_ReviewListing_SideBarForm_Subscriber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Icon = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SidebarForms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Email = table.Column<string>(nullable: false),
                    MessageText = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SidebarForms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subscribers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscribers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Listings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 150, nullable: false),
                    LongDescription = table.Column<string>(type: "text", nullable: true),
                    Tagline = table.Column<string>(maxLength: 100, nullable: true),
                    Price = table.Column<decimal>(type: "money", nullable: true),
                    ShortDescription = table.Column<string>(maxLength: 200, nullable: true),
                    Address = table.Column<string>(maxLength: 50, nullable: true),
                    Phone = table.Column<string>(maxLength: 50, nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Website = table.Column<string>(maxLength: 50, nullable: true),
                    Facebook = table.Column<string>(maxLength: 50, nullable: true),
                    Twitter = table.Column<string>(maxLength: 50, nullable: true),
                    Google = table.Column<string>(maxLength: 50, nullable: true),
                    Linkedin = table.Column<string>(maxLength: 50, nullable: true),
                    Youtube = table.Column<string>(maxLength: 50, nullable: true),
                    VideoUrl = table.Column<string>(maxLength: 50, nullable: true),
                    IsSevenTwentyFour = table.Column<bool>(nullable: true),
                    Longitude = table.Column<string>(maxLength: 100, nullable: true),
                    Latitude = table.Column<string>(maxLength: 100, nullable: true),
                    ViewsCount = table.Column<int>(nullable: true),
                    Rating = table.Column<decimal>(nullable: true),
                    PostDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    LocationId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Listings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Listings_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Listings_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Listings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PhotoUrl = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    IsMain = table.Column<bool>(nullable: false),
                    ListingId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_Listings_ListingId",
                        column: x => x.ListingId,
                        principalTable: "Listings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ReviewsListings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ListingId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    Rating = table.Column<byte>(type: "tinyint", nullable: false),
                    PhotoUrl = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewsListings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReviewsListings_Listings_ListingId",
                        column: x => x.ListingId,
                        principalTable: "Listings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReviewsListings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Listings_CategoryId",
                table: "Listings",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Listings_LocationId",
                table: "Listings",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Listings_UserId",
                table: "Listings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_ListingId",
                table: "Photos",
                column: "ListingId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewsListings_ListingId",
                table: "ReviewsListings",
                column: "ListingId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewsListings_UserId",
                table: "ReviewsListings",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "ReviewsListings");

            migrationBuilder.DropTable(
                name: "SidebarForms");

            migrationBuilder.DropTable(
                name: "Subscribers");

            migrationBuilder.DropTable(
                name: "Listings");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
