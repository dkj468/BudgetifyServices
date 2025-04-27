using IncomeService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IncomeService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
    }
}
