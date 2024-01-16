using BudgetService.Models;
using BudgetService.Services;
using Microsoft.AspNetCore.Mvc;

namespace BudgetService.Controllers
{
    [ApiController]
    [Route("api/expenses")]
    public class ExpensesController : ControllerBase
    {
        private readonly IExpenseService _expenseService;

        public ExpensesController(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllExpenses()
        {
            var expenses = await _expenseService.GetAllExpensesAsync();
            return Ok(expenses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetExpenseById(int id)
        {
            var expense = await _expenseService.GetExpenseByIdAsync(id);
            if (expense == null)
            {
                return NotFound();
            }
            return Ok(expense);
        }

        [HttpPost]
        public async Task<IActionResult> AddExpense([FromBody] Expense expense)
        {
            await _expenseService.AddExpenseAsync(expense);
            return CreatedAtAction(nameof(GetExpenseById), new { id = expense.Id }, expense);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExpense(int id, [FromBody] Expense expense)
        {
            if (id != expense.Id)
            {
                return BadRequest();
            }

            await _expenseService.UpdateExpenseAsync(expense);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpense(int id)
        {
            await _expenseService.DeleteExpenseAsync(id);
            return NoContent();
        }

        [HttpGet("total")]
        public async Task<IActionResult> GetTotalExpense([FromQuery] string currency)
        {
            var totalExpense = await _expenseService.GetTotalExpenseAsync(currency);
            return Ok(totalExpense);
        }
    }
}
