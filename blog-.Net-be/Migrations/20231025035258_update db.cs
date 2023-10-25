using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace blog_.Net_be.Migrations
{
    /// <inheritdoc />
    public partial class updatedb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Categories_categoryId",
                table: "Blogs");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "Blogs",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Blogs",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "categoryId",
                table: "Blogs",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "author",
                table: "Blogs",
                newName: "Author");

            migrationBuilder.RenameIndex(
                name: "IX_Blogs_categoryId",
                table: "Blogs",
                newName: "IX_Blogs_CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Categories_CategoryId",
                table: "Blogs",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Categories_CategoryId",
                table: "Blogs");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Blogs",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Blogs",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Blogs",
                newName: "categoryId");

            migrationBuilder.RenameColumn(
                name: "Author",
                table: "Blogs",
                newName: "author");

            migrationBuilder.RenameIndex(
                name: "IX_Blogs_CategoryId",
                table: "Blogs",
                newName: "IX_Blogs_categoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Categories_categoryId",
                table: "Blogs",
                column: "categoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
