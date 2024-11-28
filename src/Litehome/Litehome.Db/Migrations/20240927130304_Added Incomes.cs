using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Litehome.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddedIncomes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Incomes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    Frequency = table.Column<int>(type: "INTEGER", nullable: false),
                    ForMemberId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incomes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Incomes_HomeMembers_ForMemberId",
                        column: x => x.ForMemberId,
                        principalTable: "HomeMembers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Incomes_ForMemberId",
                table: "Incomes",
                column: "ForMemberId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Incomes");
        }
    }
}
