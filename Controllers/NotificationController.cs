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

        public IActionResult SendNotification([FromForm] NotificationDTO notificationDTO)
        {
            _notificationService.SendNotification(notificationDTO);
            return StatusCode(201, "Notification created successfully");
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteNotification(int id)
        {
            var success = _notificationService.DeleteNotification(id);
            if (!success)
            {
                return NotFound($"Notification with ID {id} not found.");
            }
            return NoContent();
        }
        [HttpGet]
        [Route("account/{id}")]
        public IActionResult GetNotificationForAccountId(int id)
        {
            var notifications = _notificationService.GetNotificationsForAccountId(id);
            if (notifications == null || !notifications.Any())
            {
                return NotFound($"No notifications found for Account ID {id}.");
            }
            return Ok(notifications);
        }
    }
}
