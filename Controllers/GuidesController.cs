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


    }
}
