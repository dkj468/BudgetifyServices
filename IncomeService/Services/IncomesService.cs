using IncomeService.DTOs;
using IncomeService.Entities;
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

        public async Task<IncomeDto> CreateIncome(CreateIncomeDto Income)
        {
            var newIncome = new Income
            {
                AccountId = Income.AccountId,
                IncomeTypeId = Income.IncomeTypeId,
                Amount = Income.Amount,
                Description = Income.Description,
                UserId = Income.UserId,
                GroupId = Income.GroupId,
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now,
                IsDeleted = false
            };
            var incomeFromDB = await _incomeRepo.CreateIncome(newIncome);
            var incomeType = await _incomeRepo.GetIncomeTypeById(Income.IncomeTypeId);
            var createdIncome = new IncomeDto
            {
                Id = incomeFromDB.Id,
                AccountId = incomeFromDB.AccountId,
                IncomeTypeId = incomeFromDB.IncomeTypeId,
                Amount = incomeFromDB.Amount,
                Description = incomeFromDB.Description,
                UserId = incomeFromDB.UserId,
                GroupId = incomeFromDB.GroupId,
                IncomeType = incomeType.Name
            };

            return createdIncome;
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
