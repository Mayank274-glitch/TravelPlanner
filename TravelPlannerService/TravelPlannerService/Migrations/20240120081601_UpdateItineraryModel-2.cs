using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelPlannerService.Migrations
{
    /// <inheritdoc />
    public partial class UpdateItineraryModel2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Itineraries",
                newName: "StartDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Itineraries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Itineraries");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Itineraries",
                newName: "Date");
        }
    }
}
