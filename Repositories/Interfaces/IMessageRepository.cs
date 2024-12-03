using CropConnect.DTO;
using CropConnect.Models;

namespace CropConnect.Repositories.Interfaces
{
    public interface IMessageRepository
    {
        public List<Message> GetMessages(int id1, int id2);
        public void SendMessage(Message message);
    }
}
