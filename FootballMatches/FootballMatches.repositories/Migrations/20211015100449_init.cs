using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FootballMatches.Repositories.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FootballMatches",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationId = table.Column<int>(nullable: false),
                    EventDate = table.Column<DateTime>(nullable: false),
                    FirstTeamGoals = table.Column<int>(nullable: false),
                    SecondTeamGoals = table.Column<int>(nullable: false),
                    FirstTeamId = table.Column<int>(nullable: true),
                    SecondTeamId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FootballMatches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FootballMatches_Teams_FirstTeamId",
                        column: x => x.FirstTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FootballMatches_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FootballMatches_Teams_SecondTeamId",
                        column: x => x.SecondTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    TeamId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Chisinau" },
                    { 2, "Tiraspol" },
                    { 3, "Anenii" }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Team 1" },
                    { 2, "Team 2" },
                    { 3, "Team 3" },
                    { 4, "Team 4" },
                    { 5, "Team 5" },
                    { 6, "Team 6" }
                });

            migrationBuilder.InsertData(
                table: "FootballMatches",
                columns: new[] { "Id", "EventDate", "FirstTeamGoals", "FirstTeamId", "LocationId", "SecondTeamGoals", "SecondTeamId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 1, 1, 1, 2 },
                    { 2, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 3, 2, 1, 4 },
                    { 3, new DateTime(2021, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 5, 3, 2, 6 },
                    { 4, new DateTime(2021, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, 1, 2, 6 },
                    { 5, new DateTime(2021, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 2, 1, 5, 6 }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Name", "TeamId" },
                values: new object[,]
                {
                    { 1, "Player 1", 1 },
                    { 2, "Player 2", 1 },
                    { 3, "Player 3", 2 },
                    { 4, "Player 4", 3 },
                    { 6, "Player 6", 3 },
                    { 5, "Player 5", 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FootballMatches_FirstTeamId",
                table: "FootballMatches",
                column: "FirstTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_FootballMatches_LocationId",
                table: "FootballMatches",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_FootballMatches_SecondTeamId",
                table: "FootballMatches",
                column: "SecondTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamId",
                table: "Players",
                column: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FootballMatches");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
