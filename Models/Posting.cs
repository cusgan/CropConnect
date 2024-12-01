namespace CropConnect.Models
{
    public class Posting
    {
        public required int Id { get; set; }
        public required int PosterId { get; set; }
        public required Account Poster { get; set; }
        public string ProductImage { get; set; } = string.Empty;
        public required string ProductName { get; set; } = string.Empty;
        public string ProductDescription { get; set; } = string.Empty;
        public required ProductType ProductType { get; set; }
        public required UnitType UnitType { get; set; }
        public required float Price { get; set; }
        public required int Stock { get; set; }
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
