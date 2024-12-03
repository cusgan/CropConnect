namespace CropConnect.DTO
{
    public class RatingDTO
    {
        public int Id { get; set; }
        public int RatedId { get; set; }
        public int RaterId { get; set; }
        public float Value { get; set; } = 1.0f;
        public string Content { get; set; } = string.Empty;
    }
}
