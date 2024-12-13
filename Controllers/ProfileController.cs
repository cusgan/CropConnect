using CropConnect.DTO;
using CropConnect.Services;
using CropConnect.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CropConnect.Controllers
{
    [ApiController]
    [Route("api/profile")]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;
        public ProfileController(IProfileService profileService) { _profileService = profileService; }
        [HttpPut]
        [Route("edit/{id}")]
        public IActionResult UpdateProfile(int id, [FromForm] ProfileDTO profileDTO)
        {
            if (profileDTO == null)
            {
                return BadRequest("Profile data is required.");
            }

            try
            {
                _profileService.UpdateProfile(id, profileDTO);
                return Ok("Profile updated successfully.");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
