namespace BudgetService.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public string Currency { get; set; }
        public decimal ExpenseValue { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }
    }
}
