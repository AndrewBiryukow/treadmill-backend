using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace treadmill_server.Migrations
{
    /// <inheritdoc />
    public partial class removedMachineStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "FitnessMachines");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "FitnessMachines",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
