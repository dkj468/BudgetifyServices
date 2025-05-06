using ExpenseService.DTOs;

namespace ExpenseService.Services
{
    public interface IExpensesService
    {
        public Task<List<ExpenseDto>> GetAllExpenses();
        public Task<ExpenseDto> CreateExpense(CreateExpenseDto expense);
    }
}
