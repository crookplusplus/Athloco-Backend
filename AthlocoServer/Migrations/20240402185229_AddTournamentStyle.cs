using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AthlocoServer.Migrations
{
    /// <inheritdoc />
    public partial class AddTournamentStyle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Style",
                table: "Tournaments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Style",
                table: "Tournaments");
        }
    }
}
