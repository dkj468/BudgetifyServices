using ExpenseService.Entities;

namespace ExpenseService.Repository
{
    public interface IExpenseRepository
    {
        public Task<List<Expense>> GetAllExpenses();
    }
}
