using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Litehome.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddedMetersandMeasurements : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UtilityMeters",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Active = table.Column<bool>(type: "INTEGER", nullable: false),
                    Unit = table.Column<int>(type: "INTEGER", nullable: false),
                    UtilityType = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UtilityMeters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UtilityMeasurements",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    MeterId = table.Column<string>(type: "TEXT", nullable: false),
                    MeasurementDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    MeasurementValue = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UtilityMeasurements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UtilityMeasurements_UtilityMeters_MeterId",
                        column: x => x.MeterId,
                        principalTable: "UtilityMeters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UtilityMeasurements_MeterId",
                table: "UtilityMeasurements",
                column: "MeterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UtilityMeasurements");

            migrationBuilder.DropTable(
                name: "UtilityMeters");
        }
    }
}
