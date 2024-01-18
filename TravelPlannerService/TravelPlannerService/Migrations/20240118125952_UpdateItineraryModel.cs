using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelPlannerService.Migrations
{
    /// <inheritdoc />
    public partial class UpdateItineraryModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Itineraries",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Itineraries");
        }
    }
}
