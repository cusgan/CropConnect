using CropConnect.DTO;
using CropConnect.Models;
using Microsoft.AspNetCore.Mvc;

namespace CropConnect.Repositories.Interfaces
{
    public interface INotificationRepository
    {
        public List<Notification> GetNotifications();
        public void SendNotification(Notification notification);
    }
}
