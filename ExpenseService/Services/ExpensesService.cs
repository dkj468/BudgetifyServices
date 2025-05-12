using ExpenseService.DTOs;
using ExpenseService.Entities;
using ExpenseService.RabbitMQ;
using ExpenseService.Repository;
using System.Text.Json;

namespace ExpenseService.Services
{
    public class ExpensesService : IExpensesService
    {
        private readonly IExpenseRepository _expenseRepo;
        private readonly IEventPublisher _eventPublisher;
        public ExpensesService(IExpenseRepository expenseRepository, IServiceProvider serviceProvider)
        {
            _expenseRepo = expenseRepository;
            _eventPublisher = serviceProvider.GetRequiredService<IEventPublisher>();
        }

        public async Task<ExpenseDto> CreateExpense(CreateExpenseDto expense)
        {
            var newExpense = new Expense
            {
                Description = expense.Description,
                Amount = expense.Amount,
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now,
                IsDeleted = false,
                UserId = expense.UserId,
                GroupId = expense.GroupId,
                ExpenseCategoryId = expense.ExpenseCategoryId,
                AccountId = expense.AccountId,
            };
            var expenseFromDB = await _expenseRepo.CreateExpense(newExpense);
            var expenseCategory = await _expenseRepo.GetExpenseCategoryById(expense.ExpenseCategoryId);
            var createdExpense = new ExpenseDto
            {
                Id = expenseFromDB.Id,
                Description = expenseFromDB.Description,
                Amount = expenseFromDB.Amount,
                UserId = expenseFromDB.UserId,
                GroupId = expenseFromDB.GroupId,
                ExpenseCategoryId = expenseFromDB.ExpenseCategoryId,
                ExpenseCategory = expenseCategory.Name,
                AccountId = expenseFromDB.AccountId,
            };

            var eventData = JsonSerializer.Serialize(createdExpense);
            await _eventPublisher.Publish("expense", eventData);

            return createdExpense;
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
