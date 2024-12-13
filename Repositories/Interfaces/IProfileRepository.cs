using CropConnect.Models;

namespace CropConnect.Repositories.Interfaces
{
    public interface IProfileRepository
    {
        public void CreateProfile(Profile profile);
        public Profile GetProfileById(int id);
        public void UpdateProfile(Profile profile);
    }
}
