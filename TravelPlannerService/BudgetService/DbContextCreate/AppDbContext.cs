using BudgetService.Models;
using Microsoft.EntityFrameworkCore;

namespace BudgetService.DbContextCreate
{
    public class AppDbContext : DbContext
    {
        public DbSet<Expense> Expenses { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Expense>().HasData(
                new Expense { Id = 1, Currency = "USD", ExpenseValue = 50.00m, Category = "Food", Date = DateTime.UtcNow },
                new Expense { Id = 2, Currency = "EUR", ExpenseValue = 30.00m, Category = "Transportation", Date = DateTime.UtcNow },
                new Expense { Id = 3, Currency = "USD", ExpenseValue = 20.00m, Category = "Entertainment", Date = DateTime.UtcNow },
                new Expense { Id = 4, Currency = "INR", ExpenseValue = 1000.00m, Category = "Shopping", Date = DateTime.UtcNow },
                new Expense { Id = 5, Currency = "GBP", ExpenseValue = 40.00m, Category = "Accommodation", Date = DateTime.UtcNow }
            );

            // Other configurations...

            base.OnModelCreating(modelBuilder);
        }
    }
}
