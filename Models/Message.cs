namespace CropConnect.Models
{
    public class Message
    {
        public required int Id { get; set; }
        public required int SenderId { get; set; }
        public required Account Sender { get; set; }
        public required int ReceiverId { get; set; }
        public required Account Receiver { get; set; }
        public required string Content { get; set; } = string.Empty;
        public required DateTime TimeStamp { get; set; }
    }
}
