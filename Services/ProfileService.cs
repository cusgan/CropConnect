using CropConnect.DTO;
using CropConnect.Models;
using CropConnect.Repositories;
using CropConnect.Repositories.Interfaces;
using CropConnect.Services.Interfaces;

namespace CropConnect.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _profileRepository;
        public ProfileService(IProfileRepository profileRepository) { _profileRepository = profileRepository; }
        public void CreateProfile(int id)
        {
            Profile newProfile = new Profile
            {
                AccountId = id,
                Name = "",
                Bio = "",
                WorkExperience = "",
                BirthDate = null,
            };
            _profileRepository.CreateProfile(newProfile);
        }
        public void UpdateProfile(int id, ProfileDTO profileDTO)
        {
            var profile = _profileRepository.GetProfileById(id);
            if (profile == null)
            {
                throw new Exception($"Profile with ID {id} not found.");
            }
            profile.Name = profileDTO.Name;
            profile.Bio = profileDTO.Bio;
            profile.WorkExperience = profileDTO.WorkExperience;
            profile.BirthDate = profileDTO.BirthDate;

            _profileRepository.UpdateProfile(profile);
        }
        public Profile OpenProfile(int id)
        {
            return _profileRepository.GetProfileById(id);
        }
        public void SetProfilePicture(int id, IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    imageFile.CopyTo(memoryStream);
                    var imageData = memoryStream.ToArray();
                    _profileRepository.SetProfilePicture(id, imageData);
                }
            }
        }
    }
}
