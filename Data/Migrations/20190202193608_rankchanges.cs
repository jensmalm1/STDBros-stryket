using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class rankchanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gem");

            migrationBuilder.DropColumn(
                name: "Team1Player1",
                table: "Match");

            migrationBuilder.DropColumn(
                name: "Team1Player2",
                table: "Match");

            migrationBuilder.DropColumn(
                name: "Team2Player1",
                table: "Match");

            migrationBuilder.DropColumn(
                name: "Team2Player2",
                table: "Match");

            migrationBuilder.DropColumn(
                name: "Rank",
                table: "Bros");

            migrationBuilder.RenameColumn(
                name: "MatchId",
                table: "Match",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "TeamOneGems",
                table: "Set",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TeamTwoGems",
                table: "Set",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Winner",
                table: "Set",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TeamOneSets",
                table: "Result",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TeamTwoSets",
                table: "Result",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Winner",
                table: "Result",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "Bros",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Rank",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ranking = table.Column<decimal>(nullable: false),
                    BroId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rank", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rank_Bros_BroId",
                        column: x => x.BroId,
                        principalTable: "Bros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MatchId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Team_Match_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Match",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bros_TeamId",
                table: "Bros",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Rank_BroId",
                table: "Rank",
                column: "BroId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_MatchId",
                table: "Team",
                column: "MatchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bros_Team_TeamId",
                table: "Bros",
                column: "TeamId",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bros_Team_TeamId",
                table: "Bros");

            migrationBuilder.DropTable(
                name: "Rank");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropIndex(
                name: "IX_Bros_TeamId",
                table: "Bros");

            migrationBuilder.DropColumn(
                name: "TeamOneGems",
                table: "Set");

            migrationBuilder.DropColumn(
                name: "TeamTwoGems",
                table: "Set");

            migrationBuilder.DropColumn(
                name: "Winner",
                table: "Set");

            migrationBuilder.DropColumn(
                name: "TeamOneSets",
                table: "Result");

            migrationBuilder.DropColumn(
                name: "TeamTwoSets",
                table: "Result");

            migrationBuilder.DropColumn(
                name: "Winner",
                table: "Result");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Bros");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Match",
                newName: "MatchId");

            migrationBuilder.AddColumn<string>(
                name: "Team1Player1",
                table: "Match",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Team1Player2",
                table: "Match",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Team2Player1",
                table: "Match",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Team2Player2",
                table: "Match",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Rank",
                table: "Bros",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "Gem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SetId = table.Column<int>(nullable: true),
                    Team1 = table.Column<int>(nullable: false),
                    Team2 = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gem_Set_SetId",
                        column: x => x.SetId,
                        principalTable: "Set",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gem_SetId",
                table: "Gem",
                column: "SetId");
        }
    }
}
