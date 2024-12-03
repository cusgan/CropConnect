using CropConnect.DTO;
using CropConnect.Services;
using CropConnect.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CropConnect.Controllers
{
    [ApiController]
    [Route("api/ratings")]
    public class RatingController : ControllerBase
    {
        private readonly IRatingService _ratingService;
        public RatingController(IRatingService ratingService) { _ratingService = ratingService; }
        [HttpPost]
        public IActionResult CreateRating([FromForm] RatingDTO ratingDTO)
        {
            if (ratingDTO == null)
            {
                return BadRequest("Rating data is required.");
            }

            _ratingService.CreateRating(ratingDTO);
            return StatusCode(201, "Rating posted successfully");
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetRatings(int id)
        {
            var ratings = _ratingService.GetRatings(id);
            if (ratings == null || !ratings.Any())
            {
                return NotFound($"No ratings found for Account ID {id}.");
            }
            return Ok(ratings);
        }
        [HttpPut]
        [Route("edit/{id}")]
        public IActionResult UpdateRating(int id, [FromForm] RatingDTO ratingDTO)
        {
            if (ratingDTO == null)
            {
                return BadRequest("Rating data is required.");
            }

            try
            {
                _ratingService.UpdateRating(id, ratingDTO);
                return Ok("Rating updated successfully.");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpDelete]
        public IActionResult DeleteRating(int id)
        {
            var success = _ratingService.DeleteRating(id);
            if (!success)
            {
                return NotFound($"Rating with ID {id} not found.");
            }
            return NoContent();
        }

    }
}
