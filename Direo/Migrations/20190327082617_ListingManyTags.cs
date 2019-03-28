using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Direo.Migrations
{
    public partial class ListingManyTags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ListingTags",
                table: "ListingTags");

            migrationBuilder.DropIndex(
                name: "IX_ListingTags_ListingId",
                table: "ListingTags");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ListingTags",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ListingTags",
                table: "ListingTags",
                columns: new[] { "ListingId", "TagId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ListingTags",
                table: "ListingTags");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ListingTags",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ListingTags",
                table: "ListingTags",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ListingTags_ListingId",
                table: "ListingTags",
                column: "ListingId");
        }
    }
}
