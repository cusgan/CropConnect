namespace CropConnect.Models
{
    public class Notification
    {
        public required int Id { get; set; }
        public required int ReceiverId { get; set; }
        public required Account Receiver { get; set; }
        public required string Content { get; set; } = string.Empty;
        public string Picture { get; set; } = string.Empty;
        public required string Destination { get; set; } = string.Empty;
    }
}
