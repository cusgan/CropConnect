using System.ComponentModel.DataAnnotations;

namespace CropConnect.Models
{
    public class Account
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string PasswordHash { get; set; } = string.Empty;
    }
}
