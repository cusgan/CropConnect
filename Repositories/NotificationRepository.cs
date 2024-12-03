using CropConnect.DTO;
using CropConnect.Models;
using CropConnect.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CropConnect.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly AppDbContext _appDbContext;
        public NotificationRepository(AppDbContext appDbContext) { _appDbContext = appDbContext; }
        public List<Notification> GetNotifications()
        {
            return _appDbContext.Notification.ToList();
        }
        public void SendNotification(Notification notification)
        {
            _appDbContext.Notification.Add(notification);
            _appDbContext.SaveChanges();
        }
    }
}
