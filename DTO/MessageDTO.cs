namespace CropConnect.DTO
{
    public class MessageDTO
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime TimeStamp { get; set; }
    }
}
