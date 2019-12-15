using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ranks_Bros_BroId",
                table: "Ranks");

            migrationBuilder.AlterColumn<int>(
                name: "BroId",
                table: "Ranks",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ranks_Bros_BroId",
                table: "Ranks",
                column: "BroId",
                principalTable: "Bros",
                principalColumn: "BroId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ranks_Bros_BroId",
                table: "Ranks");

            migrationBuilder.AlterColumn<int>(
                name: "BroId",
                table: "Ranks",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Ranks_Bros_BroId",
                table: "Ranks",
                column: "BroId",
                principalTable: "Bros",
                principalColumn: "BroId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
