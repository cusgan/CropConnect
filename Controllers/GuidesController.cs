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

        //[HttpGet]
        //[Route("api/guides")]
        //public async Task<IActionResult> GetGuides()
        //{
        //    var guides = new List<Guide>();
        //    const string query = "SELECT * from Guide";
        //    using (var command = _connection.CreateCommand() as MySqlCommand)
        //    {
        //        if (command == null)
        //            return StatusCode(500, "Command could not be created.");
        //        command.CommandText = query;
        //        if (_connection.State != ConnectionState.Open)
        //            _connection.Open();
        //        using (var reader = await command.ExecuteReaderAsync() )
        //        {
        //            while (await reader.ReadAsync())
        //            {
        //                guides.Add(new Guide() { 
        //                    Id = reader.GetInt32("id") ,
        //                    Title = reader.GetString("title"),
        //                    Content = reader.GetString("content")
        //                });
        //            }
        //        }
        //    return Ok(guides);
        //    }
        //}
        //[HttpGet]
        //[Route("{id}")]
        //public async Task<IActionResult> GetGuideById(int id)
        //{
        //    const string query = "SELECT * FROM Guide WHERE id = @Id";

        //    using (var command = _connection.CreateCommand() as MySqlCommand)
        //    {
        //        if (command == null)
        //            return StatusCode(500, "Command could not be created.");

        //        command.CommandText = query;
        //        command.Parameters.AddWithValue("@Id", id);
        //        if (_connection.State != ConnectionState.Open)
        //            _connection.Open();
        //        using (var reader = await command.ExecuteReaderAsync())
        //        {
        //            if (await reader.ReadAsync())
        //            {
        //                // Map the record to a Guide object
        //                var guide = new Guide
        //                {
        //                    Id = reader.GetInt32("id"),
        //                    Title = reader.GetString("title"),
        //                    Content = reader.GetString("content")
        //                };
        //                return Ok(guide); // Return the single guide
        //            }
        //            else
        //            {
        //                return NotFound($"Guide with ID {id} not found.");
        //            }
        //        }
        //    }
        //}

        ////[HttpDelete]
        ////[Route("api/guides/{id}")]
        ////public IActionResult DeleteGuideById(int id)
        ////{
        ////    var guide = _guidesList.SingleOrDefault(x => x.Id == id);
        ////    if (guide != null)
        ////    {
        ////        _guidesList.Remove(guide);
        ////    }
        ////    return NoContent();
        ////}
        ////[HttpPost]
        ////[Route("api/guides")]
        ////public IActionResult CreateGuide(Guide guide)
        ////{

        ////    return NoContent();

    }
}
