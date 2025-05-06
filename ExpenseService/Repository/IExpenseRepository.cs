using ExpenseService.Entities;

namespace ExpenseService.Repository
{
    public interface IExpenseRepository
    {
        public Task<List<Expense>> GetAllExpenses();
        public Task<Expense> CreateExpense(Expense expense);
        public Task<ExpenseCategory> GetExpenseCategoryById(int id);
    }
}
