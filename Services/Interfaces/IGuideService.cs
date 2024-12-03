using CropConnect.DTO;

namespace CropConnect.Services.Interfaces
{
    public interface IGuideService
    {
        public List<GuideDTO> GetGuides();
        public GuideDTO? GetGuideById(int id);
    }
}
