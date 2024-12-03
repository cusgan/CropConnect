using CropConnect.DTO;
using CropConnect.Models;

namespace CropConnect.Services.Interfaces
{
    public interface IMessageService
    {
        public List<Message> GetMessages(int id1, int id2);
        public void SendMessage(MessageDTO messageDTO);
    }
}
