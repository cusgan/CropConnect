using System.ComponentModel.DataAnnotations;

namespace CropConnect.Models
{
    public class Profile
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int AccountId { get; set; }
        [Required]
        public Account? Account { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;
        [StringLength(100)]
        public string Bio { get; set; } = string.Empty;
        [StringLength(100)]
        public string WorkExperience { get; set; } = string.Empty;
        public DateTime? BirthDate { get; set; }
        public byte[]? ProfilePicture { get; set; }
    }
}
