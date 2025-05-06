using IncomeService.DTOs;
using IncomeService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IncomeService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class IncomeController : ControllerBase
    {
        private readonly IIncomesService _incomesService;
        public IncomeController(IIncomesService incomesService)
        {
            _incomesService = incomesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllIncomes()
        {
            var data = await _incomesService.GetAllIncomes();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateIncome(CreateIncomeDto income)
        {
            var newIncome = await _incomesService.CreateIncome(income);
            return CreatedAtAction("createIncome", newIncome);
        }
    }
}
