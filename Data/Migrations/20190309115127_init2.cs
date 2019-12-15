using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rank_Bros_BroId",
                table: "Rank");

            migrationBuilder.AlterColumn<int>(
                name: "BroId",
                table: "Rank",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Rank_Bros_BroId",
                table: "Rank",
                column: "BroId",
                principalTable: "Bros",
                principalColumn: "BroId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rank_Bros_BroId",
                table: "Rank");

            migrationBuilder.AlterColumn<int>(
                name: "BroId",
                table: "Rank",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Rank_Bros_BroId",
                table: "Rank",
                column: "BroId",
                principalTable: "Bros",
                principalColumn: "BroId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
