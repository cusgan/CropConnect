namespace CropConnect.Models
{
    public class Rating
    {
        public required int Id { get; set; }
        public required int RatedId { get; set; }
        public required Account Rated { get; set; }
        public required int RaterId { get; set; }
        public required Account Rater { get; set; }
        public required float Value { get; set; } = 1.0f;
        public string Content { get; set; } = string.Empty;
    }
}
