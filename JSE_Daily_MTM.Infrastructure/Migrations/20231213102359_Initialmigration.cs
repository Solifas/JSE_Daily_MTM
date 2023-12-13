using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JSEDailyMTM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DailyMTM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Contract = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Classification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Strike = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CallPut = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MTMYield = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MarkPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SpotRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PreviousMTM = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PreviousPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PremiumOnOption = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Volatility = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Delta = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DeltaValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ContractsTraded = table.Column<int>(type: "int", nullable: false),
                    OpenInterest = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyMTM", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyMTM");
        }
    }
}
