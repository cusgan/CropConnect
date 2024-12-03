using CropConnect.DTO;
using CropConnect.Services;
using CropConnect.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CropConnect.Controllers
{
    [ApiController]
    [Route("api/messages")]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
        public MessageController(IMessageService messageService) { _messageService = messageService; }
        [HttpGet]
        public IActionResult GetMessages(int id1, int id2)
        {
            var messages = _messageService.GetMessages(id1, id2);
            if (messages == null || !messages.Any())
            {
                return NotFound($"No messages found between User {id1} and User {id2}.");
            }
            return Ok(messages);
        }
        [HttpPost]
        public IActionResult SendMessage([FromForm] MessageDTO messageDTO)
        {
            if (messageDTO == null)
            {
                return BadRequest("Message data is required.");
            }

            _messageService.SendMessage(messageDTO);
            return StatusCode(201, "Message sent successfully");
        }
    }
}
