namespace CropConnect.DTO
{
    public class NotificationDTO
    {
        public int Id { get; set; }
        public int ReceiverId { get; set; }
        public string Content { get; set; } = string.Empty;
        public string Picture { get; set; } = string.Empty;
        public string Destination { get; set; } = string.Empty;
    }
}
