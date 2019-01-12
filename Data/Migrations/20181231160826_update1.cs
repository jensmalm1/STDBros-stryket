using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Weeks_WeekNr",
                table: "Matches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Matches",
                table: "Matches");

            migrationBuilder.RenameTable(
                name: "Matches",
                newName: "Match");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_WeekNr",
                table: "Match",
                newName: "IX_Match_WeekNr");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Match",
                table: "Match",
                column: "MatchNr");

            migrationBuilder.CreateTable(
                name: "Odds",
                columns: table => new
                {
                    OddsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HomeWin = table.Column<double>(nullable: false),
                    Draw = table.Column<double>(nullable: false),
                    AwayWin = table.Column<double>(nullable: false),
                    MatchNr = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odds", x => x.OddsId);
                    table.ForeignKey(
                        name: "FK_Odds_Match_MatchNr",
                        column: x => x.MatchNr,
                        principalTable: "Match",
                        principalColumn: "MatchNr",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Odds_MatchNr",
                table: "Odds",
                column: "MatchNr");

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Weeks_WeekNr",
                table: "Match",
                column: "WeekNr",
                principalTable: "Weeks",
                principalColumn: "WeekNr",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Match_Weeks_WeekNr",
                table: "Match");

            migrationBuilder.DropTable(
                name: "Odds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Match",
                table: "Match");

            migrationBuilder.RenameTable(
                name: "Match",
                newName: "Matches");

            migrationBuilder.RenameIndex(
                name: "IX_Match_WeekNr",
                table: "Matches",
                newName: "IX_Matches_WeekNr");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Matches",
                table: "Matches",
                column: "MatchNr");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Weeks_WeekNr",
                table: "Matches",
                column: "WeekNr",
                principalTable: "Weeks",
                principalColumn: "WeekNr",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
