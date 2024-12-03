using CropConnect.Models;

namespace CropConnect.DTO
{
    public class GuideDTO
    {
        public int Id { get; set; }
        public Account? Author { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime DatePosted { get; set; }
        public DateTime LastUpdated { get; set; }
        public string HeadingImage { get; set; } = string.Empty;
        public GuideDTO(Guide guide)
        {
            if (guide != null)
            {
                Id = guide.Id;
                Author = guide.Author;
                Title = guide.Title;
                Content = guide.Content;
                DatePosted = guide.DatePosted;
                LastUpdated = guide.LastUpdated;
                HeadingImage = guide.HeadingImage;
            }
        }
        public static GuideDTO? Get(Guide? guide)
        {
            if (guide != null)
                return new GuideDTO(guide);
            return null;
        }
    }

}
