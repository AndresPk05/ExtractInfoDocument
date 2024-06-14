using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExtractInfoDocument.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExtractionPerformeds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    License = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtractionPerformeds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExtractionDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameDocument = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ExtractionPerformedId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtractionDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExtractionDetails_ExtractionPerformeds_ExtractionPerformedId",
                        column: x => x.ExtractionPerformedId,
                        principalTable: "ExtractionPerformeds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExtractionDetails_ExtractionPerformedId",
                table: "ExtractionDetails",
                column: "ExtractionPerformedId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExtractionDetails");

            migrationBuilder.DropTable(
                name: "ExtractionPerformeds");
        }
    }
}
