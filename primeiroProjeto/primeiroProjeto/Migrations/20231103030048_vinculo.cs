using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace primeiroProjeto.Migrations
{
    public partial class vinculo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "ToDo",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ToDo_UserId",
                table: "ToDo",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDo_Users_UserId",
                table: "ToDo",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDo_Users_UserId",
                table: "ToDo");

            migrationBuilder.DropIndex(
                name: "IX_ToDo_UserId",
                table: "ToDo");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ToDo");
        }
    }
}
