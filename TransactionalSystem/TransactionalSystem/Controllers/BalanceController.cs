using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TransactionalSystem.Models.Balance;
using TransactionalSystem.Services;

namespace TransactionalSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BalanceController : ControllerBase
    {
        private readonly IBalanceService _balanceService;

        public BalanceController(IBalanceService balanceService)
        {
            _balanceService = balanceService;
        }

        // GET api/balance
        [HttpGet]
        public async Task<ActionResult<CurrentBalanceResponse>> Get()
        {
            var currentBalance = await _balanceService.GetCurrentAccountBalanceAsync();

            var response = new CurrentBalanceResponse() { CurrentAccountBalance = currentBalance };

            return Ok(response);
        }
    }
}
