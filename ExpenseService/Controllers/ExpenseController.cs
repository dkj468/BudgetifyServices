using ExpenseService.DTOs;
using ExpenseService.Repository;
using ExpenseService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpensesService _expenseService;
        public ExpenseController(IExpensesService expensesService)
        {
            _expenseService = expensesService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllExpenses()
        {
            var data = await _expenseService.GetAllExpenses();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateExpense(CreateExpenseDto expense)
        {
            var createdExpense = await _expenseService.CreateExpense(expense);
            return CreatedAtAction("CreateExpense", createdExpense);
        }
    }
}
