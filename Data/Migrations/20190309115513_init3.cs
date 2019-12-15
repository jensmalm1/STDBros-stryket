using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rank_Bros_BroId",
                table: "Rank");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rank",
                table: "Rank");

            migrationBuilder.RenameTable(
                name: "Rank",
                newName: "Ranks");

            migrationBuilder.RenameIndex(
                name: "IX_Rank_BroId",
                table: "Ranks",
                newName: "IX_Ranks_BroId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ranks",
                table: "Ranks",
                column: "RankId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ranks_Bros_BroId",
                table: "Ranks",
                column: "BroId",
                principalTable: "Bros",
                principalColumn: "BroId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ranks_Bros_BroId",
                table: "Ranks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ranks",
                table: "Ranks");

            migrationBuilder.RenameTable(
                name: "Ranks",
                newName: "Rank");

            migrationBuilder.RenameIndex(
                name: "IX_Ranks_BroId",
                table: "Rank",
                newName: "IX_Rank_BroId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rank",
                table: "Rank",
                column: "RankId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rank_Bros_BroId",
                table: "Rank",
                column: "BroId",
                principalTable: "Bros",
                principalColumn: "BroId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
