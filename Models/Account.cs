namespace CropConnect.Models
{
    public class Account
    {
        public required string Email { get; set; } = string.Empty;
        public required string PasswordHash { get; set; } = string.Empty;
    }
}
