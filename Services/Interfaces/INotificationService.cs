using CropConnect.DTO;
using CropConnect.Models;

namespace CropConnect.Services.Interfaces
{
    public interface INotificationService
    {
        public List<Notification> GetNotifications();
        public void SendNotification(NotificationDTO notificationDTO);
    }
}
