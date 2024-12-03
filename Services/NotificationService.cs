using CropConnect.DTO;
using CropConnect.Models;
using CropConnect.Repositories;
using CropConnect.Repositories.Interfaces;
using CropConnect.Services.Interfaces;
using Microsoft.Identity.Client;

namespace CropConnect.Services
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;
        public NotificationService(INotificationRepository notificationRepository) { _notificationRepository = notificationRepository; }
        public List<Notification> GetNotifications()
        {
            return _notificationRepository.GetNotifications();
        }
        public void SendNotification(NotificationDTO notificationDTO)
        {
            Notification newNotification = new Notification()
            {
                Id = notificationDTO.Id,
                ReceiverId = notificationDTO.ReceiverId,
                Receiver = _notificationRepository.GetReceiverById(notificationDTO.ReceiverId),
                Content = notificationDTO.Content,
                Picture = notificationDTO.Picture,
                Destination = notificationDTO.Destination,
            };

            _notificationRepository.SendNotification(newNotification);
        }
        public bool DeleteNotification(int id)
        {
            var notification = _notificationRepository.GetNotificationById(id);
            if (notification == null)
                return false;

            _notificationRepository.DeleteNotification(notification);
            return true;
        }
        public List<Notification> GetNotificationsForAccountId(int id)
        {
            return _notificationRepository.GetNotificationsForAccountId(id);
        }
    }
}
