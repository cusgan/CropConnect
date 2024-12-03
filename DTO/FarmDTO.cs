namespace CropConnect.DTO
{
    public class FarmDTO
    {
        public int Id { get; set; }
        public int OwnerAccountId { get; set; }
        public string FarmName { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string FarmType { get; set; } = string.Empty;
        public string FarmSize { get; set; } = string.Empty;
        public string ContactInfo { get; set; } = string.Empty;
    }

}
