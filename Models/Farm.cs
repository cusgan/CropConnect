namespace CropConnect.Models
{
    public class Farm
    {
        public required int Id { get; set; }
        public required int OwnerAccountId { get; set; }
        public required Account OwnerAccount { get; set; }
        public required string FarmName { get; set; } = string.Empty;
        public required string Location { get; set; } = string.Empty;
        public required FarmType FarmType { get; set; }
        public required FarmSize FarmSize { get; set; }
        public required string ContactInfo { get; set; } = string.Empty;
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
