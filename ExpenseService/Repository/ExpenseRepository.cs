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
        public async Task<List<Expense>> GetAllExpenses()
        {
            return await _context.Expenses
                    .Include(e => e.ExpenseCategory)
                    .ToListAsync();
        }
    }
}
