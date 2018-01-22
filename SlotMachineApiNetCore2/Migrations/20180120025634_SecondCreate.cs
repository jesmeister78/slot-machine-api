using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SlotMachineApiNetCore2.Migrations
{
    public partial class SecondCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BetRecords",
                table: "BetRecords");

            migrationBuilder.AlterColumn<string>(
                name: "PlayerId",
                table: "BetRecords",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<Guid>(
                name: "BetId",
                table: "BetRecords",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "SessionId",
                table: "BetRecords",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_BetRecords",
                table: "BetRecords",
                column: "BetId");

            migrationBuilder.CreateTable(
                name: "GamblingSessions",
                columns: table => new
                {
                    SessionId = table.Column<Guid>(nullable: false),
                    FinalBalance = table.Column<double>(nullable: false),
                    InitialBalance = table.Column<double>(nullable: false),
                    PlayerGroup = table.Column<int>(nullable: false),
                    PlayerId = table.Column<string>(nullable: true),
                    SessionEnd = table.Column<DateTime>(nullable: true),
                    SessionStart = table.Column<DateTime>(nullable: false),
                    TimerInterval = table.Column<int>(nullable: false),
                    TotalNumBets = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamblingSessions", x => x.SessionId);
                });

            migrationBuilder.CreateTable(
                name: "GrcsResponses",
                columns: table => new
                {
                    GrcsResponseId = table.Column<Guid>(nullable: false),
                    Answer = table.Column<int>(nullable: false),
                    NumMinutesPlayed = table.Column<int>(nullable: false),
                    QuestionId = table.Column<int>(nullable: false),
                    SessionId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrcsResponses", x => x.GrcsResponseId);
                    table.ForeignKey(
                        name: "FK_GrcsResponses_GamblingSessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "GamblingSessions",
                        principalColumn: "SessionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BetRecords_SessionId",
                table: "BetRecords",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_GrcsResponses_SessionId",
                table: "GrcsResponses",
                column: "SessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_BetRecords_GamblingSessions_SessionId",
                table: "BetRecords",
                column: "SessionId",
                principalTable: "GamblingSessions",
                principalColumn: "SessionId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BetRecords_GamblingSessions_SessionId",
                table: "BetRecords");

            migrationBuilder.DropTable(
                name: "GrcsResponses");

            migrationBuilder.DropTable(
                name: "GamblingSessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BetRecords",
                table: "BetRecords");

            migrationBuilder.DropIndex(
                name: "IX_BetRecords_SessionId",
                table: "BetRecords");

            migrationBuilder.DropColumn(
                name: "BetId",
                table: "BetRecords");

            migrationBuilder.DropColumn(
                name: "SessionId",
                table: "BetRecords");

            migrationBuilder.AlterColumn<string>(
                name: "PlayerId",
                table: "BetRecords",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BetRecords",
                table: "BetRecords",
                column: "PlayerId");
        }
    }
}
