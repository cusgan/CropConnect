namespace CropConnect.DTO
{
    public class PostingDTO
    {
        public int Id { get; set; }
        public int PosterId { get; set; }
        public string ProductImage { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public string ProductDescription { get; set; } = string.Empty;
        public string ProductType { get; set; } = string.Empty;
        public string UnitType { get; set; } = string.Empty;
        public float Price { get; set; }
        public int Stock { get; set; }
        public string AdditionalInfo { get; set; } = string.Empty;
    }
}
