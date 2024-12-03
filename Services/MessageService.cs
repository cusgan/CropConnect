using CropConnect.DTO;
using CropConnect.Models;
using CropConnect.Repositories.Interfaces;
using CropConnect.Services.Interfaces;

namespace CropConnect.Services
{
    public class MessageService: IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        public MessageService(IMessageRepository messageRepository) { _messageRepository = messageRepository; }
        public List<Message> GetMessages(int id1, int id2)
        {
            return _messageRepository.GetMessages(id1, id2);
        }
        public void SendMessage(MessageDTO messageDTO)
        {
            Message newMessage = new Message()
            {
                SenderId = messageDTO.SenderId,
                ReceiverId = messageDTO.ReceiverId,
                Content = messageDTO.Content,
                TimeStamp = DateTime.UtcNow
            };

            _messageRepository.SendMessage(newMessage);
        }

    }
}
