using CropConnect.DTO;
using CropConnect.Models;

namespace CropConnect.Services.Interfaces
{
    public interface IProfileService
    {
        public void CreateProfile(int id);
        public void UpdateProfile(int id, ProfileDTO profileDTO);
        public Profile OpenProfile(int id);
        public void SetProfilePicture(int id, IFormFile imageFile);
        public Profile GetProfileByAccId(int id);
    }
}
