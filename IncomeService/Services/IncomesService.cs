using IncomeService.DTOs;
using IncomeService.Repository;

namespace IncomeService.Services
{
    public class IncomesService : IIncomesService
    {
        private readonly IIncomeRepository _incomeRepo;

        public IncomesService(IIncomeRepository incomeRepository)
        {
            _incomeRepo = incomeRepository;
        }
        public async Task<List<IncomeDto>> GetAllIncomes()
        {
            var incomes = await _incomeRepo.GetAllIncomes();
            var incomesList = new List<IncomeDto>();
            foreach (var income in incomes)
            {
                var thisExpense = new IncomeDto
                {
                    Id = income.Id,
                    Description = income.Description,
                    IncomeTypeId = income.IncomeTypeId,
                    Amount = income.Amount,
                    UserId = income.UserId,
                    GroupId = income.GroupId,
                    AccountId = income.AccountId,
                    IncomeType = income.IncomeType.Name
                };
                incomesList.Add(thisExpense);
            }
            return incomesList;
        }
    }
}
