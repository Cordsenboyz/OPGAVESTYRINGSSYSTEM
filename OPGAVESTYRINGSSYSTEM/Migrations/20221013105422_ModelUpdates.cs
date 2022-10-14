using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OPGAVESTYRINGSSYSTEM.Migrations
{
    public partial class ModelUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsComplete",
                table: "Todos",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Todos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Tasks",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsComplete",
                table: "Todos");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Todos");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Tasks");
        }
    }
}
