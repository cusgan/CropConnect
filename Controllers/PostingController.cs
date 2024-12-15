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
        public IActionResult CreatePosting([FromForm] PostingDTO postingDTO, IFormFile ProductImage)
        {
            if (postingDTO == null)
            {
                return BadRequest("Posting data is required.");
            }

            _postingService.CreatePosting(postingDTO, ProductImage);
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
        [HttpPut]
        [Route("buy/{id}")]
        public IActionResult BuyProduct(int id, [FromForm] int quantity)
        {
            var success = _postingService.BuyProduct(id, quantity);
            if (!success)
            {
                return NotFound($"Product with ID {id} is out of stock.");
            }
            return NoContent();
        }
        [HttpPost]
        [Route("{id}/upload-image")]
        public IActionResult SetProductImage(int id, IFormFile imageFile)
        {
            if (imageFile == null || imageFile.Length == 0)
            {
                return BadRequest(new { Message = "Invalid image file." });
            }

            _postingService.SetProductImage(id, imageFile);

            return Ok(new { Message = "Image uploaded successfully." });
        }
    }
}
