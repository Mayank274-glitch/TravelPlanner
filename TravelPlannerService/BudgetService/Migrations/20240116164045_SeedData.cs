using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BudgetService.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Expenses",
                columns: new[] { "Id", "Category", "Currency", "Date", "ExpenseValue" },
                values: new object[,]
                {
                    { 1, "Food", "USD", new DateTime(2024, 1, 16, 16, 40, 43, 733, DateTimeKind.Utc).AddTicks(867), 50.00m },
                    { 2, "Transportation", "EUR", new DateTime(2024, 1, 16, 16, 40, 43, 733, DateTimeKind.Utc).AddTicks(871), 30.00m },
                    { 3, "Entertainment", "USD", new DateTime(2024, 1, 16, 16, 40, 43, 733, DateTimeKind.Utc).AddTicks(874), 20.00m },
                    { 4, "Shopping", "INR", new DateTime(2024, 1, 16, 16, 40, 43, 733, DateTimeKind.Utc).AddTicks(875), 1000.00m },
                    { 5, "Accommodation", "GBP", new DateTime(2024, 1, 16, 16, 40, 43, 733, DateTimeKind.Utc).AddTicks(877), 40.00m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
