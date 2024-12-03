using CropConnect.DTO;
using CropConnect.Models;
using CropConnect.Repositories.Interfaces;
using CropConnect.Services.Interfaces;

namespace CropConnect.Services
{
    public class GuideService : IGuideService
    {
        private readonly IGuideRepository _guideRepository;
        public GuideService(IGuideRepository guideRepository) { _guideRepository = guideRepository; }
        public List<GuideDTO> GetGuides()
        {
            List<GuideDTO> guidesDTO = new List<GuideDTO>();
            List<Guide> guidesRaw = _guideRepository.GetGuides();
            foreach (var guide in guidesRaw) 
            {
                guidesDTO.Add(new GuideDTO(guide));
            }
            return guidesDTO;
        }
        public GuideDTO? GetGuideById(int id)
        {
            var guide = _guideRepository.GetGuideById(id);
            return GuideDTO.Get(guide);
        }
    }
}
