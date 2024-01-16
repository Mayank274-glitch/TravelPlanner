using BudgetService.Models;
using BudgetService.Repository;

namespace BudgetService.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _expenseRepository;

        public ExpenseService(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        public Task<IEnumerable<Expense>> GetAllExpensesAsync()
        {
            return _expenseRepository.GetAllExpensesAsync();
        }

        public Task<Expense> GetExpenseByIdAsync(int id)
        {
            return _expenseRepository.GetExpenseByIdAsync(id);
        }

        public Task AddExpenseAsync(Expense expense)
        {
            return _expenseRepository.AddExpenseAsync(expense);
        }

        public Task UpdateExpenseAsync(Expense expense)
        {
            return _expenseRepository.UpdateExpenseAsync(expense);
        }

        public Task DeleteExpenseAsync(int id)
        {
            return _expenseRepository.DeleteExpenseAsync(id);
        }

        public async Task<ExpenseTotal> GetTotalExpenseAsync(string currency)
        {
            var totalExpense = await _expenseRepository.GetTotalExpenseAsync(currency);
            return new ExpenseTotal { Currency = currency, TotalExpense = totalExpense };
        }
    }
}
