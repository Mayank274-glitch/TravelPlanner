﻿// <auto-generated />
using System;
using BudgetService.DbContextCreate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BudgetService.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BudgetService.Models.Expense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("ExpenseValue")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Expenses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Category = "Food",
                            Currency = "USD",
                            Date = new DateTime(2024, 1, 16, 16, 40, 43, 733, DateTimeKind.Utc).AddTicks(867),
                            ExpenseValue = 50.00m
                        },
                        new
                        {
                            Id = 2,
                            Category = "Transportation",
                            Currency = "EUR",
                            Date = new DateTime(2024, 1, 16, 16, 40, 43, 733, DateTimeKind.Utc).AddTicks(871),
                            ExpenseValue = 30.00m
                        },
                        new
                        {
                            Id = 3,
                            Category = "Entertainment",
                            Currency = "USD",
                            Date = new DateTime(2024, 1, 16, 16, 40, 43, 733, DateTimeKind.Utc).AddTicks(874),
                            ExpenseValue = 20.00m
                        },
                        new
                        {
                            Id = 4,
                            Category = "Shopping",
                            Currency = "INR",
                            Date = new DateTime(2024, 1, 16, 16, 40, 43, 733, DateTimeKind.Utc).AddTicks(875),
                            ExpenseValue = 1000.00m
                        },
                        new
                        {
                            Id = 5,
                            Category = "Accommodation",
                            Currency = "GBP",
                            Date = new DateTime(2024, 1, 16, 16, 40, 43, 733, DateTimeKind.Utc).AddTicks(877),
                            ExpenseValue = 40.00m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
