using CropConnect.Models;
using CropConnect.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;


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
        [HttpPut]
        [Route("api/accounts/update")]
        public IActionResult ChangePassword([FromForm] int accountId, [FromForm] string oldPassword, [FromForm] string newPassword)
        {
            if (string.IsNullOrEmpty(oldPassword) || string.IsNullOrEmpty(newPassword))
            {
                return BadRequest("Missing or incomplete arguments");
            }
            bool success = _accountService.ChangePassword(accountId, oldPassword, newPassword);
            if (!success)
                return NotFound($"Could be able to change the password");
            return Ok("Successfully Update Password");
        }
        [HttpDelete]
        [Route("api/accounts/delete")]
        public IActionResult DeleteAccount([FromForm] string email, [FromForm] string password)
        {
            _accountService.DeleteAccount(email, password);
            return Ok("Successfully Deleted Account.");
        }

    }
}
