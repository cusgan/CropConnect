using CropConnect.DTO;
using CropConnect.Models;
using CropConnect.Repositories;
using CropConnect.Repositories.Interfaces;
using CropConnect.Services.Interfaces;

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
                Receiver = null,
                Content = notificationDTO.Content,
                Picture = notificationDTO.Picture,
                Destination = notificationDTO.Destination,
            };

            _notificationRepository.SendNotification(newNotification);
        }
    }
}
