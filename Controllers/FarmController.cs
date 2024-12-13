using CropConnect.DTO;
using CropConnect.Services;
using CropConnect.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CropConnect.Controllers
{
    [ApiController]
    [Route("api/farms")]
    public class FarmController : ControllerBase
    {
        private readonly IFarmService _farmService;
        public FarmController(IFarmService farmService) { _farmService = farmService; }
        [HttpPost]
        public IActionResult RegisterFarm([FromForm] FarmDTO farmDTO)
        {
            if (farmDTO == null)
            {
                return BadRequest("Posting data is required.");
            }

            _farmService.RegisterFarm(farmDTO);
            return StatusCode(201, "Farm registered successfully");
        }
        [HttpPut]
        [Route("edit/{id}")]
        public IActionResult UpdateFarm(int id, [FromForm] FarmDTO farmDTO)
        {
            if (farmDTO == null)
            {
                return BadRequest("Farm data is required.");
            }

            try
            {
                _farmService.UpdateFarm(id, farmDTO);
                return Ok("Farm updated successfully.");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
