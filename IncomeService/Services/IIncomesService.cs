using IncomeService.DTOs;

namespace IncomeService.Services
{
    public interface IIncomesService
    {
        public Task<List<IncomeDto>> GetAllIncomes();
    }
}
