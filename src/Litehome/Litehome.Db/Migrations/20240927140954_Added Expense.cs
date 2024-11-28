using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Litehome.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddedExpense : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Incomes",
                type: "TEXT",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Expense",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    Frequency = table.Column<int>(type: "INTEGER", nullable: false),
                    HomeMemberId = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expense", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expense_HomeMembers_HomeMemberId",
                        column: x => x.HomeMemberId,
                        principalTable: "HomeMembers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Expense_HomeMemberId",
                table: "Expense",
                column: "HomeMemberId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expense");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Incomes");
        }
    }
}
