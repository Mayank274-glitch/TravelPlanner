using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TravelPlannerService.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Itineraries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Itineraries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Places",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GooglePlaceId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Places", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Itineraries");

            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "Places");
        }
    }
}
