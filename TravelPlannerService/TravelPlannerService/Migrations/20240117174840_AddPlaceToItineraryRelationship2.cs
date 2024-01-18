using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TravelPlannerService.Migrations
{
    /// <inheritdoc />
    public partial class AddPlaceToItineraryRelationship2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Itineraries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Itineraries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AddColumn<int>(
                name: "ItineraryId",
                table: "Places",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Places_ItineraryId",
                table: "Places",
                column: "ItineraryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Places_Itineraries_ItineraryId",
                table: "Places",
                column: "ItineraryId",
                principalTable: "Itineraries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Places_Itineraries_ItineraryId",
                table: "Places");

            migrationBuilder.DropIndex(
                name: "IX_Places_ItineraryId",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "ItineraryId",
                table: "Places");

            migrationBuilder.InsertData(
                table: "Itineraries",
                columns: new[] { "Id", "Date", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 16, 19, 45, 36, 401, DateTimeKind.Local).AddTicks(6157), "Itinerary 1" },
                    { 2, new DateTime(2024, 1, 17, 19, 45, 36, 401, DateTimeKind.Local).AddTicks(6159), "Itinerary 2" }
                });

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "Id", "Content", "Date", "Title" },
                values: new object[,]
                {
                    { 1, "Content 1", new DateTime(2024, 1, 16, 19, 45, 36, 401, DateTimeKind.Local).AddTicks(6116), "Note 1" },
                    { 2, "Content 2", new DateTime(2024, 1, 16, 19, 45, 36, 401, DateTimeKind.Local).AddTicks(6128), "Note 2" }
                });

            migrationBuilder.InsertData(
                table: "Places",
                columns: new[] { "Id", "Address", "GooglePlaceId", "Name" },
                values: new object[,]
                {
                    { 1, "Address 1", "google_place_id_1", "Place 1" },
                    { 2, "Address 2", "google_place_id_2", "Place 2" }
                });
        }
    }
}
