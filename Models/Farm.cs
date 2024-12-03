using System.ComponentModel.DataAnnotations;

namespace CropConnect.Models
{
    public class Farm
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int OwnerAccountId { get; set; }
        [Required]
        public Account? OwnerAccount { get; set; }
        [Required]
        [StringLength(50)]
        public string FarmName { get; set; } = string.Empty;
        [Required]
        [StringLength(100)]
        public string Location { get; set; } = string.Empty;
        [Required]
        public FarmType FarmType { get; set; }
        [Required]
        public FarmSize FarmSize { get; set; }
        [Required]
        [StringLength(50)]
        public string ContactInfo { get; set; } = string.Empty;
    }

    // Enum for Farm Type
    public enum FarmType
    {
        Livestock,
        Crops,
        Mixed,
        Aquaculture,
        Other
    }

    // Enum for Farm Size
    public enum FarmSize
    {
        Small,
        Medium,
        Large
    }

}
