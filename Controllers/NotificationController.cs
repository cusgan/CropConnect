using CropConnect.DTO;
using CropConnect.Models;
using CropConnect.Services;
using CropConnect.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CropConnect.Controllers
{
    [ApiController]
    [Route("api/notifications")]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        public NotificationController(INotificationService notificationService) { _notificationService = notificationService; }
        [HttpGet]
        public IActionResult GetNotifications()
        {
            return Ok(_notificationService.GetNotifications());
        }
        [HttpPost]

        public IActionResult SendNotification(NotificationDTO notificationDTO)
        {
            //return NotFound(notificationDTO.ReceiverId);
            _notificationService.SendNotification(notificationDTO);
            return StatusCode(201, "Notification created successfully");
        }
    }
}
