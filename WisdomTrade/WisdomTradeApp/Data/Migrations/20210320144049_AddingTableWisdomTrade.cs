using Microsoft.EntityFrameworkCore.Migrations;

namespace WisdomTradeApp.Data.Migrations
{
    public partial class AddingTableWisdomTrade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WisdomTrade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ticker = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Population = table.Column<int>(type: "int", nullable: false),
                    TotalCredit = table.Column<float>(type: "real", nullable: false),
                    AverageUpperLimit = table.Column<float>(type: "real", nullable: false),
                    AverageLowerLimit = table.Column<float>(type: "real", nullable: false),
                    FinalDirection = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WisdomTrade", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WisdomTrade");
        }
    }
}
