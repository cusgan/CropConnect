namespace CropConnect.Models
{
    public class Profile
    {
        public required int Id { get; set; }
        public required int AccountId { get; set; }
        public required Account Account { get; set; }
        public required string Name { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public string WorkExperience { get; set; } = string.Empty;
        public DateOnly BirthDate { get; set; }

    }
}
