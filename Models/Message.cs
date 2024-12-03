using System.ComponentModel.DataAnnotations;

namespace CropConnect.Models
{
    public class Message
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int SenderId { get; set; }
        [Required]
        public Account? Sender { get; set; }
        [Required]
        public int ReceiverId { get; set; }
        [Required]
        public Account? Receiver { get; set; }
        [Required]
        [StringLength(100)]
        public string Content { get; set; } = string.Empty;
        [Required]
        public DateTime TimeStamp { get; set; }
    }
}
