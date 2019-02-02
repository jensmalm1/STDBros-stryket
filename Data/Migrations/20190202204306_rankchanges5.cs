using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class rankchanges5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Team",
                newName: "TeamId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Set",
                newName: "SetId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Result",
                newName: "ResultId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Rank",
                newName: "RankId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Matches",
                newName: "MatchId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Bros",
                newName: "BroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TeamId",
                table: "Team",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "SetId",
                table: "Set",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ResultId",
                table: "Result",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "RankId",
                table: "Rank",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "MatchId",
                table: "Matches",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "BroId",
                table: "Bros",
                newName: "Id");
        }
    }
}
