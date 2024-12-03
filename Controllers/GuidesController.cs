using CropConnect.DTO;
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
        public IActionResult CreateGuide([FromForm] int authorId, [FromForm] string title, [FromForm] string content, [FromForm] string heading)
        {
            bool success = _guideService.CreateGuide(authorId,title,content,heading);
            return Ok ($"Successfully created new Guide, success = {success}");
        }
        [HttpPut]
        [Route("api/guides/update")]
        public IActionResult UpdateGuide([FromForm] int guideId, [FromForm] string title, [FromForm] string content, [FromForm] string heading)
        {
            bool success = _guideService.UpdateGuide(guideId, title, content, heading);
            return Ok ($"Successfully updated Guide, success = {success}");
        }
        [HttpDelete]
        [Route("api/guides/delete/{id}")]
        public IActionResult DeleteGuideById(int id)
        {
            _guideService.DeleteGuideById(id);
            return Ok($"Successfully deleted Guide with id: {id}");
        }

        

    }
}
