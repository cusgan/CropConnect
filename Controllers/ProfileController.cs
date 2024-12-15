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
        //[HttpPut]
        //[Route("edit/{id}")]
        //public IActionResult UpdateProfile(int id, [FromForm] string Name, [FromForm] string Bio, [FromForm] string WorkExperience)
        //{
        //    if (Name == null)
        //    {
        //        return BadRequest("Name is required.");
        //    }
        //    if (!ModelState.IsValid)
        //    {
        //        _profileService.UpdateProfile(id, Name, Bio, WorkExperience);
        //        return Ok("Profile updated successfully.");
        //    }
        //    try
        //    {
        //        _profileService.UpdateProfile(id, Name, Bio, WorkExperience);
        //        return Ok("Profile updated successfully.");
        //    }
        //    catch (Exception ex)
        //    {
        //        return NotFound(ex.Message);
        //    }
        //}
        [HttpPut]
        [Route("edit/{id}")]
        public IActionResult UpdateProfile(int id, [FromForm] string Name, [FromForm] string Bio, [FromForm] string WorkExperience)
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                return BadRequest("Name is required.");
            }

            try
            {
                // Call the service to update the profile
                _profileService.UpdateProfile(id, Name, Bio, WorkExperience);
                return Ok("Profile updated successfully.");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message); // Catch any exception and return NotFound
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
