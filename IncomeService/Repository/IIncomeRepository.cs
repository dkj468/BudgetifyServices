using IncomeService.Entities;

namespace IncomeService.Repository
{
    public interface IIncomeRepository
    {
        public Task<List<Income>> GetAllIncomes();
    }
}
