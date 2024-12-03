using CropConnect.DTO;
using CropConnect.Models;
using CropConnect.Repositories.Interfaces;

namespace CropConnect.Repositories
{
    public class MessageRepository: IMessageRepository
    {
        private readonly AppDbContext _appDbContext;
        public MessageRepository(AppDbContext appDbContext) { _appDbContext = appDbContext; }
        public List<Message> GetMessages(int id1, int id2)
        {
            return _appDbContext.Message.Where(m => (m.SenderId == id1 && m.ReceiverId == id2) || (m.SenderId == id2 && m.ReceiverId == id1)).OrderBy(m => m.TimeStamp).ToList();
        }
        public void SendMessage(Message message)
        {
            _appDbContext.Message.Add(message);
            _appDbContext.SaveChanges();
        }

    }
}
