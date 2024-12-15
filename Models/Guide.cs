using System.ComponentModel.DataAnnotations;

namespace CropConnect.Models
{
    public class Guide
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int AuthorId { get; set; }
        [Required]
        public Account? Author { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; } = string.Empty;
        [StringLength(100)]
        public string Content { get; set; } = string.Empty;
        [Required]
        public DateTime DatePosted { get; set; }
        [Required]
        public DateTime LastUpdated { get; set; }
        public byte[]? HeadingImage { get; set; }
    }
}
