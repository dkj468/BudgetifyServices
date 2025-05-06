using IncomeService.Entities;

namespace IncomeService.Repository
{
    public interface IIncomeRepository
    {
        public Task<List<Income>> GetAllIncomes();
        public Task<Income> CreateIncome (Income income);
        public Task<IncomeType> GetIncomeTypeById (int id);
    }
}
