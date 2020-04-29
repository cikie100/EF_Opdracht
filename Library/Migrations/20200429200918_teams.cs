using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class teams : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "teams",
                columns: table => new
                {
                    stamnummer = table.Column<int>(nullable: false),
                    naamTrainer = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teams", x => x.stamnummer);
                });

            migrationBuilder.CreateTable(
                name: "spelers",
                columns: table => new
                {
                    spelerid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    naam = table.Column<string>(nullable: true),
                    rugnummer = table.Column<int>(nullable: false),
                    waarde = table.Column<int>(nullable: false),
                    teamstamnummer = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_spelers", x => x.spelerid);
                    table.ForeignKey(
                        name: "FK_spelers_teams_teamstamnummer",
                        column: x => x.teamstamnummer,
                        principalTable: "teams",
                        principalColumn: "stamnummer",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "transfers",
                columns: table => new
                {
                    transferid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    spelerID = table.Column<int>(nullable: false),
                    transferPrijs = table.Column<int>(nullable: false),
                    oude_teamstamnummer = table.Column<int>(nullable: true),
                    nieuwe_teamID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transfers", x => x.transferid);
                    table.ForeignKey(
                        name: "FK_transfers_teams_nieuwe_teamID",
                        column: x => x.nieuwe_teamID,
                        principalTable: "teams",
                        principalColumn: "stamnummer",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_transfers_teams_oude_teamstamnummer",
                        column: x => x.oude_teamstamnummer,
                        principalTable: "teams",
                        principalColumn: "stamnummer",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_transfers_spelers_spelerID",
                        column: x => x.spelerID,
                        principalTable: "spelers",
                        principalColumn: "spelerid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_spelers_teamstamnummer",
                table: "spelers",
                column: "teamstamnummer");

            migrationBuilder.CreateIndex(
                name: "IX_transfers_nieuwe_teamID",
                table: "transfers",
                column: "nieuwe_teamID");

            migrationBuilder.CreateIndex(
                name: "IX_transfers_oude_teamstamnummer",
                table: "transfers",
                column: "oude_teamstamnummer");

            migrationBuilder.CreateIndex(
                name: "IX_transfers_spelerID",
                table: "transfers",
                column: "spelerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "transfers");

            migrationBuilder.DropTable(
                name: "spelers");

            migrationBuilder.DropTable(
                name: "teams");
        }
    }
}
