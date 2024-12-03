using CropConnect.Models;
using CropConnect.Repositories.Interfaces;
using CropConnect.Services.Interfaces;

namespace CropConnect.Services
{
    public class GuideService : IGuideService
    {
        private readonly IGuideRepository _guideRepository;
        public GuideService(IGuideRepository guideRepository) { _guideRepository = guideRepository; }
        public List<Guide> GetGuides()
        {
            return _guideRepository.GetGuides();
        }
        public Guide GetGuideById(int id)
        {
            return _guideRepository.GetGuideById(id);
        }
    }
}
