using CropConnect.DTO;

namespace CropConnect.Services.Interfaces
{
    public interface IProfileService
    {
        public void CreateProfile(int id);
        public void UpdateProfile(int id, ProfileDTO profileDTO);
    }
}
