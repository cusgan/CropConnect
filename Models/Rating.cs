using System.ComponentModel.DataAnnotations;

namespace CropConnect.Models
{
    public class Rating
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int RatedId { get; set; }
        [Required]
        public Account? Rated { get; set; }
        [Required]
        public int RaterId { get; set; }
        [Required]
        public Account? Rater { get; set; }
        [Required]
        public float Value { get; set; } = 1.0f;
        [StringLength(100)]
        public string Content { get; set; } = string.Empty;
    }
}
