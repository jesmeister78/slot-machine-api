using Microsoft.EntityFrameworkCore.Migrations;

namespace SlotMachineDomain.Migrations
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