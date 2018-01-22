using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SlotMachineApiNetCore2.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "BetRecords",
                table => new
                {
                    PlayerId = table.Column<string>(nullable: false),
                    Balance = table.Column<double>(nullable: false),
                    BetAmount = table.Column<double>(nullable: false),
                    NumRows = table.Column<int>(nullable: false),
                    Timestamp = table.Column<DateTime>(nullable: false),
                    WinAmount = table.Column<double>(nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_BetRecords", x => x.PlayerId); });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "BetRecords");
        }
    }
}