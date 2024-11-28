using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Litehome.Db.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedIncomewithKeyValues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Incomes_HomeMembers_ForMemberId",
                table: "Incomes");

            migrationBuilder.DropIndex(
                name: "IX_Incomes_ForMemberId",
                table: "Incomes");

            migrationBuilder.DropColumn(
                name: "ForMemberId",
                table: "Incomes");

            migrationBuilder.AddColumn<string>(
                name: "HomeMemberId",
                table: "Incomes",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Incomes_HomeMemberId",
                table: "Incomes",
                column: "HomeMemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Incomes_HomeMembers_HomeMemberId",
                table: "Incomes",
                column: "HomeMemberId",
                principalTable: "HomeMembers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Incomes_HomeMembers_HomeMemberId",
                table: "Incomes");

            migrationBuilder.DropIndex(
                name: "IX_Incomes_HomeMemberId",
                table: "Incomes");

            migrationBuilder.DropColumn(
                name: "HomeMemberId",
                table: "Incomes");

            migrationBuilder.AddColumn<string>(
                name: "ForMemberId",
                table: "Incomes",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Incomes_ForMemberId",
                table: "Incomes",
                column: "ForMemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Incomes_HomeMembers_ForMemberId",
                table: "Incomes",
                column: "ForMemberId",
                principalTable: "HomeMembers",
                principalColumn: "Id");
        }
    }
}
