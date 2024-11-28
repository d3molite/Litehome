using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Litehome.Db.Migrations
{
    /// <inheritdoc />
    public partial class ReallyaddedExpenses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expense_HomeMembers_HomeMemberId",
                table: "Expense");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Expense",
                table: "Expense");

            migrationBuilder.RenameTable(
                name: "Expense",
                newName: "Expenses");

            migrationBuilder.RenameIndex(
                name: "IX_Expense_HomeMemberId",
                table: "Expenses",
                newName: "IX_Expenses_HomeMemberId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Expenses",
                table: "Expenses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_HomeMembers_HomeMemberId",
                table: "Expenses",
                column: "HomeMemberId",
                principalTable: "HomeMembers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_HomeMembers_HomeMemberId",
                table: "Expenses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Expenses",
                table: "Expenses");

            migrationBuilder.RenameTable(
                name: "Expenses",
                newName: "Expense");

            migrationBuilder.RenameIndex(
                name: "IX_Expenses_HomeMemberId",
                table: "Expense",
                newName: "IX_Expense_HomeMemberId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Expense",
                table: "Expense",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Expense_HomeMembers_HomeMemberId",
                table: "Expense",
                column: "HomeMemberId",
                principalTable: "HomeMembers",
                principalColumn: "Id");
        }
    }
}
