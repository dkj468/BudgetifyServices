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

        public async Task<Income> CreateIncome(Income income)
        {
            _context.Incomes.Add(income);
            await _context.SaveChangesAsync();
            return income;
        }

        public async Task<List<Income>> GetAllIncomes()
        {
            return await _context.Incomes
                    .Include(i => i.IncomeType)
                    .ToListAsync();
        }

        public async Task<IncomeType> GetIncomeTypeById(int id)
        {
            var incomeType = await _context.IncomeTypes.FindAsync(id);
            return incomeType;
        }
    }
}
