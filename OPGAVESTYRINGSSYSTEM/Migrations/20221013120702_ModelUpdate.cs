using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OPGAVESTYRINGSSYSTEM.Migrations
{
    public partial class ModelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TaskId",
                table: "Todos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Todos_TaskId",
                table: "Todos",
                column: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Todos_Tasks_TaskId",
                table: "Todos",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "TaskId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todos_Tasks_TaskId",
                table: "Todos");

            migrationBuilder.DropIndex(
                name: "IX_Todos_TaskId",
                table: "Todos");

            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "Todos");
        }
    }
}
