using CropConnect.DTO;
using CropConnect.Models;
using Microsoft.AspNetCore.Mvc;

namespace CropConnect.Repositories.Interfaces
{
    public interface INotificationRepository
    {
        public List<Notification> GetNotifications();
        public Account GetReceiverById(int id);
        public void SendNotification(Notification notification);
        public Notification GetNotificationById(int id);
        public void DeleteNotification(Notification notification);
        public List<Notification> GetNotificationsForAccountId(int id);
    }
}
