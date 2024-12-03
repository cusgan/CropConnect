using System.ComponentModel.DataAnnotations;

namespace CropConnect.Models
{
    public class Notification
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public int ReceiverId { get; set; }
        [Required]
        public Account? Receiver { get; set; }
        [Required]
        [StringLength(100)]
        public string Content { get; set; } = string.Empty;
        [StringLength(100)]
        public string Picture { get; set; } = string.Empty;
        [Required]
        [StringLength(100)]
        public string Destination { get; set; } = string.Empty;
    }
}
