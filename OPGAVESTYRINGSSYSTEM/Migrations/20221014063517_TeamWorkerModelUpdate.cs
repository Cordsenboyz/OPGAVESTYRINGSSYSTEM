using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OPGAVESTYRINGSSYSTEM.Migrations
{
    public partial class TeamWorkerModelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeamWorker");

            migrationBuilder.CreateIndex(
                name: "IX_TeamWorkers_TeamId",
                table: "TeamWorkers",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamWorkers_Teams_TeamId",
                table: "TeamWorkers",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamWorkers_Workers_WorkerId",
                table: "TeamWorkers",
                column: "WorkerId",
                principalTable: "Workers",
                principalColumn: "WorkerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamWorkers_Teams_TeamId",
                table: "TeamWorkers");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamWorkers_Workers_WorkerId",
                table: "TeamWorkers");

            migrationBuilder.DropIndex(
                name: "IX_TeamWorkers_TeamId",
                table: "TeamWorkers");

            migrationBuilder.CreateTable(
                name: "TeamWorker",
                columns: table => new
                {
                    TeamId = table.Column<int>(type: "INTEGER", nullable: false),
                    workersWorkerId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamWorker", x => new { x.TeamId, x.workersWorkerId });
                    table.ForeignKey(
                        name: "FK_TeamWorker_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamWorker_Workers_workersWorkerId",
                        column: x => x.workersWorkerId,
                        principalTable: "Workers",
                        principalColumn: "WorkerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeamWorker_workersWorkerId",
                table: "TeamWorker",
                column: "workersWorkerId");
        }
    }
}
