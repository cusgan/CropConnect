using CropConnect.Models;

namespace CropConnect.DTO
{
    public class GuideDTO
    {
        public int Id { get; set; }
        public required AccountDTO Author { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime DatePosted { get; set; }
        public DateTime LastUpdated { get; set; }
        public string HeadingImage { get; set; } = string.Empty;

    }

}
