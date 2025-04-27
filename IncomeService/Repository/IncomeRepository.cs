using IncomeService.Data;
using IncomeService.Entities;
using Microsoft.EntityFrameworkCore;

namespace IncomeService.Repository
{
    public class IncomeRepository : IIncomeRepository
    {
        private readonly DataContext _context;
        public IncomeRepository(DataContext context) 
        { 
            _context = context;
        }
        public async Task<List<Income>> GetAllIncomes()
        {
            return await _context.Incomes
                    .Include(i => i.IncomeType)
                    .ToListAsync();
        }
    }
}
