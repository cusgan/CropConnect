namespace CropConnect.Models
{
    public class Guide
    {
        public required int Id { get; set; }
        //public required int AuthorId { get; set; }
        //public required Account Author { get; set; }
        public required string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        //public required DateTime DatePosted { get; set; }
        //public required DateTime LastUpdated { get; set; }
        //public string HeadingImage { get; set; } = string.Empty;
    }
}
