using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Litehome.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddedDefaultCategoryData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ExpenseCategories",
                columns: new[] { "Id", "Name" },
                values: new object[] { "fb7cafed-001d-44ad-8fa7-83bb3cbea7bd", "General" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ExpenseCategories",
                keyColumn: "Id",
                keyValue: "fb7cafed-001d-44ad-8fa7-83bb3cbea7bd");
        }
    }
}
