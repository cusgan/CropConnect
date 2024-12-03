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
                guidesDTO.Add(ToDTO(guide)!);
            }
            return guidesDTO;
        }
        public GuideDTO? GetGuideById(int id)
        {
            var guide = _guideRepository.GetGuideById(id);
            return ToDTO(guide);
        }
        public bool CreateGuide(int authorid, string title, string content, string heading)
        {
            DateTime now = DateTime.Now;
            Guide guide = new Guide()
            {
                AuthorId = authorid,
                Title = title,
                Content = content,
                HeadingImage = heading,
                DatePosted = now,
                LastUpdated = now
            };

            return _guideRepository.CreateGuide(guide);
        }
        public bool UpdateGuide(int guideId, string title, string content, string heading)
        {
            Guide? guide = _guideRepository.GetGuideById(guideId);
            if (guide == null)
                return false;

            guide.Title = title;
            guide.Content = content;
            guide.HeadingImage = heading;
            guide.LastUpdated = DateTime.Now;
            return _guideRepository.UpdateGuide(guide);
        }
        public void DeleteGuideById(int id)
        {
            _guideRepository.DeleteGuideById(id);
        }


        private static GuideDTO? ToDTO(Guide? guide)
        {
            GuideDTO? dto = null;
            if (guide != null)
            {
                AccountDTO adto;
                if (guide.Author != null)
                    adto = new AccountDTO()
                    {
                        Id = guide.AuthorId,
                        Email = guide.Author.Email
                    };
                else
                    adto = new AccountDTO()
                    {
                        Id = -1,
                        Email = "-"
                    };
                dto = new GuideDTO()
                {
                    Id = guide.Id,
                    Author = adto,
                    Title = guide.Title,
                    Content = guide.Content,
                    DatePosted = guide.DatePosted,
                    LastUpdated = guide.LastUpdated,
                    HeadingImage = guide.HeadingImage
                };
            }
            return dto;
        }
        private static Guide? ToRaw(GuideDTO? guide)
        {
            Guide? raw = null;
            if (guide != null)
            {
                raw = new Guide()
                {
                    Id = guide.Id,
                    AuthorId = guide.Author.Id,
                    Author = null,
                    Title = guide.Title,
                    Content = guide.Content,
                    DatePosted = guide.DatePosted,
                    LastUpdated = guide.LastUpdated,
                    HeadingImage = guide.HeadingImage
                };
            }
            return raw;
        }
    }
}
