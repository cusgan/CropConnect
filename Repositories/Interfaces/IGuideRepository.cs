using CropConnect.Models;

namespace CropConnect.Repositories.Interfaces
{
    public interface IGuideRepository
    {
        public List<Guide> GetGuides();
        public List<Guide> QueryGuides(string query);
        public Guide? GetGuideById(int id);
        public bool CreateGuide(Guide guide);
        public bool UpdateGuide(Guide guide);
        public void DeleteGuideById(int id);
    }
}
