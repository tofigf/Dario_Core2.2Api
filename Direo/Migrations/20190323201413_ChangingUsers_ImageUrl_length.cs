using Microsoft.EntityFrameworkCore.Migrations;

namespace Direo.Migrations
{
    public partial class ChangingUsers_ImageUrl_length : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListingTag_Listings_ListingId",
                table: "ListingTag");

            migrationBuilder.DropForeignKey(
                name: "FK_ListingTag_Tags_TagId",
                table: "ListingTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ListingTag",
                table: "ListingTag");

            migrationBuilder.RenameTable(
                name: "ListingTag",
                newName: "ListingTags");

            migrationBuilder.RenameIndex(
                name: "IX_ListingTag_TagId",
                table: "ListingTags",
                newName: "IX_ListingTags_TagId");

            migrationBuilder.RenameIndex(
                name: "IX_ListingTag_ListingId",
                table: "ListingTags",
                newName: "IX_ListingTags_ListingId");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ListingTags",
                table: "ListingTags",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ListingTags_Listings_ListingId",
                table: "ListingTags",
                column: "ListingId",
                principalTable: "Listings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ListingTags_Tags_TagId",
                table: "ListingTags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListingTags_Listings_ListingId",
                table: "ListingTags");

            migrationBuilder.DropForeignKey(
                name: "FK_ListingTags_Tags_TagId",
                table: "ListingTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ListingTags",
                table: "ListingTags");

            migrationBuilder.RenameTable(
                name: "ListingTags",
                newName: "ListingTag");

            migrationBuilder.RenameIndex(
                name: "IX_ListingTags_TagId",
                table: "ListingTag",
                newName: "IX_ListingTag_TagId");

            migrationBuilder.RenameIndex(
                name: "IX_ListingTags_ListingId",
                table: "ListingTag",
                newName: "IX_ListingTag_ListingId");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Users",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ListingTag",
                table: "ListingTag",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ListingTag_Listings_ListingId",
                table: "ListingTag",
                column: "ListingId",
                principalTable: "Listings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ListingTag_Tags_TagId",
                table: "ListingTag",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
