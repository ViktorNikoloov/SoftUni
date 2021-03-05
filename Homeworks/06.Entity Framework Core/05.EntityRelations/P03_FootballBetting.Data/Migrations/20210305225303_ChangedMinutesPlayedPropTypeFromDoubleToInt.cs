using Microsoft.EntityFrameworkCore.Migrations;

namespace P03_FootballBetting.Data.Migrations
{
    public partial class ChangedMinutesPlayedPropTypeFromDoubleToInt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "MinutesPlayed",
                table: "PlayerStatistics",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "MinutesPlayed",
                table: "PlayerStatistics",
                type: "float",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
