using BudgetService.DbContextCreate;
using BudgetService.Models;
using Microsoft.EntityFrameworkCore;

namespace BudgetService.Repository
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly AppDbContext _dbContext;

        public ExpenseRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Expense>> GetAllExpensesAsync()
        {
            return await _dbContext.Expenses.ToListAsync();
        }

        public async Task<Expense> GetExpenseByIdAsync(int id)
        {
            return await _dbContext.Expenses.FindAsync(id);
        }

        public async Task AddExpenseAsync(Expense expense)
        {
            _dbContext.Expenses.Add(expense);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateExpenseAsync(Expense expense)
        {
            _dbContext.Entry(expense).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteExpenseAsync(int id)
        {
            var expense = await _dbContext.Expenses.FindAsync(id);
            if (expense != null)
            {
                _dbContext.Expenses.Remove(expense);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<decimal> GetTotalExpenseAsync(string targetCurrency)
        {

            var expenses = await _dbContext.Expenses.ToListAsync();

            // Sum the values for the target currency, or return 0 if no expenses match the target currency
            var totalExpense = expenses
                .Where(expense => expense.Currency == targetCurrency)
                .Sum(expense => expense.ExpenseValue);

            return totalExpense;
        }
    }
}
