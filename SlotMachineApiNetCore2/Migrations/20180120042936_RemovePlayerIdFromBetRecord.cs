using Microsoft.EntityFrameworkCore.Migrations;

namespace SlotMachineApiNetCore2.Migrations
{
    public partial class RemovePlayerIdFromBetRecord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "PlayerId",
                "BetRecords");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                "PlayerId",
                "BetRecords",
                nullable: true);
        }
    }
}