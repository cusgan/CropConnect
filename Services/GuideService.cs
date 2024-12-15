using CropConnect.DTO;
using CropConnect.Models;
using CropConnect.Repositories;
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

        public List<GuideDTO> QueryGuides(string query)
        {
            List<GuideDTO> guidesDTO = new List<GuideDTO>();
            List<Guide> guidesRaw = _guideRepository.QueryGuides(query);
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
        public bool CreateGuide(int authorid, string title, string content, IFormFile imageFile)
        {
            DateTime now = DateTime.Now;
            Guide guide = new Guide()
            {
                AuthorId = authorid,
                Title = title,
                Content = content,
                DatePosted = now,
                LastUpdated = now,
            };
            byte[]? imageData = null;
            if (imageFile != null && imageFile.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    imageFile.CopyTo(memoryStream);
                    imageData = memoryStream.ToArray();
                }
            }

            return _guideRepository.CreateGuide(guide, imageData);
        }
        public bool UpdateGuide(int guideId, string title, string content)
        {
            Guide? guide = _guideRepository.GetGuideById(guideId);
            if (guide == null)
                return false;

            guide.Title = title;
            guide.Content = content;
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
        public void SetHeadingImage(int id, IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    imageFile.CopyTo(memoryStream);
                    var imageData = memoryStream.ToArray();
                    _guideRepository.SetHeadingImage(id, imageData);
                }
            }
        }
    }
}
