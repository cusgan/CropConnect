using CropConnect.Models;

namespace CropConnect.Repositories.Interfaces
{
    public interface IGuideRepository
    {
        public List<Guide> GetGuides();
        public Guide? GetGuideById(int id);
    }
}
