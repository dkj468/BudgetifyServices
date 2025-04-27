using ExpenseService.Repository;
using ExpenseService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
    }
}
