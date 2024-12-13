using CropConnect.Models;
using CropConnect.Repositories.Interfaces;

namespace CropConnect.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly AppDbContext _appDbContext;
        public ProfileRepository(AppDbContext appDbContext) { _appDbContext = appDbContext; }
        public void CreateProfile(Profile profile)
        {
            _appDbContext.Profile.Add(profile);
            _appDbContext.SaveChanges();
        }
        public Profile GetProfileById(int id)
        {
            return _appDbContext.Profile
                .FirstOrDefault(p => p.Id == id);
        }
        public void UpdateProfile(Profile profile)
        {
            _appDbContext.Profile.Update(profile);
            _appDbContext.SaveChanges();
        }
    }
}
