using CropConnect.Models;
using CropConnect.Services;
using CropConnect.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;


namespace CropConnect.Controllers
{
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IProfileService _profileService;
        public AccountsController(IAccountService accountService, IProfileService profileService) { _accountService = accountService; _profileService = profileService; }

        [HttpPost]
        [Route("api/accounts/login")]
        public IActionResult Login([FromForm] string email, [FromForm] string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return BadRequest("Both inputs are required.");
            }
            int userId = _accountService.Login(email, password);
            if (userId == -1)
                return NotFound($"Invalid Email or Password");
            return Ok(new { Message = "Successfully Logged In", userId = userId });
        }
        [HttpPost]
        [Route("api/accounts/register")]
        public IActionResult Register([FromForm] string email, [FromForm] string password, [FromForm] string name, [FromForm] string birthdate)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return BadRequest("Both inputs are required.");
            }
            var acc = _accountService.Register(email, password);
            if (acc == -1)
                return NotFound($"Account with that Email already exists");
            _profileService.CreateProfile(acc,name,birthdate);
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
