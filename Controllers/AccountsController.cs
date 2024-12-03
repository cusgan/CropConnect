using CropConnect.Models;
using CropConnect.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace CropConnect.Controllers
{
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountsController(IAccountService accountService) { _accountService = accountService; }

        [HttpPost]
        [Route("api/accounts/login")]
        public IActionResult Login([FromForm] string email, [FromForm] string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return BadRequest("Both inputs are required.");
            }
            bool success = _accountService.Login(email, password);
            if (!success)
                return NotFound($"Invalid Email or Password");
            return Ok("Successfully Logged In");
        }
        [HttpPost]
        [Route("api/accounts/register")]
        public IActionResult Register([FromForm] string email, [FromForm] string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return BadRequest("Both inputs are required.");
            }
            bool success = _accountService.Register(email, password);
            if (!success)
                return NotFound($"Account with that Email already exists");
            return Ok("Successfully Registered");
        }


    }
}
