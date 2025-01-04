using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace zltArticle.Migrations
{
    /// <inheritdoc />
    public partial class SortOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArticleSortOrder",
                table: "Article",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArticleSortOrder",
                table: "Article");
        }
    }
}
