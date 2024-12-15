using CropConnect.DTO;
using CropConnect.Services;
using CropConnect.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace CropConnect.Controllers
{
    [ApiController]
    public class GuidesController:ControllerBase
    {
        private readonly IGuideService _guideService;
        public GuidesController(IGuideService guideService) { _guideService = guideService; }

        [HttpGet]
        [Route("api/guides")]
        public IActionResult GetGuides()
        {
            return Ok(_guideService.GetGuides());
        }
        [HttpGet]
        [Route("api/guides/{id}")]
        public IActionResult GetGuideById(int id)
        {
            var guide = _guideService.GetGuideById(id);
            if (guide == null)
                return NotFound($"Guide with {id} not found.");
            return Ok(guide);
        }
        [HttpPost]
        [Route("api/guides/post")]
        public IActionResult CreateGuide([FromForm] int authorId, [FromForm] string title, [FromForm] string content, IFormFile HeadingImage)
        {
            bool success = _guideService.CreateGuide(authorId,title,content,HeadingImage);
            return Ok ($"Successfully created new Guide, success = {success}");
        }
        [HttpPut]
        [Route("api/guides/update")]
        public IActionResult UpdateGuide([FromForm] int guideId, [FromForm] string title, [FromForm] string content)
        {
            bool success = _guideService.UpdateGuide(guideId, title, content);
            return Ok ($"Successfully updated Guide, success = {success}");
        }
        [HttpDelete]
        [Route("api/guides/delete/{id}")]
        public IActionResult DeleteGuideById(int id)
        {
            _guideService.DeleteGuideById(id);
            return Ok($"Successfully deleted Guide with id: {id}");
        }
        [HttpGet]
        [Route("api/guides/query")]
        public IActionResult QueryGuides(string query)
        {
            _guideService.QueryGuides(query);
            return Ok(_guideService.QueryGuides(query));
        }
        [HttpPost]
        [Route("{id}/upload-image")]
        public IActionResult SetHeadingImage(int id, IFormFile imageFile)
        {
            if (imageFile == null || imageFile.Length == 0)
            {
                return BadRequest(new { Message = "Invalid image file." });
            }

            _guideService.SetHeadingImage(id, imageFile);

            return Ok(new { Message = "Image uploaded successfully." });
        }
    }
}
