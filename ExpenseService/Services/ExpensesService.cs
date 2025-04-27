using ExpenseService.DTOs;
using ExpenseService.Repository;

namespace ExpenseService.Services
{
    public class ExpensesService : IExpensesService
    {
        private readonly IExpenseRepository _expenseRepo;

        public ExpensesService(IExpenseRepository expenseRepository)
        {
            _expenseRepo = expenseRepository;
        }
        public async Task<List<ExpenseDto>> GetAllExpenses()
        {
            var expenses = await _expenseRepo.GetAllExpenses();
            var expensesList = new List<ExpenseDto>();
            foreach (var expense in expenses)
            {
                var thisExpense = new ExpenseDto
                {
                    Id = expense.Id,
                    Description = expense.Description,
                    ExpenseCategoryId = expense.ExpenseCategoryId,
                    Amount = expense.Amount,
                    UserId = expense.UserId,
                    GroupId = expense.GroupId,
                    AccountId = expense.AccountId,
                    ExpenseCategory = expense.ExpenseCategory.Name,
                };
                expensesList.Add(thisExpense);
            }
            return expensesList;
        }
    }
}
