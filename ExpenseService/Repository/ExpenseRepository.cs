using ExpenseService.Data;
using ExpenseService.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpenseService.Repository
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly DataContext _context;
        public ExpenseRepository(DataContext context) 
        { 
            _context = context;
        }

        public async Task<Expense> CreateExpense(Expense expense)
        {
            _context.Expenses.Add(expense);
            await _context.SaveChangesAsync();
            return expense;
        }

        public async Task<List<Expense>> GetAllExpenses()
        {
            return await _context.Expenses
                    .Include(e => e.ExpenseCategory)
                    .ToListAsync();
        }

        public async Task<ExpenseCategory> GetExpenseCategoryById(int id)
        {
            var expenseCategory = await _context.ExpenseCategories.FindAsync(id);
            return expenseCategory;
        }
    }
}
