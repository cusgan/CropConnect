using System.ComponentModel.DataAnnotations;

namespace CropConnect.Models
{
    public class Posting
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int PosterId { get; set; }
        [Required]
        public Account? Poster { get; set; }
        [StringLength(100)]
        public string ProductImage { get; set; } = string.Empty;
        [Required]
        [StringLength(50)]
        public string ProductName { get; set; } = string.Empty;
        [StringLength(100)]
        public string ProductDescription { get; set; } = string.Empty;
        [Required]
        public ProductType ProductType { get; set; }
        [Required]
        public UnitType UnitType { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public int Stock { get; set; }
        [StringLength(100)]
        public string AdditionalInfo { get; set; } = string.Empty;
    }
    public enum ProductType
    {
        Crop,
        Dairy,
        Seeds,
        Meat,
        Livestock,
        Processed,
        Misc
    }

    public enum UnitType
    {
        Piece,
        Kilogram,
        Liter,
        Pack,
        Other
    }

}
