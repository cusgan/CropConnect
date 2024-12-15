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
        [HttpGet]
        [Route("{id}")]
        public IActionResult OpenProfile(int id)
        {
            var profile = _profileService.OpenProfile(id);

            if (profile == null)
                return NotFound(new { Message = "Profile not found." });

            return Ok(profile);
        }
        [HttpPost]
        [Route("{id}/upload-image")]
        public IActionResult SetProfilePicture(int id, IFormFile imageFile)
        {
            if (imageFile == null || imageFile.Length == 0)
            {
                return BadRequest(new { Message = "Invalid image file." });
            }

            _profileService.SetProfilePicture(id, imageFile);

            return Ok(new { Message = "Image uploaded successfully." });
        }
        [HttpGet]
        [Route("{id}/profile")]
        public IActionResult GetProfileByAccId(int id)
        {
            var profile = _profileService.GetProfileByAccId(id);

            if (profile == null)
                return NotFound(new { Message = "Profile not found." });

            return Ok(profile);
        }
    }
}
