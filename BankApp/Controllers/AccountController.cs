using Microsoft.AspNetCore.Mvc;
namespace BankApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpGet("balance/{accountNumber}")]
        public IActionResult GetBalance(int accountNumber)
        {
            if (accountNumber.ToString().Length > 5)
                //return Problem("Invalid account number", "Get Balance", 400, "API Error");
                throw new Exception("Invalid account number");
            return Ok("");
        }
    }
}
