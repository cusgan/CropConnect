namespace CropConnect.DTO
{
    public class ProfileDTO
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public string WorkExperience { get; set; } = string.Empty;
        public DateOnly BirthDate { get; set; }
    }
}
