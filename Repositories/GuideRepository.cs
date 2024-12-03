using CropConnect.Models;
using CropConnect.Repositories.Interfaces;

namespace CropConnect.Repositories
{
    public class GuideRepository : IGuideRepository
    {
        private readonly AppDbContext _appDbContext;
        public GuideRepository(AppDbContext appDbContext){ _appDbContext = appDbContext; }
        public Guide? GetGuideById(int id)
        {
            return _appDbContext.Guide.SingleOrDefault(x => x.Id == id);
        }
        public List<Guide> GetGuides()
        {
            return _appDbContext.Guide.ToList();
        }
    }
}
