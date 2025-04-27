using ExpenseService.DTOs;

namespace ExpenseService.Services
{
    public interface IExpensesService
    {
        public Task<List<ExpenseDto>> GetAllExpenses();
    }
}
