using CropConnect.Models;

namespace CropConnect.Services.Interfaces
{
    public interface IGuideService
    {
        public List<Guide> GetGuides();
        public Guide GetGuideById(int id);
    }
}
