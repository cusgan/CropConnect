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
        public Account GetReceiverById(int id)
        {
            return _appDbContext.Account.FirstOrDefault(n => n.Id == id);
        }
        public void SendNotification(Notification notification)
        {
            _appDbContext.Notification.Add(notification);
            _appDbContext.SaveChanges();
        }
        public Notification GetNotificationById(int id)
        {
            return _appDbContext.Notification.FirstOrDefault(n => n.Id == id);
        }
        public void DeleteNotification(Notification notification)
        {
            _appDbContext.Notification.Remove(notification);
            _appDbContext.SaveChanges();
        }
        public List<Notification> GetNotificationsForAccountId(int id)
        {
            return _appDbContext.Notification
                .Where(n => n.ReceiverId == id)
                .ToList();
        }
    }
}
