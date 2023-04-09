using Microsoft.EntityFrameworkCore.Migrations;

namespace IndentityRobotna.Migrations
{
    public partial class HY : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Curses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Curses_CategoryId",
                table: "Curses",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Curses_Categories_CategoryId",
                table: "Curses",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Curses_Categories_CategoryId",
                table: "Curses");

            migrationBuilder.DropIndex(
                name: "IX_Curses_CategoryId",
                table: "Curses");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Curses");
        }
    }
}
