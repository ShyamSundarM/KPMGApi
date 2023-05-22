using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KPMGApi.Migrations
{
    /// <inheritdoc />
    public partial class addRainAndJobTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobEmployments",
                columns: table => new
                {
                    Category = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Developers = table.Column<int>(type: "int", nullable: false),
                    Manufacturing = table.Column<int>(type: "int", nullable: false),
                    Sales = table.Column<int>(type: "int", nullable: false),
                    Operations = table.Column<int>(type: "int", nullable: false),
                    Other = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobEmployments", x => x.Category);
                });

            migrationBuilder.CreateTable(
                name: "RainTimeline",
                columns: table => new
                {
                    Category = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Tokyo = table.Column<double>(type: "float", nullable: false),
                    NewYork = table.Column<double>(type: "float", nullable: false),
                    London = table.Column<double>(type: "float", nullable: false),
                    Berlin = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RainTimeline", x => x.Category);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobEmployments");

            migrationBuilder.DropTable(
                name: "RainTimeline");
        }
    }
}
