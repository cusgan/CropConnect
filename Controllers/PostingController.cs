using CropConnect.DTO;
using CropConnect.Services;
using CropConnect.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CropConnect.Controllers
{
    [ApiController]
    [Route("api/postings")]
    public class PostingController : ControllerBase
    {
        private readonly IPostingService _postingService;
        public PostingController(IPostingService postingService) { _postingService = postingService; }
        [HttpPost]
        public IActionResult CreatePosting([FromForm] PostingDTO postingDTO)
        {
            if (postingDTO == null)
            {
                return BadRequest("Posting data is required.");
            }

            _postingService.CreatePosting(postingDTO);
            return StatusCode(201, "Posting created successfully");
        }
        [HttpGet]
        public IActionResult GetAllPostings()
        {
            var postings = _postingService.GetAllPostings();
            if (postings == null || !postings.Any())
            {
                return NotFound($"No postings created yet.");
            }
            return Ok(postings);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetPostingsById(int id)
        {
            var postings = _postingService.GetPostingsById(id);
            if (postings == null || !postings.Any())
            {
                return NotFound($"No postings found for Account ID {id}.");
            }
            return Ok(postings);
        }
        [HttpPut]
        [Route("edit/{id}")]
        public IActionResult UpdatePosting(int id, [FromForm] PostingDTO postingDTO)
        {
            if (postingDTO == null)
            {
                return BadRequest("Posting data is required.");
            }

            try
            {
                _postingService.UpdatePosting(id, postingDTO);
                return Ok("Posting updated successfully.");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpDelete]
        public IActionResult DeletePosting(int id)
        {
            var success = _postingService.DeletePosting(id);
            if (!success)
            {
                return NotFound($"Posting with ID {id} not found.");
            }
            return NoContent();
        }
    }
}
